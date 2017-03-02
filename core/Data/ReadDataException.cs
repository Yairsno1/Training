using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Data
{
  [Serializable]
  public class ReadDataException : Exception 
  {
    public ReadDataException() : base()
    {
    }

    public ReadDataException(string p_message) : base(p_message)
    {
    }

    public ReadDataException(string p_message, Exception p_innerException) : 
         base (p_message, p_innerException)
    {
    }

    protected ReadDataException(SerializationInfo p_info, StreamingContext p_context) :
      base(p_info, p_context)
    {
    }
  }
}
