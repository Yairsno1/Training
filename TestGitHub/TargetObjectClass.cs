using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingr.SPPE.BusinessServices.BusinessObject.SPPEMapping.SchemaProII
{
  public class TargetObjectClass
  {
    [XmlAttribute("SPPEItemType")]
    public string SPPEItemType { get; set; }

    [XmlAttribute("SPPEClass")]
    public string SPPEClass { get; set; }

    [XmlAttribute("SPPESubClass")]
    public string SPPESubClass { get; set; }

    [XmlAttribute("SPPEType")]
    public string SPPEType { get; set; }

    [XmlAttribute("SymbolPath")]
    public string SymbolPath { get; set; }
  }
}
