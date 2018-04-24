using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// Something that the player could encounter upon their journey.
    /// </summary>
    public class Entity
    {
        public int EntityID { get; set; }
        public string EntityName { get; set; }
        public bool IsAlive { get; set; }
    }
}
