using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// This class inherits from Individual and holds two unique properties.
    /// </summary>
    public class Member : Individual
    {
        public int Rank
        {
            get;
            set;
        }

        public string PositionTitle
        {
            get;
            set;
        }
    }
}
