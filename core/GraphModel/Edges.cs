using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  internal class Edges : IEdges
  {
    private Dictionary<string, Edge> m_edges;

    public Edges()
    {
      m_edges = new Dictionary<string, Edge>();
    }


       #region IEdges implementation
    public int Count
    {
      get 
      {
        return m_edges.Count;
      }
    }

    public IEdge this[string p_edgeId]
    {
      get 
      {
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

    internal void Add(Edge p_edge)
    {
      m_edges.Add(p_edge.Id, p_edge);
    }

    internal void Delete(Edge p_edge)
    {
      m_edges.Remove(p_edge.Id);
    }
  }
}
