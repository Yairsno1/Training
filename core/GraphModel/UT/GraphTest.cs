using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YS.Training.Core.Interfaces.GraphModelDef;
using YS.Training.Core.GraphModel;

namespace UT
{
  [TestClass]
  public class GraphTest
  {
    [TestMethod]
    public void Test_New_EmptyGraph()
    {
      Graph g = null;

      g = new Graph();

      Assert.AreEqual(0, g.Vertices.Count);
      Assert.AreEqual(0, g.Edges.Count);
    }

    [TestMethod]
    public void Test_AddVertex_Single()
    {
      Graph g = null;
      IVertex v = null;

      g = new Graph();
      v = g.AddVertex("V1");

      Assert.AreEqual(1, g.Vertices.Count);
      Assert.AreEqual("V1", v.Name);
      Assert.AreEqual(0, g.Vertices["V1"].OutEdges.Count);
    }

    [TestMethod]
    public void Test_AddVertex_Multiple()
    {
      Graph g = null;
      IVertex v1 = null;
      IVertex v2 = null;
      IVertex v3 = null;

      g = new Graph();
      v1 = g.AddVertex("V1");
      v2 = g.AddVertex("V2");
      v3 = g.AddVertex("V3");

      Assert.AreEqual(3, g.Vertices.Count);
      Assert.AreEqual("V2", v2.Name);
      Assert.AreEqual(0, g.Vertices["V3"].OutEdges.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException), "InvalidOperationException exception wasn't thrown for duplicate vertices")]
    public void Test_AddVertex_Duplicate()
    {
      Graph g = null;
      IVertex v1 = null;
      IVertex v2 = null;
      IVertex v3 = null;

      g = new Graph();
      v1 = g.AddVertex("V1");
      v2 = g.AddVertex("V2");
      v3 = g.AddVertex("V1");
    }

    [TestMethod]
    public void Test_AddEdge_HangedInTheAir()
    {
      Graph g = null;
      IEdge e = null;

      g = new Graph();
      e = g.AddEdge(null, null);

      Assert.AreEqual(1, g.Edges.Count);
      Assert.IsFalse(e.HasSourceVertex);
      Assert.IsFalse(e.HasTargetVertex);
    }

    [TestMethod]
    public void Test_AddEdge_TargetOnly()
    {
      Graph g = null;
      IVertex v = null;
      IEdge e = null;

      g = new Graph();
      v = g.AddVertex("V1");
      e = g.AddEdge(null, v);

      Assert.AreEqual(1, g.Edges.Count);
      Assert.IsFalse(e.HasSourceVertex);
      Assert.IsTrue(e.HasTargetVertex);
      Assert.AreEqual(0, v.OutEdges.Count);
    }

    [TestMethod]
    public void Test_AddEdge_SourceOnly()
    {
      Graph g = null;
      IVertex v = null;
      IEdge e = null;

      g = new Graph();
      v = g.AddVertex("V1");
      e = g.AddEdge(v, null);

      Assert.AreEqual(1, g.Edges.Count);
      Assert.IsTrue(e.HasSourceVertex);
      Assert.IsFalse(e.HasTargetVertex);
      Assert.AreEqual(1, v.OutEdges.Count);
    }

    [TestMethod]
    public void Test_AddEdge_FromHere2There()
    {
      Graph g = null;
      IVertex v1 = null;
      IVertex v2 = null;
      IEdge e = null;

      g = new Graph();
      v1 = g.AddVertex("V1");
      v2 = g.AddVertex("V2");
      e = g.AddEdge(v1, v2);

      Assert.AreEqual(1, g.Edges.Count);
      Assert.IsTrue(e.HasSourceVertex);
      Assert.IsTrue(e.HasTargetVertex);
      Assert.AreEqual(1, v1.OutEdges.Count);
      Assert.AreEqual(0, v2.OutEdges.Count);
    }

    [TestMethod]
    public void Test_AddEdge_NotDirected()
    {
      Graph g = null;
      IVertex v1 = null;
      IVertex v2 = null;
      IEdge e1 = null;
      IEdge e2 = null;

      g = new Graph();
      v1 = g.AddVertex("V1");
      v2 = g.AddVertex("V2");
      e1 = g.AddEdge(v1, v2);
      e2 = g.AddEdge(v2, v1);

      Assert.AreEqual(2, g.Edges.Count);
      Assert.AreEqual(1, v1.OutEdges.Count);
      Assert.AreEqual(1, v2.OutEdges.Count);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException), "InvalidOperationException exception wasn't thrown for duplicate edges")]
    public void Test_AddEdge_DoubleEdge()
    {
      Graph g = null;
      IVertex v1 = null;
      IVertex v2 = null;
      IEdge e1 = null;
      IEdge e2 = null;

      g = new Graph();
      v1 = g.AddVertex("V1");
      v2 = g.AddVertex("V2");
      e1 = g.AddEdge(v1, v2);
      e2 = g.AddEdge(v1, v2);
    }

    [TestMethod]
    public void Test_TriangleGraph_EdgeCount()
    {
      Graph g = null;

      g = CreateTriangleG();

      Assert.AreEqual(4, g.Edges.Count);
      Assert.AreEqual(2, g.Vertices["V1"].OutEdges.Count);
      Assert.AreEqual(1, g.Vertices["V2"].OutEdges.Count);
      Assert.AreEqual(1, g.Vertices["V3"].OutEdges.Count);
    }

    [TestMethod]
    public void Test_TriangleGraph_V1toV2()
    {
      Graph g = null;
      IVertex v1 = null;
      IEdge eActual = null;

      g = CreateTriangleG();
      v1 = g.Vertices["V1"];
      foreach (IEdge e in v1.OutEdges)
      {
        if (e.Target.Name.Equals("V2"))
        {
          eActual = e;
          break;
        }
      }

      Assert.IsNotNull(eActual);
    }

    [TestMethod]
    public void Test_TriangleGraph_V1toV3()
    {
      Graph g = null;
      IVertex v1 = null;
      IEdge eActual = null;

      g = CreateTriangleG();
      v1 = g.Vertices["V1"];
      foreach (IEdge e in v1.OutEdges)
      {
        if (e.Target.Name.Equals("V3"))
        {
          eActual = e;
          break;
        }
      }

      Assert.IsNotNull(eActual);
    }

    [TestMethod]
    public void Test_TriangleGraph_V2toV1()
    {
      Graph g = null;
      IVertex v1 = null;
      IEdge eActual = null;

      g = CreateTriangleG();
      v1 = g.Vertices["V2"];
      foreach (IEdge e in v1.OutEdges)
      {
        if (e.Target.Name.Equals("V1"))
        {
          eActual = e;
          break;
        }
      }

      Assert.IsNotNull(eActual);
    }

    [TestMethod]
    public void Test_TriangleGraph_V3toV2()
    {
      Graph g = null;
      IVertex v1 = null;
      IEdge eActual = null;

      g = CreateTriangleG();
      v1 = g.Vertices["V3"];
      foreach (IEdge e in v1.OutEdges)
      {
        if (e.Target.Name.Equals("V2"))
        {
          eActual = e;
          break;
        }
      }

      Assert.IsNotNull(eActual);
    }

    private Graph CreateTriangleG()
    {
      Graph g = null;
      IVertex v1 = null;
      IVertex v2 = null;
      IVertex v3 = null;
      IEdge e11 = null;
      IEdge e13 = null;
      IEdge e21 = null;
      IEdge e32 = null;

      g = new Graph();

      v1 = g.AddVertex("V1");
      v2 = g.AddVertex("V2");
      v3 = g.AddVertex("V3");

      e11 = g.AddEdge(v1, v2);
      e21 = g.AddEdge(v2, v1);
      e13 = g.AddEdge(v1, v3);
      e32 = g.AddEdge(v3, v2);

      return g;
    }
  }
}
