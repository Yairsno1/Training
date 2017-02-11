using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YS.Training.Core.GraphModel;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace UT
{
  /// <summary>
  /// Summary description for GraphSerializerTest
  /// </summary>
  [TestClass]
  public class GraphSerializerTest
  {
    private const string GRAPH_INFO_FILE = @"c:\temp\training\car_graph.xml";

    public GraphSerializerTest()
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
    public void Test_Deserialize()
    {
      GraphSerializer gSrz = null;
      Graph g = null;

      gSrz = new GraphSerializer();
      g = gSrz.Deserialize(GRAPH_INFO_FILE);

      Assert.AreEqual("Carmelia area roadmap as graph model", g.Description);
    }

    [TestMethod]
    public void Test_Deserialize_VertexCount()
    {
      Graph g = null;

      g = LoadGraphFromInfoFile();

      Assert.AreEqual(30, g.Vertices.Count);
    }

    [TestMethod]
    public void Test_Deserialize_EdgeCount()
    {
      Graph g = null;
      IVertex mega = null;

      g = LoadGraphFromInfoFile();

      mega = g.Vertices["Mega"];

      Assert.AreEqual(4, mega.OutEdges.Count);
    }

    [TestMethod]
    public void Test_Deserialize_Weight()
    {
      Graph g = null;
      IVertex rachel = null;
      IEdge rachel2mega = null;

      g = LoadGraphFromInfoFile();

      rachel = g.Vertices["Rachel"];
      foreach (IEdge e in rachel.OutEdges)
      {
        if (e.Target.Name.Equals("Mega"))
        {
          rachel2mega = e;
          break;
        }
      }

      Assert.AreEqual(50,rachel2mega.Weight);
    }

    [TestMethod]
    public void Test_Deserialize_ApproximationHueristic()
    {
      Graph g = null;
      IVertex hana40 = null;
      IVertex khoogim = null;

      g = LoadGraphFromInfoFile();

      hana40 = g.Vertices["Hana 40"];
      khoogim = g.Vertices["Khoogim"];

      Assert.AreEqual(1850, g.Approximations.GetH(hana40, khoogim));
    }

    private Graph LoadGraphFromInfoFile()
    {
      GraphSerializer gSrz = null;
      Graph g = null;

      gSrz = new GraphSerializer();
      g = gSrz.Deserialize(GRAPH_INFO_FILE);

      return g;
    }
  }
}
