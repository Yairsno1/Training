using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  /// <summary>
  /// Stores huristic estimation of the path cost between two vertices in a graph.
  /// </summary>
  public class Approximations : IApproximations
  {
    private Dictionary<string, Dictionary<string, double>> m_aprroxsTable;

    /// <summary>
    /// Initializes Approximations instance.
    /// </summary>
    public Approximations()
    {
      m_aprroxsTable = new Dictionary<string, Dictionary<string, double>>();
    }


       #region IApproximations implementation
    /// <summary>
    /// Gets huristic estimation of the path cost from start to destination vertices.
    /// </summary>
    /// <param name="p_source">Vertex from.</param>
    /// <param name="p_target">Vertex to.</param>
    /// <returns>Huristic estimation, 0 if hueristic for the pair is missing.</returns>
    public double GetH(IVertex p_source, IVertex p_target)
    {
      double rv = 0;
      string srcVName = string.Empty;
      Dictionary<string, double> src2TargetesApprox = null;
      string targetVName = string.Empty;

      if (null == p_source)
      {
        throw new ArgumentNullException("p_source", "Source vertex can not be null");
      }
      else if (null == p_target)
      {
        throw new ArgumentNullException("p_target", "Target vertex can not be null");
      }

      srcVName = p_source.Name;
      if (m_aprroxsTable.ContainsKey(srcVName))
      {
        src2TargetesApprox = m_aprroxsTable[srcVName];
        targetVName = p_target.Name;
        if (src2TargetesApprox.ContainsKey(targetVName))
        {
          rv = src2TargetesApprox[targetVName];
        }
      }

      return rv;
    }
      #endregion

    /// <summary>
    /// Sets huristic estimation of the path cost from start to destination vertices.
    /// </summary>
    /// <param name="p_source">Vertex from.</param>
    /// <param name="p_target">Vertex to.</param>
    /// <param name="p_approximationValue">Estimation value.</param>
    public void SetH(IVertex p_source, IVertex p_target, double p_approximationValue)
    {
      string srcVName = string.Empty;
      Dictionary<string, double> src2TargetesApprox = null;
      string targetVName = string.Empty;

      if (null == p_source)
      {
        throw new ArgumentNullException("p_source", "Source vertex can not be null");
      }
      else if (null == p_target)
      {
        throw new ArgumentNullException("p_target", "Target vertex can not be null");
      }
      else if (p_approximationValue < 0)
      {
        throw new ArgumentException("Approximation must be greater than or equal to zero", "p_approximationValue");
      }

      srcVName = p_source.Name;

      if (!m_aprroxsTable.ContainsKey(srcVName))
      {
        m_aprroxsTable.Add(srcVName, new Dictionary<string, double>());
      }
      src2TargetesApprox = m_aprroxsTable[srcVName];

      targetVName = p_target.Name;
      if (src2TargetesApprox.ContainsKey(targetVName))
      {
        src2TargetesApprox[targetVName] = p_approximationValue;
      }
      else
      {
        src2TargetesApprox.Add(targetVName, p_approximationValue);
      }
    }

  }
}
