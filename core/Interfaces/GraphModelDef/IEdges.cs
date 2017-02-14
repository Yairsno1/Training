using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  /// <summary>
  /// Defines collection of edges.
  /// </summary>
  public interface IEdges : IEnumerable<IEdge>, IEnumerable
  {
    /// <summary>
    /// Gets the number of edges in the collection.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Gets the edge with the specified id.
    /// </summary>
    /// <param name="edgeId">The id of the edge to get.</param>
    /// <returns>The edge with the specified id.</returns>
    /// <exception cref="ArgumentException">The id is empty or null.</exception>
    /// <exception cref="KeyNotFoundException">The id was not found.</exception>
    IEdge this[string edgeId] { get; }
  }
}
