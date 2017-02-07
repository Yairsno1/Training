using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingr.SPPE.BusinessServices.BusinessObject.SPPEMapping.SchemaProII
{
  public class ObjectClassAttributeValue
  {
    [XmlAttribute("Value")]
    public string Value { get; set; }
  }
}
