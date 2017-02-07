using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  public interface IEdges : IEnumerable<IEdge>, IEnumerable
  {
    int Count { get; }
    IEdge this[string edgeId] { get; }
  }
}
