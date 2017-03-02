using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.Data
{
  public interface IReadOnlyRecords : IEnumerable<IReadOnlyRecord>, IEnumerable
  {
    int ColumnCount { get; }
    int Count { get; }

    IReadOnlyRecord this[int index] { get; }
  }
}
