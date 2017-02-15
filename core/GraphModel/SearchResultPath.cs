using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  /// <summary>
  /// Represents directed path between two graph vertices.
  /// </summary>
  internal class SearchResultPath : IPath
  {
    private LinkedList<SearchVertex> m_vertices;
    //Lookup hash designated to find vertex within the linked list in O(1).
    private Dictionary<string, LinkedListNode<SearchVertex>> m_verticesLookup;
    private double m_weight;

    /// <summary>
    /// Initialize SearchResultPath instance which uses the specified goal vertex
    /// to reconstruct the path.
    /// </summary>
    /// <param name="p_goal">Specific path goal vertex.</param>
    /// <remarks>
    /// The goal object is a head of linked list that represents discovered path
    /// from end to start, the path reconstruction is of course reversing it.
    /// </remarks>
    public SearchResultPath(SearchVertex p_goal)
    {
      m_vertices = new LinkedList<SearchVertex>();
      m_verticesLookup = new Dictionary<string, LinkedListNode<SearchVertex>>();

      Constract(p_goal);
    }


       #region IPath
    /// <summary>
    /// Gets path's end.
    /// </summary>
    public IVertex EndVertex
    {
      get
      {
        return m_vertices.Last.Value.GraphVertex;
      }
    }

    /// <summary>
    /// Gets if the path is empty.
    /// </summary>
    public bool IsEmpty
    {
      get
      {
        return m_vertices.Count == 0;
      }
    }

    /// <summary>
    /// Gets the following vertex of the specified vertex.
    /// </summary>
    /// <param name="p_sourceVertex">The specific source vertex.</param>
    /// <returns>The vertex that follows the specified source vertex, null if source vertex is last in the parh.</returns>
    /// <exception cref="ArgumentNullException">Source vertex is null.</exception>
    /// <exception cref="InvalidOperationException">Source is not part of the path.</exception>
    public IVertex NextVertex(IVertex p_sourceVertex)
    {
      IVertex rv = null;
      string vertexName = string.Empty;
      LinkedListNode<SearchVertex> next = null;

      if (null == p_sourceVertex)
      {
        throw new ArgumentNullException("p_sourceVertex", "Source vertex can not be null");
      }

      vertexName = p_sourceVertex.Name;
      if (!m_verticesLookup.ContainsKey(vertexName))
      {
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "{0} is not in the path", vertexName));
      }

      next = m_verticesLookup[vertexName].Next;
      if (null != next)
      {
        rv = next.Value.GraphVertex;
      }

      return rv;
    }

    /// <summary>
    /// Gets path's start.
    /// </summary>
    public IVertex StartVertex
    {
      get
      {
        return m_vertices.First.Value.GraphVertex; 
      }
    }

    /// <summary>
    /// Gets total path weight.
    /// </summary>
    public double Weight
    {
      get
      {
        return m_weight;
      }
    }
      #endregion

    /// <summary>
    /// Constructs the path from start to end. 
    /// </summary>
    /// <param name="p_goal">End vertex, head of end-to-start path.</param>
    private void Constract(SearchVertex p_goal)
    {
      SearchVertex currVertex = null;

      m_weight = p_goal.Delta;
      currVertex = p_goal;      
      while (null != currVertex)
      {
        LinkedListNode<SearchVertex> node = m_vertices.AddFirst(currVertex);
        m_verticesLookup.Add(currVertex.Name, node);

        currVertex = currVertex.Prev;
      }
    }
  }
}
