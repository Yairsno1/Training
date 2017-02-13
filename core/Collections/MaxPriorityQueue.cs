using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Collections
{
  public class MaxPriorityQueue<I> : PriorityQueue<I> where I : IComparable<I>
  {
    public MaxPriorityQueue() : base()
    { }

    public MaxPriorityQueue(int p_initialCapacity)
      : base(p_initialCapacity)
    { }

    protected override bool HasPriority(I p_lhs, I p_rhs)
    {
      return (p_lhs as IComparable<I>).CompareTo(p_rhs) > 0;
    }
  }
}
