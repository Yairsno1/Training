using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  /// <summary>
  /// Definess graph model of vertices and directed edges.
  /// </summary>
  /// <remarks>
  /// The graph may contain edges that are not connected at both ends.
  /// <para>
  /// Implementations may override this behavior and force vertex onnection
  /// at both ends of each edge.
  /// </para>
  /// </remarks>
  public interface IGraph
  {
    /// <summary>
    /// Gets or sets the graph's description.
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// Gets the list of edges.
    /// </summary>
    /// <remarks>
    /// This property helps us to create a graph that can contain edegs
    /// which are not connected to vertex at both ends.
    /// </remarks>
    IEdges Edges { get; }

    /// <summary>
    /// Gets or sets the graph's name.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Gets the list of vertices.
    /// </summary>
    IVertices Vertices { get; }

    /// <summary>
    /// Gets or sets the approximations hueristics among the vertices.
    /// </summary>
    IApproximations Approximations { get; set; }

    /// <summary>
    /// Creates ans adds edge with the specified out end vertex, the specified in end vertex and no weight(cost).
    /// </summary>
    /// <param name="source">The specific out end vertex, can be null.</param>
    /// <param name="target">The specific in end vertex, can be null.</param>
    /// <returns>The created edge.</returns>
    /// <exception cref="InvalidOperationException">Vertices are not null and such edge exists.</exception>
    /// <remarks>
    /// This method helps us to create a graph that can contain edegs
    /// which are not connected to vertex at both ends.
    /// </remarks>
    IEdge AddEdge(IVertex source, IVertex target);

    /// <summary>
    /// Creates ans adds edge with the specified out end vertex, the specified in end vertex and specified weight(cost).
    /// </summary>
    /// <param name="source">The specific out end vertex, can be null.</param>
    /// <param name="target">The specific in end vertex, can be null.</param>
    /// <param name="weight">The specific weight of the edge.</param>
    /// <returns>The created edge.</returns>
    /// <exception cref="InvalidOperationException">Vertices are not null and such edge exists.</exception>
    /// <remarks>
    /// This method helps us to create a graph that can contain edegs
    /// which are not connected to vertex at both ends.
    /// </remarks>
    IEdge AddEdge(IVertex source, IVertex target, double weight);

    /// <summary>
    /// Creates and adds vertex with the specified name.
    /// </summary>
    /// <param name="vertexName">The specific name.</param>
    /// <returns>The created vertex.</returns>
    /// <exception cref="ArgumentException">Name is null or empty.</exception>
    /// <exception cref="InvalidOperationException">Vertex with the same exists.</exception>
    IVertex AddVertex(string vertexName);

    /// <summary>
    /// Delete the specified edge.
    /// </summary>
    /// <param name="edge">The specific edge to delete.</param>
    /// <exception cref="ArgumentNullException">Edge is null.</exception>
    void DeleteEdge(IEdge edge);

    /// <summary>
    /// Delete the specified vertex.
    /// </summary>
    /// <param name="vertex">The specific vertex to delete.</param>
    /// <exception cref="ArgumentNullException">Vertex is null.</exception>
    void DeleteVertex(IVertex vertex);
  }
}
