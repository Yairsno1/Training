using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Collections;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  public class GraphExplorer : IGraphExplorer
  {
    IGraph m_graph;

    public GraphExplorer(IGraph p_explored)
    {
      if (null == p_explored)
      {
        throw new ArgumentNullException("p_explored", "Graph can not be null");
      }

      m_graph = p_explored;
    }

       #region IGraphExplorer
    public IPath AStar(IVertex p_start, IVertex p_destination)
    {
      SearchResultPath rv = null;
      IApproximations approxTable = null;
      SearchVertex currLocation = null;
      Dictionary<string, IVertex> visited = null;
      PriorityQueue<SearchVertex> frontier = null;
      Dictionary<string, SearchVertex> frontierLookup = null; //Quick search if expanded vertex is in the frontier already.
      string currLocationName = string.Empty;

      if (null == p_start)
      {
        throw new ArgumentNullException("p_start", "Start vertex can not be null");
      }
      else if (null == p_destination)
      {
        throw new ArgumentNullException("p_destination", "Destination vertex can not be null");
      }

      approxTable = m_graph.Approximations;

      currLocationName = p_start.Name;
      currLocation = new SearchVertex(p_start, null, 0, approxTable.GetH(p_start, p_destination));
      if (currLocationName.Equals(p_destination.Name))
      {
        rv = new SearchResultPath(currLocation);
      }
      else
      {
        frontier = new MinPriorityQueue<SearchVertex>();
        frontierLookup = new Dictionary<string, SearchVertex>();
        visited = new Dictionary<string, IVertex>();

        frontier.Enqueue(currLocation);
        frontierLookup.Add(currLocationName, currLocation);

        while (!frontier.IsEmpty)
        {
          currLocation = frontier.Dequeue();
          currLocationName = currLocation.Name;
          frontierLookup.Remove(currLocationName);
          visited.Add(currLocationName, currLocation.GraphVertex);

          foreach (IEdge e in currLocation.GraphVertex.OutEdges)
          {
            IVertex target = e.Target;
            if (null == target)
            {
              continue;
            }
            else if (visited.ContainsKey(target.Name))
            {
              continue;
            }



          } //foreach

        } //while
      } //start != destination



      return rv;
    }

    public IGraph Graph
    {
      get 
      {
        return m_graph;
      }
    }
       #endregion

  }
}
