using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  /// <summary>
  /// Represents collection of edges.
  /// </summary>
  internal class Edges : IEdges
  {
    private Dictionary<string, Edge> m_edges;

    /// <summary>
    /// Initializes Edges instance.
    /// </summary>
    public Edges()
    {
      m_edges = new Dictionary<string, Edge>();
    }


       #region IEdges implementation
    /// <summary>
    /// Gets the number of edges in the collection.
    /// </summary>
    public int Count
    {
      get 
      {
        return m_edges.Count;
      }
    }

    /// <summary>
    /// Gets the edge with the specified id.
    /// </summary>
    /// <param name="p_edgeId">The id of the edge to get.</param>
    /// <returns>The edge with the specified id.</returns>
    /// <exception cref="ArgumentException">The id is empty or null.</exception>
    /// <exception cref="KeyNotFoundException">The id was not found.</exception>
    public IEdge this[string p_edgeId]
    {
      get 
      {
        if (string.IsNullOrEmpty(p_edgeId))
        {
          throw new ArgumentException("Id can not be null or empty.", "p_edgeId");
        }

        return m_edges[p_edgeId];
      }
    }

    public IEnumerator<IEdge> GetEnumerator()
    {
      return m_edges.Values.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return m_edges.Values.GetEnumerator();
    }
      #endregion

    /// <summary>
    /// Adds the specified edge.
    /// </summary>
    /// <param name="p_edge">Specific edge to add.</param>
    internal void Add(Edge p_edge)
    {
      m_edges.Add(p_edge.Id, p_edge);
    }

    /// <summary>
    /// Removes the specified edge.
    /// </summary>
    /// <param name="p_edge">Specific edge to remove.</param>
    internal void Delete(Edge p_edge)
    {
      m_edges.Remove(p_edge.Id);
    }
  }
}
