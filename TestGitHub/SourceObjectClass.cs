using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingr.SPPE.BusinessServices.BusinessObject.SPPEMapping.SchemaProII
{
  public class SourceObjectClass
  {
    [XmlAttribute("Class")]
    public string Class { get; set; }

    [XmlAttribute("SubClass")]
    public string SubClass { get; set; }

    [XmlAttribute("Type")]
    public string Type1 { get; set; }

    [XmlAttribute("Type2")]
    public string Type2 { get; set; }
  }
}
