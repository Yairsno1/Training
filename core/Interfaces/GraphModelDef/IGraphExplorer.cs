using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  /// <summary>
  /// Define methods to explore a graph.
  /// </summary>
  public interface IGraphExplorer
  {
    /// <summary>
    /// Gets the explored graph.
    /// </summary>
    IGraph Graph { get; }

    /// <summary>
    /// Finds an efficiently directed path between specified start and destination(goal) vertices.
    /// </summary>
    /// <param name="start">The specific start of the search.</param>
    /// <param name="destination">The search destination.</param>
    /// <returns>The directed path between the specified start and destination, null if no such path exists.</returns>
    /// <remarks>
    /// <exception cref="ArgumentNullException">Start or destination is null.</exception>
    /// The A* search algorithm is known due its performance and accuracy.
    /// <para>
    /// https://en.wikipedia.org/wiki/A*_search_algorithm
    /// </para>
    /// </remarks>
    IPath AStar(IVertex start, IVertex destination);
  }
}
