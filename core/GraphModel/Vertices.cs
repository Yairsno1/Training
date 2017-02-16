using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  /// <summary>
  /// Represents collection of vertices.
  /// </summary>
  internal class Vertices : IVertices
  {
    private Dictionary<string, Vertex> m_vertices; //Access vertex by name.

    /// <summary>
    /// Initializes Vertices instance.
    /// </summary>
    public Vertices()
    {
      m_vertices = new Dictionary<string, Vertex>();
    }


       #region IVertices implementation
    /// <summary>
    /// Gets the number of vertices in the collection.
    /// </summary>
    public int Count
    {
      get
      {
        return m_vertices.Count;
      }
    }

    /// <summary>
    /// Gets the vertex with the specified name.
    /// </summary>
    /// <param name="p_vertexName">The name of the vertex to get.</param>
    /// <returns>The vertex with the specified name.</returns>
    /// <exception cref="ArgumentException">The name is empty or null.</exception>
    /// <exception cref="KeyNotFoundException">The specified name was not found.</exception>
    public IVertex this[string p_vertexName]
    {
      get
      {
        return m_vertices[p_vertexName];
      }
    }

    public IEnumerator<IVertex> GetEnumerator()
    {
      return m_vertices.Values.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return m_vertices.Values.GetEnumerator();
    }
      #endregion

    /// <summary>
    /// Adds vertex.
    /// </summary>
    /// <param name="p_vertex">The vertex to add.</param>
    ///  <exception cref="InvalidOperationException">Vertex with the same name already exists.</exception>
    internal void Add(Vertex p_vertex)
    {
      string name = string.Empty;

      name = p_vertex.Name;
      if (m_vertices.ContainsKey(name))
      {
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Vertex {0} already exists", name));
      }

      m_vertices.Add(name, p_vertex);
    }

    /// <summary>
    /// Removes vertex.
    /// </summary>
    /// <param name="p_vertex">The vertex to remove.</param>
    internal void Delete(Vertex p_vertex)
    {
      m_vertices.Remove(p_vertex.Name);
    }
  }
}
