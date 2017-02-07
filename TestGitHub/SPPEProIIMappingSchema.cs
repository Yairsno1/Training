using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingr.SPPE.BusinessServices.BusinessObject.SPPEMapping.SchemaProII
{
  [XmlRoot("PROII")]
  public class SPPEProIIMappingSchema
  {
    [XmlArray("ObjectClasses")]
    [XmlArrayItem("ObjectClass")]
    public List<ObjectClass> ObjectClassCollection { get; set; }

    [XmlArray("UOMClasses")]
    [XmlArrayItem("UOMClass")]
    public List<UOMClass> UOMClassCollection { get; set; }
  }
}
