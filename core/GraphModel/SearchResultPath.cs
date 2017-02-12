using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YS.Training.Core.Interfaces.GraphModelDef;

namespace YS.Training.Core.GraphModel
{
  internal class SearchResultPath : IPath
  {
    private LinkedList<int> xx;

    public SearchResultPath()
    {

    }


       #region IPath
    public IVertex EndVertex
    {
      get { throw new NotImplementedException(); }
    }

    public bool IsEmpty
    {
      get { throw new NotImplementedException(); }
    }

    public IVertex NextVertex(IVertex sourceVertex)
    {
      throw new NotImplementedException();
    }

    public IVertex StartVertex
    {
      get { throw new NotImplementedException(); }
    }

    public double Weight
    {
      get { throw new NotImplementedException(); }
    }
      #endregion

  }
}
