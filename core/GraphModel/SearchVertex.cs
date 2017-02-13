using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  /// <summary>
  /// Represents vertex that expanded during path search.
  /// </summary>
  internal class SearchVertex : IComparable<SearchVertex>
  {
    private IVertex m_subject;
    private SearchVertex m_prev;
    private double m_delta;
    private double m_approximation;

    public SearchVertex(IVertex p_subject,
                          SearchVertex p_expandedFrom,
                          double p_expansionDelta,
                          double p_approximation)
    {
      m_subject = p_subject;
      m_prev = p_expandedFrom;
      m_delta = (null == m_prev) ? 0 : m_prev.m_delta + p_expansionDelta;
      m_approximation = p_approximation;
    }

    public string Name
    {
      get
      {
        return m_subject.Name;
      }
    }

    public IVertex GraphVertex
    {
      get
      {
        return m_subject;
      }
    }

    public SearchVertex Prev
    {
      get
      {
        return m_prev;
      }
    }

    public int CompareTo(SearchVertex p_other)
    {
      return (m_delta + m_approximation).CompareTo(p_other.m_delta + p_other.m_approximation);
    }
  }
}
