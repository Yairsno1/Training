using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  public interface IPath
  {    
    IVertex EndVertex { get; }
    IVertex StartVertex { get; }
    double Weight { get; }

    void Append(IVertex vertex);
    IVertex NextVertex(IVertex sourceVertex);
  }
}
