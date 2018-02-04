using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    public interface ILocatable
    {
        string Location
        {
            get;
            set;
        }

        string GetLocation();
    }
}
