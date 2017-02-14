using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YS.Training.Core.GraphModel.GraphXmlSchema;

namespace YS.Training.Core.GraphModel
{
  public class GraphSerializer
  {
    public GraphSerializer()
    {

    }

    public void Serialize(Graph p_graph, string p_graphInformationFile)
    {
      throw new NotImplementedException("Todo ...");
    }

    public Graph Deserialize(string p_graphInformationFile)
    {
      Graph rv = null;
      GraphInformation gInfo = null;

      if (string.IsNullOrEmpty(p_graphInformationFile))
      {
        throw new ArgumentException("Graph information file path can not be null or empty", "p_graphInformationFile");
      }
      else if (!File.Exists(p_graphInformationFile))
      {
        throw new FileNotFoundException("Graph information file " +
                                        p_graphInformationFile + 
                                        " does not exist");
      }

      XmlSerializer serializer = new XmlSerializer(typeof(GraphInformation));
      using (StreamReader reader = new StreamReader(p_graphInformationFile))
      {
        gInfo = (GraphInformation)serializer.Deserialize(reader);
      }

      rv = new Graph();

      rv.Name = gInfo.Name;
      rv.Description = gInfo.Description;

      CreateVertices(rv, gInfo);
      RouteEdges(rv, gInfo);
      LoadApproximationsTable(rv, gInfo);

      return rv;
    }

    private void CreateVertices(Graph p_graph, GraphInformation p_graphInfo)
    {
      List<VertexItem> verticesInfo = null;
      int i = 0;
      VertexItem vi = null;

      verticesInfo = p_graphInfo.VertexCollection;
      for (i = 0; i < verticesInfo.Count; i++)
      {
        vi = verticesInfo[i];
        try
        {
          p_graph.AddVertex(vi.Name);
        }
        catch (ArgumentException)
        {
          throw new VertexInfoEmptyNameException(
                      string.Format(CultureInfo.InvariantCulture,
                                    "Vertex [#{0}] without name found",
                                    i+1));
        }
        catch (InvalidOperationException)
        {
          throw new VertexInfoDuplicationException(
                        string.Format(CultureInfo.InvariantCulture,
                        "Vertices with the same name found; {0}",vi.Name));
        }
      }
    }

    private void LoadApproximationsTable(Graph p_graph, GraphInformation p_graphInfo)
    {
      Approximations approxs = null;
      List<ApproximationItem> approximationsInfo = null;
      int i = 0;
      ApproximationItem ai = null;
      Vertex srcV = null;
      Vertex targetV = null;

      approxs = new Approximations();
      approximationsInfo = p_graphInfo.ApproximationCollection;

      for (i = 0; i < approximationsInfo.Count; i++)
      {
        ai = approximationsInfo[i];

        try
        {
          srcV = p_graph.Vertices[ai.Source] as Vertex;
          targetV = p_graph.Vertices[ai.Target] as Vertex;
        }
        catch (KeyNotFoundException)
        {
          throw new EdgeInfoEndNotExistsException(
                  string.Format(CultureInfo.InvariantCulture,
                                "Vertex for {0} ==> {1} approximation does not exist.",
                                ai.Source, ai.Target));
        }
        try
        {
          double approxVal = Convert.ToDouble(ai.aproximation);
          approxs.SetH(srcV, targetV, approxVal);
        }
        catch (FormatException)
        {
          throw new FormatException(
                 string.Format(CultureInfo.InvariantCulture,
                                "Approximation [{0}] value for edge {1} ==> {2} is not a number in a valid format.",
                                 ai.aproximation, ai.Source, ai.Target));
        }
      }

      p_graph.Approximations = approxs;
    }

    private void RouteEdges(Graph p_graph, GraphInformation p_graphInfo)
    {
      List<VertexItem> verticesInfo = null;
      int i = 0;
      VertexItem vi = null;
      Vertex srcV = null;
      Vertex targetV = null;
      List<EdgeItem> vEdgesInfo = null;
      int j = 0;
      double weight = 0;

      verticesInfo = p_graphInfo.VertexCollection;
      for (i = 0; i < verticesInfo.Count; i++)
      {
        vi = verticesInfo[i];
        srcV = p_graph.Vertices[vi.Name] as Vertex;

        vEdgesInfo = vi.EdgeCollection;
        for (j = 0; j < vEdgesInfo.Count; j++)
        {
          string targetName = vEdgesInfo[j].Target;
          try
          {
            targetV = string.IsNullOrEmpty(targetName) ? null : p_graph.Vertices[targetName] as Vertex;
            weight = Convert.ToDouble(vEdgesInfo[j].Weight);
            p_graph.AddEdge(srcV, targetV, weight);
          }
          catch (KeyNotFoundException)
          {
            throw new EdgeInfoEndNotExistsException(
                  string.Format(CultureInfo.InvariantCulture,
                                "Route edge from {0} failed, end vertex {1} does not exist.",
                                vi.Name, targetV));
          }
          catch (InvalidOperationException)
          {
            throw new EdgeInfoEndDuplicationException(
                   string.Format(CultureInfo.InvariantCulture,
                                 "Route edge from {0} failed, duplicate route to end vertex {1}.",
                                  vi.Name, targetName));
          }
          catch (FormatException)
          {
            throw new FormatException(
                   string.Format(CultureInfo.InvariantCulture,
                                  "Weight [{0}] data for edge {1} ==> {2} is not a number in a valid format.",
                                   vEdgesInfo[j].Weight, vi.Name, targetName));
          }
        }
      }
    }


  }
}
