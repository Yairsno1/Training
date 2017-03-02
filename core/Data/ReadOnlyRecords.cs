using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.Data;

namespace YS.Training.Core.Data
{
  internal class ReadOnlyRecords : IReadOnlyRecords
  {
    private List<ReadOnlyRecord> m_records;

    public ReadOnlyRecords()
    {
      m_records = new List<ReadOnlyRecord>();
    }

       #region IReadOnlyRecords
    public int ColumnCount
    {
      get
      {
        return 0 == m_records.Count ? 0 : m_records[0].ColumnCount;
      }
    }

    public int Count
    {
      get
      {
        return m_records.Count;
      }
    }

    public IReadOnlyRecord this[int p_index]
    {
      get
      {
        return m_records[p_index];
      }
    }

    public IEnumerator<IReadOnlyRecord> GetEnumerator()
    {
      return m_records.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return m_records.GetEnumerator();
    }
       #endregion

    internal void Add(object[] p_record)
    {
      m_records.Add(new ReadOnlyRecord(p_record));
    }
  }
}
