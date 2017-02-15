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
  /// Represents directed edge that connects two graph vertices.
  /// </summary>
  /// <remarks>
  /// Vertices ends are not mandatory, each side of the edge may or may not be connected to vertex,
  /// e.g. edge may be "hanged".
  /// </remarks>
  internal class Edge : IEdge
  {
    private Vertex m_source;
    private Vertex m_target;
    private double m_weight;
    private string m_id;

    /// <summary>
    /// Initializes Edge instance with the specified out and in connections.
    /// </summary>
    /// <param name="p_source">Start end vertex, send null if the edge should not be connected at its out end.</param>
    /// <param name="p_target">Target end vertex, send null if the edge should not be connected at its in end.</param>
    public Edge(Vertex p_source, Vertex p_target)
    {
      m_id = Guid.NewGuid().ToString("N").ToUpper(CultureInfo.InvariantCulture);
      m_source = p_source;
      m_target = p_target;
      m_weight = 0;

    }

       #region IEdge implementation
    /// <summary>
    /// Gets if the out end is connected to vertex.
    /// </summary>
    public bool HasSourceVertex
    {
      get
      {
        return m_source != null;
      }
    }

    /// <summary>
    /// Gets if the in end is connected to vertex.
    /// </summary>
    public bool HasTargetVertex
    {
      get 
      {
        return m_target != null;
      }
    }

    /// <summary>
    /// Gets the edge id.
    /// </summary>
    public string Id
    {
      get
      {
        return m_id;
      }
    }

    /// <summary>
    /// Gets the out end of the edge, null if does not exist.
    /// </summary>
    public IVertex Source
    {
      get
      {
        return m_source;
      }
    }

    /// <summary>
    /// Gets the in end of the edge, null if does not exist.
    /// </summary>
    public IVertex Target
    {
      get
      {
        return m_target;
      }
    }

    /// <summary>
    /// Gets or sets the weight of the edge.
    /// </summary>
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
