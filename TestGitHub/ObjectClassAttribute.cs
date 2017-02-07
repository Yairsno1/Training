using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingr.SPPE.BusinessServices.BusinessObject.SPPEMapping.SchemaProII
{
  public class ObjectClassAttribute
  {
    [XmlElement("Target")]
    public ObjectClassAttributeName Target { get; set; }

    [XmlElement("Source")]
    public ObjectClassAttributeName Source { get; set; }

    [XmlElement("Domain")]
    public ObjectClassAttributeValue Domain { get; set; }

  }
}
