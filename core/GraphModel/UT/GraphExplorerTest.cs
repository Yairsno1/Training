using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YS.Training.Core.GraphModel;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace UT
{
  /// <summary>
  /// Summary description for GraphExplorerTest
  /// </summary>
  [TestClass]
  public class GraphExplorerTest
  {
    private static Graph m_graph = null;

    public GraphExplorerTest()
    {
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
     [ClassInitialize()]
     public static void MyClassInitialize(TestContext testContext)
     {
       GraphSerializer gSrz = null;

       gSrz = new GraphSerializer();
       m_graph = gSrz.Deserialize(@"c:\temp\training\car_graph.xml");
     }

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
     public void Test_AStar_NoPath()
     {
       GraphExplorer gExplorer = null;
       IPath searchResult = null;
       IVertex start = null;
       IVertex destination = null;

       start = m_graph.Vertices["Shlomzion-Wizo"];
       destination = m_graph.Vertices["Khoogim"];

       gExplorer = new GraphExplorer(m_graph);
       searchResult = gExplorer.AStar(start, destination);

       Assert.IsNull(searchResult);
     }

    [TestMethod]
    public void Test_AStar_StartIsTheGoal()
    {
      GraphExplorer gExplorer = null;
      IPath searchResult = null;
      IVertex start = null;
      IVertex destination = null;

      start = m_graph.Vertices["Hana 40"];
      destination = m_graph.Vertices["Hana 40"];

      gExplorer = new GraphExplorer(m_graph);
      searchResult = gExplorer.AStar(start, destination);

      Assert.AreEqual("Hana 40", searchResult.StartVertex.Name);
      Assert.IsNull(searchResult.NextVertex(start));
    }

    [TestMethod]
    public void Test_AStar_Boorekas()
    {
      GraphExplorer gExplorer = null;
      IPath searchResult = null;
      IVertex start = null;
      IVertex destination = null;

      start = m_graph.Vertices["Hana 40"];
      destination = m_graph.Vertices["Z. Carmelia"];

      gExplorer = new GraphExplorer(m_graph);
      searchResult = gExplorer.AStar(start, destination);

      Assert.AreEqual("Rachel 2", searchResult.NextVertex(m_graph.Vertices["Rachel Fork"]).Name);
    }

    [TestMethod]
    public void Test_AStar_TakeShohamToSchool()
    {
      GraphExplorer gExplorer = null;
      IPath searchResult = null;
      IVertex start = null;
      IVertex destination = null;

      start = m_graph.Vertices["Hana 40"];
      destination = m_graph.Vertices["Khoogim"];

      gExplorer = new GraphExplorer(m_graph);
      searchResult = gExplorer.AStar(start, destination);

      Assert.AreEqual("Hana 29", searchResult.NextVertex(m_graph.Vertices["Hana 40"]).Name);
    }

  }
}
