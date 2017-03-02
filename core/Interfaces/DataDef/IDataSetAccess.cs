using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Interfaces.Data
{
  public interface IDataSetAccess
  {
    string DataBase { get; set; }

    void CloseConnection();
    void OpenConnection();
    IReadOnlyRecords SelectAll(string sourceName);
  }
}
