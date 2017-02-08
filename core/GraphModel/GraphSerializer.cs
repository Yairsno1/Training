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

    }

    public Graph Deserialize(string p_graphInformationFile)
    {
      Graph rv = null;
      GraphInformation gInfo = null;
      List<VertexItem> verticesInfo = null;
      int i = 0;
      VertexItem vi = null;
      Vertex srcV = null;
      Vertex targetV = null;
      List<EdgeItem> vEdgesInfo = null;
      int j = 0;
      double weight = 0;
      Approximations approxs = null;
      List<ApproximationItem> approximationsInfo = null;
      ApproximationItem ai = null;

      if (string.IsNullOrEmpty(p_graphInformationFile))
      {
        throw new ArgumentException("p_graphInformationFile", "Graph information file path can not be null or empty");
      }
      else if (!File.Exists(p_graphInformationFile))
      {
        throw new FileNotFoundException("Graph information file " + p_graphInformationFile + " does not exist");
      }

      XmlSerializer serializer = new XmlSerializer(typeof(GraphInformation));
      using (StreamReader reader = new StreamReader(p_graphInformationFile))
      {
        gInfo = (GraphInformation)serializer.Deserialize(reader);
      }

      rv = new Graph();

      rv.Name = gInfo.Name;
      rv.Description = gInfo.Description;

      verticesInfo = gInfo.VertexCollection;
      try
      {
        for (i = 0; i < verticesInfo.Count; i++)
        {
          vi = verticesInfo[i];
          rv.AddVertex(vi.Name);
        }
      }
      catch (ArgumentException)
      {
        throw new VertexInfoEmptyNameException(string.Format(CultureInfo.InvariantCulture,"Vertex without name found"));
      }
      catch (InvalidOperationException)
      {
        throw new VertexInfoDuplicationException(string.Format(CultureInfo.InvariantCulture, "Vertices with the sane name found"));
      }
      catch 
      {
        throw;
      }

      for (i = 0; i < verticesInfo.Count; i++)
      {
        vi = verticesInfo[i];
        srcV = rv.Vertices[vi.Name] as Vertex;

        vEdgesInfo = vi.EdgeCollection;
        for (j=0; j<vEdgesInfo.Count; j++)
        {
          targetV = rv.Vertices[vEdgesInfo[j].Target] as Vertex;
          weight = Convert.ToDouble(vEdgesInfo[j].Weight);
          rv.AddEdge(srcV, targetV, weight);
        }
      }

      approxs = new Approximations();
      approximationsInfo = gInfo.ApproximationCollection;
      for (i = 0; i < approximationsInfo.Count; i++)
      {
        ai = approximationsInfo[i];

        srcV = rv.Vertices[ai.Source] as Vertex;
        targetV = rv.Vertices[ai.Target] as Vertex;
        double approxVal = Convert.ToDouble(ai.aproximation);
        approxs.SetH(srcV, targetV, approxVal);
      }
      rv.Approximations = approxs;

      return rv;
    }

  }
}
