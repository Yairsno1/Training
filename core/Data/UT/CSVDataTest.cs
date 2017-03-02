using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YS.Training.Core.Data.CSVClient;
using YS.Training.Core.Interfaces.Data;

namespace UT
{
  /// <summary>
  /// Summary description for CSVDataTest
  /// </summary>
  [TestClass]
  public class CSVDataTest
  {
    private const string DATABASE_DIR = @"c:\temp\training";
    private const string TA35_INDEX_SOURCE = @"book3";

    public CSVDataTest()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    //
    // You can use the following additional attributes as you write your tests:
    //
    // Use ClassInitialize to run code before running the first test in the class
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    [TestMethod]
    public void Test_Database()
    {
      CSVData csvConnect = null;

      csvConnect = new CSVData();
      csvConnect.DataBase = DATABASE_DIR;

      Assert.AreEqual(DATABASE_DIR + @"\", csvConnect.DataBase);
    }

    [TestMethod]
    public void Test_RecordCount()
    {
      CSVData csvConnect = null;
      IReadOnlyRecords bars = null;

      csvConnect = new CSVData();
      csvConnect.DataBase = DATABASE_DIR;
      try
      {
        csvConnect.OpenConnection();
        bars = csvConnect.SelectAll(TA35_INDEX_SOURCE);
      }
      finally
      {
        csvConnect.CloseConnection();
      }

      Assert.AreEqual(4089, bars.Count);
    }

    [TestMethod]
    public void Test_FieldValue()
    {
      CSVData csvConnect = null;
      IReadOnlyRecords bars = null;

      csvConnect = new CSVData();
      csvConnect.DataBase = DATABASE_DIR;
      try
      {
        csvConnect.OpenConnection();
        bars = csvConnect.SelectAll(TA35_INDEX_SOURCE);
      }
      finally
      {
        csvConnect.CloseConnection();
      }

      Assert.AreEqual(1427.35, Convert.ToDouble(bars[bars.Count-1][1])); //Open price of TA35 index at 1/3/2017
    }

  }
}
