using System;
using System.Collections.Generic;

namespace Week14IDisposable
{
    /// <summary>
    /// Represents an agent. Must destroy all evidence when "burned."
    /// </summary>
    public class Agent : Asset
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
        /// Instantiates a new Agent object with the given name and ID number.
        /// </summary>
        /// <param name="name">The agent's name.</param>
        /// <param name="id">The agent's ID number.</param>
        public Agent(string name, int id) : base(name, 1)
        {
            assetName = name;
            idNumber = id;
            secrets = new List<string>()
            {
                "The cake is a lie.",
                "Gender is a construct made up by the church to prevent you from eating all the communion wafers.",
                "The Twin Towers never actually collapsed. In fact, they are still there."
            };
        }

        /// <summary>
        /// Requests a report from this agent. The request will only be granted to one with a higher clearance level.
        /// </summary>
        /// <param name="requester">The asset requesting the report of this agent.</param>
        /// <returns>A report of the secrets the agent knows if the clearance checks out; otherwise throws an UnauthorizedAccessException.</returns>
        public List<string> RequestReport(Asset requester)
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException(AssetName);
            }
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
            return assetName;
        }

        /// <summary>
        /// Dispose this object, freeing up resources.
        /// </summary>
        /// <param name="disposing">Whether or not to manually dispose managed state.</param>
        /// <remarks>This isn't the best example of a dispose method - it's not like these resources are taking up that much space.</remarks>
        protected sealed override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    secrets = null;
                    base.Dispose(disposing);
                }
                disposedValue = true;
            }
        }
    }
}
