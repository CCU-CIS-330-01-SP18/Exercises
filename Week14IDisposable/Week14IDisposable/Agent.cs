using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week14IDisposable
{
    /// <summary>
    /// Represents an agent. Must destroy all evidence when "burned."
    /// </summary>
    class Agent : Asset, IDisposable
    {
        private int idNumber;
        private List<string> secrets;
        public int IDNumber
        {
            get
            {
                return idNumber;
            }
        }

        /// <summary>
        /// Instantiates a new Agent object with a random ID number.
        /// </summary>
        public Agent()
        {
            var random = new Random();
            idNumber = random.Next();
            clearanceLevel = 1;
        }

        /// <summary>
        /// Instantiates a new Agent object with the given ID number.
        /// </summary>
        /// <param name="id">The agent's ID number.</param>
        public Agent(int id)
        {
            idNumber = id;
        }

        /// <summary>
        /// Requests a report from this agent. The request will only be granted to one with a higher clearance level.
        /// </summary>
        /// <param name="requester">The asset requesting the report of this agent.</param>
        /// <returns>A report of the secrets the agent knows if the clearance checks out; otherwise throws an UnauthorizedAccessException.</returns>
        public List<string> RequestReport(Asset requester)
        {
            if (requester.ClearanceLevel > ClearanceLevel)
            {
                var report = new List<string>();
                foreach (string secret in secrets)
                {
                    report.Add(secret);
                }
                return report;
            }
            else
            {
                throw new UnauthorizedAccessException("You do not have adequate clearance to request information from this agent.");
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return "Agent " + idNumber.ToString();
        }

        public override Dispose()
        {

        }
    }
}
