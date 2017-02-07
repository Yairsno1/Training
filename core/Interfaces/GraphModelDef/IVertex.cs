using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  public interface IVertex
  {
    string Name { get; }
    IEdges OutEdges { get; }
  }
}
