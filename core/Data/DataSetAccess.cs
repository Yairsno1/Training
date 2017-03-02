using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.Data;

namespace YS.Training.Core.Data
{
  public abstract class DataSetAccess : IDataSetAccess
  {
    private string m_database;
    private bool m_connected; 

    protected DataSetAccess()
    {
      m_database = string.Empty;
      m_connected = false;
    }

       #region IDataSetAccess
    public abstract void CloseConnection();

    public virtual string DataBase
    {
      get
      {
        return m_database;
      }
      set
      {
        m_database = value;
      }
    }

    public abstract void OpenConnection();

    public abstract IReadOnlyRecords SelectAll(string p_sourceName);
      #endregion

    protected bool IsConnected
    {
      get
      {
        return m_connected;
      }
      set
      {
        m_connected = value;
      }
    }
  }
}
