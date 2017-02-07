using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingr.SPPE.BusinessServices.BusinessObject.SPPEMapping.SchemaProII
{
  public class UOMObject
  {
    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("MappedTo")]
    public string MappedTo { get; set; }
  }
}
