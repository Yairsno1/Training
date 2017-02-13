using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YS.Training.Core.Collections;

namespace UT
{
  /// <summary>
  /// Summary description for MaxPriorityQueueTest
  /// </summary>
  [TestClass]
  public class MaxPriorityQueueTest
  {
    public MaxPriorityQueueTest()
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
    public void Test_Capacity_Default()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();

      Assert.AreEqual(64, q.Capacity);
    }

    [TestMethod]
    public void Test_Capacity_NegativeInput()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>(-4);

      Assert.AreEqual(64, q.Capacity);
    }

    [TestMethod]
    public void Test_Capacity()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>(10);

      Assert.AreEqual(10, q.Capacity);
    }

    [TestMethod]
    public void Test_Capacity_AutoResize()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>(3);
      q.Enqueue(1);
      q.Enqueue(2);
      q.Enqueue(3);
      q.Enqueue(4);

      Assert.AreEqual(6, q.Capacity);
    }

    [TestMethod]
    public void Test_Count_EmptyQ()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();

      Assert.AreEqual(0, q.Count);
    }

    [TestMethod]
    public void Test_Count()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();
      q.Enqueue(1);
      q.Enqueue(2);

      Assert.AreEqual(2, q.Count);
    }

    [TestMethod]
    public void Test_IsEmpty_EmptyQ()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();

      Assert.IsTrue(q.IsEmpty);
    }

    [TestMethod]
    public void Test_IsEmpty_FilledQ()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();
      q.Enqueue(1);
      q.Enqueue(2);

      Assert.IsFalse(q.IsEmpty);
    }

    [TestMethod]
    public void Test_Peek_EmptyQ()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();

      Assert.AreEqual(default(double), q.Peek());
    }

    [TestMethod]
    public void Test_Peek()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();
      q.Enqueue(1);

      Assert.AreEqual(1, q.Peek());
    }

    [TestMethod]
    public void Test_Enqueue()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();
      q.Enqueue(3);
      q.Enqueue(2);
      q.Enqueue(1);

      Assert.AreEqual(3, q.Peek());
    }

    [TestMethod]
    public void Test_Contains()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();
      q.Enqueue(3);
      q.Enqueue(2);
      q.Enqueue(1);

      Assert.IsTrue(q.Contains(2));
    }

    [TestMethod]
    public void Test_Contains_Not()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();
      q.Enqueue(3);
      q.Enqueue(2);
      q.Enqueue(1);

      Assert.IsFalse(q.Contains(4));
    }

    [TestMethod]
    public void Test_Dequeue_EmptyQ()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();

      Assert.AreEqual(default(double), q.Dequeue());
    }

    [TestMethod]
    public void Test_Dequeue()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();
      q.Enqueue(1);
      q.Enqueue(2);
      q.Enqueue(3);

      Assert.AreEqual(3, q.Dequeue());
      Assert.AreEqual(2, q.Dequeue());
      Assert.AreEqual(1, q.Dequeue());
    }

    [TestMethod]
    public void Test_PriorityUpgrade()
    {
      PriorityQueue<double> q = null;

      q = new MaxPriorityQueue<double>();
      q.Enqueue(30);
      q.Enqueue(10);
      q.Enqueue(20);

      q.Remove(20);
      q.Enqueue(40);

      Assert.AreEqual(40, q.Peek());
    }

    [TestMethod]
    public void Test_Integration_1()
    {
      PriorityQueue<double> q = null;
      double[] items = { 5, 85, 43, 2, 28, 99, 67, 1.98, 33, 19, 17, 44 };
      SortedList<double, double> monitor = new SortedList<double, double>();

      q = new MaxPriorityQueue<double>();

      for (int i = 0; i < items.Length; i++)
      {
        q.Enqueue(items[i]);
        monitor.Add(-1 * items[i], items[i]);
      }

      foreach (double monitorItem in monitor.Values)
      {
        Assert.AreEqual(monitorItem, q.Dequeue());
      }
    }

    [TestMethod]
    public void Test_Integration_2()
    {
      PriorityQueue<double> q = null;
      double[] items = { 82, 100, 9.3, 1.19, 10, 29, 12, 9.0006, 22, 20.9, 207, 13.56, 30, 2, 66 };
      SortedList<double, double> monitor = new SortedList<double, double>();

      q = new MaxPriorityQueue<double>();

      for (int i = 0; i < items.Length; i++)
      {
        q.Enqueue(items[i]);
        monitor.Add(-1 * items[i], items[i]);

        if (i == 3)
        {
          q.Dequeue();
          monitor.Remove(-100);
        }
        else if (i == 8)
        {
          q.Dequeue();
          monitor.Remove(-82);
        }
      }

      foreach (double monitorItem in monitor.Values)
      {
        Assert.AreEqual(monitorItem, q.Dequeue());
      }
    }

    [TestMethod]
    public void Test_Remove()
    {
      PriorityQueue<double> q = null;
      double[] items = { 5, 85, 43, 2, 28, 99, 67, 1.98, 33, 19, 17, 44 };
      SortedList<double, double> monitor = new SortedList<double, double>();

      q = new MaxPriorityQueue<double>(7);

      for (int i = 0; i < items.Length; i++)
      {
        q.Enqueue(items[i]);
        monitor.Add(-1 * items[i], items[i]);
      }

      q.Remove(1.98);
      monitor.Remove(-1.98);
      q.Remove(85);
      monitor.Remove(-85);

      foreach (double monitorItem in monitor.Values)
      {
        Assert.AreEqual(monitorItem, q.Dequeue());
      }
    }

  }
}
