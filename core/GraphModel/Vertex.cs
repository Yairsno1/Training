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
  /// Represents graph vertex(node).
  /// </summary>
  internal class Vertex : IVertex
  {
    private string m_name;
    private Edges m_outEdges; //The edges that routed off the vertex.

    /// <summary>
    /// Initializes Vertex instance with the specified name.
    /// </summary>
    /// <param name="p_name">The name of the vertex.</param>
    public Vertex(string p_name)
    {
      m_name = p_name;
      m_outEdges = new Edges();
    }

       #region IVertex implementation
    /// <summary>
    /// Gets the vertex name.
    /// </summary>
    public string Name
    {
      get
      {
        return m_name;
      }
    }

    /// <summary>
    /// Gets the list of edges that route off the vertex.
    /// </summary>
    public IEdges OutEdges
    {
      get
      {
        return m_outEdges;
      }
    }
      #endregion

    /// <summary>
    /// Route an edge from the vertex.
    /// </summary>
    /// <param name="p_outEdge">The edge to route.</param>
    /// <exception cref="InvalidOperationException">
    /// The edge is routed to non-null vertex which already has in-edge from this vertex.
    /// </exception>
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
