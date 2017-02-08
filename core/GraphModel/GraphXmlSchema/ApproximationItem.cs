using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YS.Training.Core.GraphModel.GraphXmlSchema
{
  public class ApproximationItem
  {
    [XmlAttribute("From")]
    public string Source { set; get; }

    [XmlAttribute("To")]
    public string Target { set; get; }

    [XmlAttribute("H")]
    public string aproximation { set; get; }

  }
}
