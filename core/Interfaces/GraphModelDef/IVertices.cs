using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  /// <summary>
  /// Defines collection of vertices.
  /// </summary>
  public interface IVertices : IEnumerable<IVertex>, IEnumerable
  {
    /// <summary>
    /// Gets the number of vertices in the collection.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Gets the vertex with the specified name.
    /// </summary>
    /// <param name="vertexName">The name of the vertex to get.</param>
    /// <returns>The vertex with the specified name.</returns>
    /// <exception cref="ArgumentException">The name is empty or null.</exception>
    /// <exception cref="KeyNotFoundException">The specified name was not found.</exception>
    IVertex this[string vertexName] { get; }
  }
}
