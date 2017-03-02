using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.Data;

namespace YS.Training.Core.Data.CSVClient
{
  public class CSVData : DataSetAccess
  {
    private string M_CSV_FILE_EXTENSION = ".csv";
    private string M_CSV_FILE_DELIMITER = ",";

    private string m_dataFilesDir;

    public CSVData() : base()
    {
      m_dataFilesDir = string.Empty;
    }

       #region IDataSetAccess
    public override void CloseConnection()
    {
      if (this.IsConnected)
      {
        this.IsConnected = false;
      }
    }

    public override string DataBase
    {
      get
      {
        return base.DataBase;
      }
      set
      {
        if (!string.IsNullOrEmpty(value))
        {
          m_dataFilesDir = value.EndsWith(@"\") ? value : value + @"\";
          base.DataBase = m_dataFilesDir;
        }
      }
    }

    public override void OpenConnection()
    {
      if (string.IsNullOrEmpty(this.DataBase))
      {
        throw new ArgumentException("Database directory was not set", "DataBase");
      }
      else if (!Directory.Exists(this.DataBase))
      {
        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                                                              "The directory {0} for the csv files was not found",
                                                              this.DataBase));
      }

      this.IsConnected = true;
    }

    public override IReadOnlyRecords SelectAll(string p_sourceName)
    {
      ReadOnlyRecords rv = null;

      if (!this.IsConnected)
      {
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,"Connection is closed"));
      }
      else if (string.IsNullOrEmpty(p_sourceName))
      {
        throw new ArgumentException("CSV data file name can not be null or empty", "p_sourceName");
      }
      else if (!File.Exists(m_dataFilesDir + p_sourceName + M_CSV_FILE_EXTENSION))
      {
        throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture,
                                                              "The CSV data file {0} was not found",
                                                              p_sourceName));
      }

      rv = new ReadOnlyRecords();

      string fileName = string.Empty;
      StreamReader reader = null;
      try
      {
        fileName = m_dataFilesDir + p_sourceName + M_CSV_FILE_EXTENSION;
        reader = new StreamReader(fileName);
        string line = string.Empty;

        while ((line = reader.ReadLine()) != null)
        {
          string[] fields = Regex.Split(line, M_CSV_FILE_DELIMITER);
          rv.Add(fields);
        }
      }
      catch (Exception excp)
      {
        throw new ReadDataException(excp.Message, excp);
      }
      finally
      {
        if (null != reader)
        {
          reader.Close();
        }
      }

      return rv;
    }
       #endregion

  }
}
