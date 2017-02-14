using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  /// <summary>
  /// Defines directed edge that connects two graph vertices.
  /// </summary>
  /// <remarks>
  /// This edge definition does not indicate mandatory vertices ends, 
  /// each side of the edge may or may not has vertex.
  /// <para>
  /// Implementations may override this behavior and force vertex onnection
  /// at both ends of the edge.
  /// </para>
  /// </remarks>
  public interface IEdge
  {
    /// <summary>
    /// Gets if the out end is connected to vertex.
    /// </summary>
    bool HasSourceVertex { get; }

    /// <summary>
    /// Gets if the in end is connected to vertex.
    /// </summary>
    bool HasTargetVertex { get; }

    /// <summary>
    /// Gets the edge id.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Gets the out end of the edge, null if does not exist.
    /// </summary>
    IVertex Source { get; }

    /// <summary>
    /// Gets the in end of the edge, null if does not exist.
    /// </summary>
    IVertex Target { get; }

    /// <summary>
    /// Gets or sets the weight of the edge.
    /// </summary>
    double Weight { get; set; }    
  }
}
