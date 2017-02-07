using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingr.SPPE.BusinessServices.BusinessObject.SPPEMapping.SchemaProII
{
  public class ObjectClass
  {
    [XmlAttribute("Name")]
    public string Name { get; set; }
    [XmlElement("Source")]
    public SourceObjectClass Source { get; set; }
    [XmlElement("Target")]
    public TargetObjectClass Target { get; set; }
    [XmlArray("Attributes")]
    [XmlArrayItem("Attribute")]
    public List<ObjectClassAttribute> Attributes { get; set; }
  }
}
