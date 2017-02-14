using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  /// <summary>
  /// Defines methods to get approximation hueristic between two vertices of a graph.
  /// </summary>
  public interface IApproximations
  {
    /// <summary>
    /// Gets approximation hueristic between two vertices.
    /// </summary>
    /// <param name="source">Source(from) vertex.</param>
    /// <param name="target">Target(to) vertex</param>
    /// <returns>The approximation hueristic between the source and target vertices, 0 if such hueristic does not exist.</returns>
    double GetH(IVertex source, IVertex target);
  }
}
