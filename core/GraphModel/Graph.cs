using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  /// <summary>
  /// Represents graph model of vertices and directed edges.
  /// </summary>
  /// <remarks>
  /// The graph may contain edges that are not connected at both ends.
  /// </remarks>
  public class Graph : IGraph
  {
    private Edges m_edges;
    private Vertices m_vertices;
    private string m_desc;
    private string m_name;
    private IApproximations m_approxs;

    /// <summary>
    /// Initializes Graph instance.
    /// </summary>
    public Graph()
    {
      m_edges = new Edges();
      m_vertices = new Vertices();
      m_name = string.Empty;
      m_desc = string.Empty;
      m_approxs = new Approximations();
    }


       #region IGraph implementation

    /// <summary>
    /// Creates and adds edge with the specified out end vertex, the specified in end vertex and specified weight(cost).
    /// </summary>
    /// <param name="p_source">The specific out end vertex, can be null.</param>
    /// <param name="p_target">The specific in end vertex, can be null.</param>
    /// <param name="p_weight">The specific weight of the edge.</param>
    /// <returns>The created edge.</returns>
    /// <exception cref="InvalidOperationException">Vertices are not null and such edge exists.</exception>
    /// <remarks>
    /// This method helps us to create a graph that can contain edegs
    /// which are not connected to vertex at both ends.
    /// </remarks>
    public IEdge AddEdge(IVertex p_source, IVertex p_target, double p_weight)
    {
      Edge rv = null;
      Vertex srcVertex = null;

      srcVertex = (Vertex)p_source;

      rv = new Edge(srcVertex, (Vertex)p_target);
      if (null != p_source)
      {
        srcVertex.AddOutEdge(rv);
      }
      rv.Weight = p_weight;
      m_edges.Add(rv);

      return rv;
    }

    /// <summary>
    /// Creates and adds edge with the specified out end vertex, the specified in end vertex and no weight(cost).
    /// </summary>
    /// <param name="p_source">The specific out end vertex, can be null.</param>
    /// <param name="p_target">The specific in end vertex, can be null.</param>
    /// <returns>The created edge.</returns>
    /// <exception cref="InvalidOperationException">Vertices are not null and such edge exists.</exception>
    /// <remarks>
    /// This method helps us to create a graph that can contain edegs
    /// which are not connected to vertex at both ends.
    /// </remarks>
    public IEdge AddEdge(IVertex p_source, IVertex p_target)
    {
      return AddEdge(p_source, p_target, 0);
    }

    /// <summary>
    /// Creates and adds vertex with the specified name.
    /// </summary>
    /// <param name=p_"vertexName">The specific name.</param>
    /// <returns>The created vertex.</returns>
    /// <exception cref="ArgumentException">Name is null or empty.</exception>
    /// <exception cref="InvalidOperationException">Vertex with the same exists.</exception>
    public IVertex AddVertex(string p_vertexName)
    {
      Vertex rv = null;

      if (string.IsNullOrEmpty(p_vertexName))
      {
        throw new ArgumentException("Vertex name can not be null or empty", "p_vertexName");
      }

      rv = new Vertex(p_vertexName);
      m_vertices.Add(rv);

      return rv;
    }

    /// <summary>
    /// Gets or sets the approximations hueristics among the vertices.
    /// </summary>
    public IApproximations Approximations
    {
      get
      {
        return m_approxs;
      }
      set
      {
        m_approxs = value;
      }
    }

    /// <summary>
    /// Delete the specified edge.
    /// </summary>
    /// <param name="p_edge">The specific edge to delete.</param>
    /// <exception cref="ArgumentNullException">Edge is null.</exception>
    public void DeleteEdge(IEdge p_edge)
    {
      Edge edge2Del = null;

      if (null == p_edge)
      {
        throw new ArgumentNullException("p_edge", "Edge can not be null");
      }

      edge2Del = (Edge)p_edge;

      if (p_edge.HasSourceVertex)
      {
        ((p_edge.Source as Vertex).OutEdges as Edges).Delete(edge2Del);
      }
      (m_edges as Edges).Delete(edge2Del);
    }

    /// <summary>
    /// Delete the specified vertex.
    /// </summary>
    /// <param name="p_vertex">The specific vertex to delete.</param>
    /// <exception cref="ArgumentNullException">Vertex is null.</exception>
    public void DeleteVertex(IVertex p_vertex)
    {
      if (null == p_vertex)
      {
        throw new ArgumentNullException("p_vertex", "Vertex can not be null");
      }

      m_vertices.Delete((Vertex)p_vertex);
    }

    /// <summary>
    /// Gets or sets the graph's description.
    /// </summary>
    public string Description
    {
      get
      {
        return m_desc;
      }
      set
      {
        m_desc = value;
      }
    }

    /// <summary>
    /// Gets the list of edges.
    /// </summary>
    /// <remarks>
    /// This property helps us to create a graph that can contain edegs
    /// which are not connected to vertex at both ends.
    /// </remarks>
    public IEdges Edges
    {
      get 
      {
        return m_edges;
      }
    }

    /// <summary>
    /// Gets or sets the graph's name.
    /// </summary>
    public string Name
    {
      get
      {
        return m_name;
      }
      set
      {
        m_name = value;
      }
    }

    /// <summary>
    /// Gets the list of vertices.
    /// </summary>
    public IVertices Vertices
    {
      get
      {
        return m_vertices;
      }
    }
      #endregion

  }
}
