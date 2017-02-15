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
  /// <remarks>
  /// Search algorithms use this type of vertex to store information about
  /// the vertices that founed during the search.
  /// </remarks>
  internal class SearchVertex : IComparable<SearchVertex>
  {
    private IVertex m_subject; //Graph model vertex.
    private SearchVertex m_prev; //The vertex we came from, helps to memorize the path.
    private double m_delta; //Path cost from the start to this vertex.
    private double m_approximation; //Hueristic estimation of the cost to gaol.

    /// <summary>
    /// Initialize SearchVertex instance that wraps the specified graph model vertex, points to
    /// the vertex it came from, with the cost from the previous vertex
    /// and the estimation of the cost to gaol.
    /// </summary>
    /// <param name="p_subject">The graph model vertex context.</param>
    /// <param name="p_expandedFrom">The vertex that this vertex directly expanded from.</param>
    /// <param name="p_expansionDelta">The weight from the previous version.</param>
    /// <param name="p_approximation">Estimation of the cost to gaol.</param>
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


    public double Delta
    {
      get
      {
        return m_delta;
      }
    }

    public IVertex GraphVertex
    {
      get
      {
        return m_subject;
      }
    }

    public string Name
    {
      get
      {
        return m_subject.Name;
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
      if (null == p_other)
      {
        throw new ArgumentNullException("p_other", "other object to compare can not be null");
      }

      return (m_delta + m_approximation).CompareTo(p_other.m_delta + p_other.m_approximation);
    }
  }
}
