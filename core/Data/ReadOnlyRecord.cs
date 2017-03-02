using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.Data;

namespace YS.Training.Core.Data
{
  internal class ReadOnlyRecord : IReadOnlyRecord
  {
    private object[] m_vals;

    public ReadOnlyRecord(object[] p_vals)
    {
      m_vals = p_vals;
    }

       #region IReadOnlyRecord
    public int ColumnCount
    {
      get
      {
        return m_vals.Length;
      }
    }

    public object this[int p_columnIndex]
    {
      get
      {
        return m_vals[p_columnIndex];
      }
    }
       #endregion

  }
}
