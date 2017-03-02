using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.Data
{
  public interface IReadOnlyRecord
  {
    int ColumnCount { get; }
    object this[int columnIndex] { get; }
  }
}
