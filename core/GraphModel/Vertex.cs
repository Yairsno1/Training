using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  internal class Vertex : IVertex
  {
    private string m_name;
    private Edges m_outEdges;

    public Vertex(string p_name)
    {
      m_name = p_name;
      m_outEdges = new Edges();
    }

       #region IVertex implementation
    public string Name
    {
      get
      {
        return m_name;
      }
    }

    public IEdges OutEdges
    {
      get
      {
        return m_outEdges;
      }
    }
      #endregion

    internal void AddOutEdge(Edge p_outEdge)
    {
      if (p_outEdge.HasTargetVertex)
      {
        foreach (IEdge e in m_outEdges)
        {
          if (e.HasTargetVertex)
          {
            if (e.Target.Name.Equals(p_outEdge.Target.Name))
            {
              throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                                     "Edge from vertex {0} to vertex {1} already exists",
                                                     this.Name, p_outEdge.Target.Name));
            }
          }
        }
      }

      m_outEdges.Add(p_outEdge);
    }
  }
}
