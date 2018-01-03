using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFlow
{
    /// <summary>
    /// Indentifies the action a driver may take at a stoplight.
    /// </summary>
    public enum DriverAction
    {
        Unknown,

        Stop,

        ProceedWithCaution,

        StopIfSafe,
    }
}
