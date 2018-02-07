﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// A generic class inherited from the Individual class and contains the unique ID and JoinDate properties.
    /// </summary>
    class Member : Individual
    {
        public int MemberID
        {
            get;
            set;
        }
        public DateTime JoinDate
        {
            get;
            set;
        }
    }
}