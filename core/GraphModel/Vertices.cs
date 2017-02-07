using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  internal class Vertices : IVertices
  {
    private Dictionary<string, Vertex> m_vertices;

    public Vertices()
    {
      m_vertices = new Dictionary<string, Vertex>();
    }


       #region IVertices implementation
    public int Count
    {
      get
      {
        return m_vertices.Count;
      }
    }

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

    internal void Delete(Vertex p_vertex)
    {
      m_vertices.Remove(p_vertex.Name);
    }
  }
}
