using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  /// <summary>
  /// Represents graph model of vertices and directed edges.
  /// </summary>
  /// <remarks>
  /// The graph may contain edges that are not connected on both ends.
  /// </remarks>
  public interface IGraph
  {
    string Description { get; set; }
    IEdges Edges { get; }
    string Name { get; set; }
    IVertices Vertices { get; }

    IEdge AddEdge(IVertex source, IVertex target);
    IEdge AddEdge(IVertex source, IVertex target, double weight);
    IEdge AddEdge(IVertex source, IVertex target, double weight, double proximity);
    IVertex AddVertex(string vertexName);
    void DeleteEdge(IEdge edge);
    void DeleteVertex(IVertex vertex);
  }
}
