using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YS.Training.Core.GraphModel.GraphXmlSchema
{
  public class EdgeItem
  {
    [XmlAttribute("To")]
    public string Target { set; get; }

    [XmlAttribute("Weight")]
    public string Weight { set; get; }
  }
}
