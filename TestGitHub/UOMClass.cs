using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingr.SPPE.BusinessServices.BusinessObject.SPPEMapping.SchemaProII
{
  public class UOMClass
  {
    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("MappedTo")]
    public string MappedTo { get; set; }

    [XmlAttribute("SP_ID")]
    public string ID { get; set; }

    [XmlArray("UOMObjects")]
    [XmlArrayItem("UOMObject")]
    public List<UOMObject> UOMObjectCollection { get; set; }

  }
}
