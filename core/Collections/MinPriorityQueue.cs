using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Collections
{
  /// <summary>
  /// Represents minimum priority queue on top of array-based binary heap.
  /// </summary>
  /// <typeparam name="I">The type of the queue's items.</typeparam>
  public class MinPriorityQueue<I> : PriorityQueue<I> where I : IComparable<I>
  {
    /// <summary>
    /// Initializes new MinPriorityQueue instance with default capacity.
    /// </summary>
    /// <remarks>
    /// Default capacity value is 64.
    /// </remarks>
    public MinPriorityQueue() : base()
    { }

    /// <summary>
    /// Initializes new MinPriorityQueue instance with specified capacity.
    /// </summary>
    /// <param name="p_initialCapacity">The specific initial capacity.</param>
    public MinPriorityQueue(int p_initialCapacity)
      : base(p_initialCapacity)
    { }

    /// <summary>
    /// Priority is given to the min item.
    /// </summary>
    /// <param name="p_lhs">The specific item which ask for priority.</param>
    /// <param name="p_rhs">The specific item that its priority is checked against.</param>
    /// <returns>True if p_lhs is less than p_rhs, false otherwise.</returns>
    /// <remarks>Th method is sealed.</remarks>
    protected sealed override bool HasPriority(I p_lhs, I p_rhs)
    {
      return (p_lhs as IComparable<I>).CompareTo(p_rhs) < 0;
    }
  }
}
