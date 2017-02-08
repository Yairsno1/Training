using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YS.Training.Core.GraphModel.GraphXmlSchema
{
  public class VertexItem
  {
    [XmlAttribute("Name")]
    public string Name { set; get; }

    [XmlArray("Edges")]
    [XmlArrayItem("Edge")]
    public List<EdgeItem> EdgeCollection { get; set; }
  }
}
