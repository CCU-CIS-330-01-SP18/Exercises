using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchyAndCollections
{
    /// <summary>
    /// The level of priority a business client has. This has been implemented primarily for the purposes of Net Neutrality circumvention.
    /// </summary>
    public enum ClientPriority
    {
        Lowest,
        Low,
        Normal,
        High,
        VeryHigh
    }
}
