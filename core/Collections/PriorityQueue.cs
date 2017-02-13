using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YS.Training.Core.Collections
{
  /// <summary>
  /// Represents priority queue on top of array-based binary heap.
  /// https://he.wikipedia.org/wiki/%D7%A2%D7%A8%D7%99%D7%9E%D7%94_%D7%91%D7%99%D7%A0%D7%90%D7%A8%D7%99%D7%AA
  /// </summary>
  /// <typeparam name="I">The type of the queue's items.</typeparam>
  public abstract class PriorityQueue<I> where I : IComparable<I>
  {
    private const int M_DEFAULT_CAPACITY = 64;

    private int m_size;
    private I[] m_items;

    protected PriorityQueue() : this(M_DEFAULT_CAPACITY)
    { }

    protected PriorityQueue(int p_initialCapacity)
    {
      m_items = p_initialCapacity > 0 ? new I[p_initialCapacity] :
                                        new I[M_DEFAULT_CAPACITY];
      m_size = 0;
    }

    
    public int Capacity
    {
      get
      {
        return m_items.Length;
      }
      set
      {
        if (value > m_items.Length)
        {
          Resize(value);
        }
      }
    }

    public bool Contains(I p_item)
    {
      return (null == p_item) ? false : (IndexOf(p_item) > -1);
    }

    public int Count
    {
      get
      {
        return m_size;
      }
    }

    public I Dequeue()
    {
      I rv = default(I);

      rv = Peek();
      if (m_size > 0)
      {
        RemoveAt(0);
      }

      return rv;
    }

    public void Enqueue(I p_item)
    {
      if (m_size == Capacity)
      {
        Resize(m_size * 2);
      }

      //Insert the new item at the end of the array
      m_items[m_size++] = p_item;

      //Bubble it up as long as it has priority over its parent.
      BubbleUp(m_size-1);
    }

    public bool IsEmpty
    {
      get
      {
        return (0 == m_size);
      }
    }

    public I Peek()
    {
      return m_size > 0 ? m_items[0] : default(I);
    }

    public void Remove(I p_item)
    {
      int removedIndex = -1;

      removedIndex = IndexOf(p_item);
      if (removedIndex > -1)
      {
        RemoveAt(removedIndex);
      }
    }

    /// <summary>
    /// Gets if an item should have priotity over other.
    /// </summary>
    /// <param name="p_lhs">The specific item which ask for priority.</param>
    /// <param name="p_rhs">The specific item that its priority is checked against.</param>
    /// <returns>
    /// For minimum queue returns true if left is less than right,
    ///  for maximum queue returns true if left is greater than right.
    /// </returns>
    protected abstract bool HasPriority(I p_lhs, I p_rhs);

    private bool BubbleDown(int p_itemIndex)
    {
      bool rv = false;
      int currIndex = -1;
      int leftIndex = -1;
      int rightIndex = -1;
      int chosenChild = -1;

      if (m_size > 1)
      {
        currIndex = p_itemIndex;

        while (currIndex < m_size - 1)
        {
          leftIndex = (currIndex * 2) + 1;
          rightIndex = (currIndex * 2) + 2;

          if (leftIndex >= m_size)
          {
            break; //no childs.
          }

          //Child to compare.
          chosenChild = leftIndex;
          if (rightIndex < m_size)
          {
            if (HasPriority(m_items[rightIndex], m_items[leftIndex]))
            {
              chosenChild = rightIndex;
            }
          }

          if (HasPriority(m_items[chosenChild], m_items[currIndex]))
          {
            Swap(currIndex, chosenChild);
            currIndex = chosenChild;
            rv = true;
          }
          else
          {
            break;
          }
        }
      }

      return rv;
    }

    private bool BubbleUp(int p_itemIndex)
    {
      bool rv = false;
      int currIndex = -1;
      int parentIndex = -1;

      currIndex = p_itemIndex;
      while (currIndex > 0) //==0 => root.
      {
        parentIndex = (currIndex - 1) / 2;
        if (HasPriority(m_items[currIndex], m_items[parentIndex]))
        {
          Swap(currIndex, parentIndex);
          currIndex = parentIndex;
          rv = true;
        }
        else
        {
          currIndex = -1;
        }
      }

      return rv;
    }

    private int IndexOf(I p_item)
    {
      int rv = -1;
      for (int i=0; i<m_size; i++)
      {
        if (m_items[i].Equals(p_item))
        {
          rv = i;
          break;
        }
      }

      return rv;
    }

    private void RemoveAt(int p_itemIndex)
    {
      if ((m_size - 1) == p_itemIndex) //last
      {
        m_items[--m_size] = default(I);
      }
      else
      {
        m_items[p_itemIndex] = m_items[m_size - 1];
        m_items[--m_size] = default(I);        

        if (!BubbleDown(p_itemIndex))
        {
          BubbleUp(p_itemIndex);
        }
      }
    }

    private void Resize(int p_newSize)
    {
      if (p_newSize > 0 && p_newSize > m_items.Length)
      {
        Array.Resize<I>(ref m_items, p_newSize);
      }
    }

    private void Swap(int p_item1Index, int p_item2Index)
    {
      I tmpItem = default(I);

      tmpItem = m_items[p_item1Index];
      m_items[p_item1Index] = m_items[p_item2Index];
      m_items[p_item2Index] = tmpItem;
    }
  }
}
