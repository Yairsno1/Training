using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  public interface IVertices : IEnumerable<IVertex>, IEnumerable
  {
    int Count { get; }
    IVertex this[string vertexName] { get; }
  }
}
