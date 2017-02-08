using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  internal class Edge : IEdge
  {
    private Vertex m_source;
    private Vertex m_target;
    private double m_weight;
    private string m_id;

    public Edge(Vertex p_source, Vertex p_target)
    {
      m_id = Guid.NewGuid().ToString("N").ToUpper(CultureInfo.InvariantCulture);
      m_source = p_source;
      m_target = p_target;
      m_weight = 0;

    }

       #region IEdge implementation
    public bool HasSourceVertex
    {
      get
      {
        return m_source != null;
      }
    }

    public bool HasTargetVertex
    {
      get 
      {
        return m_target != null;
      }
    }

    public string Id
    {
      get
      {
        return m_id;
      }
    }

    public IVertex Source
    {
      get
      {
        return m_source;
      }
    }

    public IVertex Target
    {
      get
      {
        return m_target;
      }
    }

    public double Weight
    {
      get
      {
        return m_weight;
      }
      set
      {
        m_weight = value;
      }
    }
      #endregion

  }
}
