using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace Week9CodingExercise
{
    /// <summary>
    /// Class that serializes and deserializes using DataContract Serialization.
    /// </summary>
    class DataContractSerialization : ISerializer
    {
        /// <summary>
        /// Performs a DataContract serialization on a Roster of Action Characters.
        /// </summary>
        /// <param name="roster">The Roster of Action Characters.</param>
        public void Serialize(Roster<ActionCharacter> roster)
        {
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(Roster<ActionCharacter>));

            var xmlSettings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter xmlWriter = XmlWriter.Create("roster_bin_dc.xml", xmlSettings))
            {
                dataContractSerializer.WriteObject(xmlWriter, roster);
            }
        }

        /// <summary>
        /// Performs a DataContract deserialization.
        /// </summary>
        /// <returns>The roster list that has been deserialaized.</returns>
        public Roster<ActionCharacter> Deserialize()
        {
            throw new NotImplementedException();
        }  
    }
}
