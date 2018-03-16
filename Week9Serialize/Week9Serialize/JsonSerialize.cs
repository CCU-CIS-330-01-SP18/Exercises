using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Week9Serialization
{
    public class JsonSerialize : ISerializer
    {
        /// <summary>
        /// Serializes in JSON format.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns></returns>
        public string Serialize(object objectToSerialize)
        {
            var settings = new JsonSerializerSettings();

            // I attempted to use these settings to make the last test pass, but to no avail.

            //settings.Culture = System.Globalization.CultureInfo.CurrentCulture;
            //settings.TypeNameHandling = TypeNameHandling.Objects;
            //settings.CheckAdditionalContent = true;
            //settings.TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full;

            return JsonConvert.SerializeObject(objectToSerialize, typeof(CerealList), settings);
        }

        /// <summary>
        /// Deserializes an object that has been serialized in JSON format.
        /// </summary>
        /// <param name="serializedString">The string to deserialize.</param>
        /// <returns></returns>
        public CerealList Deserialize(string serializedString)
        {
            return JsonConvert.DeserializeObject<CerealList>(serializedString);
        }
    }
}
