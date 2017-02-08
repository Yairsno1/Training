using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YS.Training.Core.GraphModel.GraphXmlSchema
{
  [XmlRoot("Graph")]
  public class GraphInformation
  {
    [XmlAttribute("Name")]
    public string Name { set; get; }

    [XmlAttribute("Description")]
    public string Description { set; get; }

    [XmlArray("Vertices")]
    [XmlArrayItem("Vertex")]
    public List<VertexItem> VertexCollection { get; set; }

    [XmlArray("Approximations")]
    [XmlArrayItem("Approximation")]
    public List<ApproximationItem> ApproximationCollection { get; set; }

  }
}
