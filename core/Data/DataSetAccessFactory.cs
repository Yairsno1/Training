using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Data.CSVClient;
using YS.Training.Core.Interfaces.Data;

namespace YS.Training.Core.Data
{
  public enum DataSetProvider
  {
    CSV,
  }

  public static class DataSetAccessFactory
  {
    public static IDataSetAccess CreateDataSetAccess(DataSetProvider p_providerType)
    {
      IDataSetAccess rv = null;

      if (p_providerType == DataSetProvider.CSV)
      {
        rv = new CSVData();
      }

      return rv;
    }
  }
}
