using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.GraphModelDef
{
  public interface IGraphExplorer
  {
    IGraph Graph { get; }

    IPath AStar(IVertex start, IVertex destination);
  }
}
