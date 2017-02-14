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
      SearchVertex expanding = null;  //current explored vertex
      IVertex expandingGVertex = null; //current explored vertex of the graph(cache from object expanding)
      string expandingName = string.Empty; //the name of the current explored vertex(cache from object expanding)
      Dictionary<string, byte> visited = null; //Already visited vertices, we intersted in the key only.
      PriorityQueue<SearchVertex> frontier = null; 
      Dictionary<string, SearchVertex> frontierLookup = null; //Quick search if expanded vertex is in the frontier already.
      SearchVertex goal = null;

      if (null == p_start)
      {
        throw new ArgumentNullException("p_start", "Start vertex can not be null");
      }
      else if (null == p_destination)
      {
        throw new ArgumentNullException("p_destination", "Destination vertex can not be null");
      }
      

      if (p_start.Equals(p_destination))
      {
        goal = new SearchVertex(p_start, null, 0, 0);
      }
      else
      {
        approxTable = m_graph.Approximations;
        frontier = new MinPriorityQueue<SearchVertex>(m_graph.Vertices.Count);
        frontierLookup = new Dictionary<string, SearchVertex>();
        visited = new Dictionary<string, byte>();

        //Initialize the frontier with our serach start
        SearchVertex start = new SearchVertex(p_start, null, 0, approxTable.GetH(p_start, p_destination));
        frontier.Enqueue(start);
        frontierLookup.Add(start.Name, start);

        //Let's roll ...
        while (!frontier.IsEmpty)
        {
          //pick the best path so far, remove the vertex from the frontier and mark it as visited.
          expanding = frontier.Dequeue();
          expandingGVertex = expanding.GraphVertex;
          expandingName = expandingGVertex.Name;
          frontierLookup.Remove(expandingName);
          visited.Add(expandingName, 0);

          //Expand ...
          foreach (IEdge e in expandingGVertex.OutEdges)
          {
            IVertex neighbor = e.Target;            

            if (null == neighbor)
            {
              continue; //Dead-end
            }
            else if (visited.ContainsKey(neighbor.Name))
            {
              continue; //We have been here before.
            }

            string neighborName = neighbor.Name;

            SearchVertex discovery = new SearchVertex(neighbor, expanding, e.Weight, approxTable.GetH(neighbor, p_destination));

            if (neighbor.Equals(p_destination))
            {
              //goal!!
              if (null == goal)
              {
                goal = discovery;
              }
              else
              {
                if (discovery.Delta < goal.Delta)
                {
                  //Better path.
                  goal = discovery;
                }
              }

              continue;
            }

            if (frontierLookup.ContainsKey(neighborName))
            {
              //Still in the frontier.
              SearchVertex exists = frontierLookup[neighborName];
              if (discovery.Delta < exists.Delta)
              {
                frontier.Remove(exists);
                frontierLookup.Remove(neighborName);

                frontier.Enqueue(discovery);
                frontierLookup.Add(discovery.Name, discovery);
              }

              continue;
            }

            //Don't bother if we have found a path and it is better that what we are still exploring.
            if (null == goal || (null != goal && discovery.Delta < goal.Delta))
            {
              frontier.Enqueue(discovery);
              frontierLookup.Add(discovery.Name, discovery);
            }

          } //foreach

        } //while
      } //start != destination

      if (null != goal)
      {
        rv = new SearchResultPath(goal);
      }

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
