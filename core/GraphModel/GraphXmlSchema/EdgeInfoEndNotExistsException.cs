using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.GraphModel.GraphXmlSchema
{
  [Serializable]
  public class EdgeInfoEndNotExistsException : Exception
  {
    public EdgeInfoEndNotExistsException() : base()
    {
    }

    public EdgeInfoEndNotExistsException(string p_message) : base(p_message)
    {
    }

    public EdgeInfoEndNotExistsException(string p_message, Exception p_innerException) : 
         base (p_message, p_innerException)
    {
    }

    protected EdgeInfoEndNotExistsException(SerializationInfo p_info, StreamingContext p_context) :
      base(p_info, p_context)
    {
    }
  }
}
