using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  /// <summary>
  /// Defines graph vertex(node).
  /// </summary>
  public interface IVertex
  {
    /// <summary>
    /// Gets the vertex name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the list of edges that route off the vertex.
    /// </summary>
    IEdges OutEdges { get; }
  }
}
