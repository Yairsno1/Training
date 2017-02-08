using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  public interface IEdge
  {
    bool HasSourceVertex { get; }
    bool HasTargetVertex { get; }
    string Id { get; }
    IVertex Source { get; }
    IVertex Target { get; }
    double Weight { get; set; }    
  }
}
