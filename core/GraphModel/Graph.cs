using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  public class Graph : IGraph
  {
    private Edges m_edges;
    private Vertices m_vertices;
    private string m_desc;
    private string m_name;

    public Graph()
    {
      m_edges = new Edges();
      m_vertices = new Vertices();
      m_name = string.Empty;
      m_desc = string.Empty;
    }


       #region IGraph implementation
    public IEdge AddEdge(IVertex p_source, IVertex p_target, double p_weight, double p_proximity)
    {
      Edge rv = null;
      Vertex srcVertex = null;

      srcVertex = (Vertex)p_source;

      rv = new Edge(srcVertex, (Vertex)p_target);
      if (null != p_source)
      {
        srcVertex.AddOutEdge(rv);
      }
      rv.Weight = p_weight;
      rv.Proximity = p_proximity;
      m_edges.Add(rv);

      return rv;
    }

    public IEdge AddEdge(IVertex p_source, IVertex p_target, double p_weight)
    {
      return AddEdge(p_source, p_target, p_weight, 0);
    }

    public IEdge AddEdge(IVertex p_source, IVertex p_target)
    {
      return AddEdge(p_source, p_target, 0, 0);
    }

    public IVertex AddVertex(string p_vertexName)
    {
      Vertex rv = null;

      if (string.IsNullOrEmpty(p_vertexName))
      {
        throw new ArgumentException("Vertex name can not be null or empty", "p_vertexName");
      }

      rv = new Vertex(p_vertexName);
      m_vertices.Add(rv);

      return rv;
    }

    public void DeleteEdge(IEdge p_edge)
    {
      Edge edge2Del = null;

      if (null == p_edge)
      {
        throw new ArgumentNullException("p_edge", "Edge can not be null");
      }

      edge2Del = (Edge)p_edge;

      if (p_edge.HasSourceVertex)
      {
        ((p_edge.Source as Vertex).OutEdges as Edges).Delete(edge2Del);
      }
      (m_edges as Edges).Delete(edge2Del);
    }

    public void DeleteVertex(IVertex p_vertex)
    {
      if (null == p_vertex)
      {
        throw new ArgumentNullException("p_vertex", "Vertex can not be null");
      }

      m_vertices.Delete((Vertex)p_vertex);
    }

    public string Description
    {
      get
      {
        return m_desc;
      }
      set
      {
        m_desc = value;
      }
    }

    public IEdges Edges
    {
      get 
      {
        return m_edges;
      }
    }

    public string Name
    {
      get
      {
        return m_name;
      }
      set
      {
        m_name = value;
      }
    }

    public IVertices Vertices
    {
      get
      {
        return m_vertices;
      }
    }
      #endregion

  }
}
