using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  /// <summary>
  /// Define directed path between two graph vertices.
  /// </summary>
  public interface IPath
  {
    /// <summary>
    /// Gets path's end.
    /// </summary>
    IVertex EndVertex { get; }

    /// <summary>
    /// Gets if the path is empty.
    /// </summary>
    bool IsEmpty { get; }

    /// <summary>
    /// Gets path's start.
    /// </summary>
    IVertex StartVertex { get; }

    /// <summary>
    /// Gets total path weight.
    /// </summary>
    double Weight { get; }

    /// <summary>
    /// Gets the following vertex of the specified vertex.
    /// </summary>
    /// <param name="sourceVertex">The specific source vertex.</param>
    /// <returns>The vertex that follows the specified source vertex, null if source vertex is last in the parh.</returns>
    /// <exception cref="ArgumentNullException">Source vertex is null.</exception>
    /// <exception cref="InvalidOperationException">Source is not part of the path.</exception>
    IVertex NextVertex(IVertex sourceVertex);
  }
}
