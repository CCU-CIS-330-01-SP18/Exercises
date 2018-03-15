namespace Week9Serialization
{
    interface ISerializer
    {
        /// <summary>
        /// Serializes this object, and puts the serialized object in a file.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="path">The path to the file that will hold the serialized object.</param>
        void Serialize(object obj, string path);

        /// <summary>
        /// Given a path to a file, deserializes an object contained in that file.
        /// </summary>
        /// <param name="serialized">A string containing the path to a file that contains a serialized object.</param>
        /// <returns>The deserialized object.</returns>
        object Deserialize(string filePath);
    }
}
