using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  internal class SearchResultPath : IPath
  {
    private LinkedList<SearchVertex> m_vertices;
    private Dictionary<string, LinkedListNode<SearchVertex>> m_verticesLookup;

    public SearchResultPath(SearchVertex p_goal)
    {
      m_vertices = new LinkedList<SearchVertex>();
      m_verticesLookup = new Dictionary<string, LinkedListNode<SearchVertex>>();

      Constract(p_goal);
    }


       #region IPath
    public IVertex EndVertex
    {
      get
      {
        return m_vertices.Last.Value.GraphVertex;
      }
    }

    public bool IsEmpty
    {
      get
      {
        return m_vertices.Count == 0;
      }
    }

    public IVertex NextVertex(IVertex p_sourceVertex)
    {
      IVertex rv = null;
      string vertexName = string.Empty;
      LinkedListNode<SearchVertex> next = null;

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

    public IVertex StartVertex
    {
      get
      {
        return m_vertices.First.Value.GraphVertex; 
      }
    }

    public double Weight //redundant, remove from the interface
    {
      get { throw new NotSupportedException(); }
    }
      #endregion

    private void Constract(SearchVertex p_goal)
    {
      SearchVertex currVertex = null;

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
