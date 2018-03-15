namespace Week9Serialization
{
    interface ISerializer
    { 
        /// <summary>
        /// Given a path to a file, deserializes a team contained in that file.
        /// </summary>
        /// <param name="filePath">A string containing the path to a file that contains a serialized team.</param>
        /// <returns>The deserialized team.</returns>
        Team<T> Deserialize<T>(string filePath) where T : Cephalokid;

        /// <summary>
        /// Serializes this team, and puts the serialized team in a file.
        /// </summary>
        /// <param name="team">The team to serialize.</param>
        /// <param name="filePath">The path to the file that will hold the serialized team.</param>
        void Serialize<T>(Team<T> team, string filePath) where T : Cephalokid;
    }
}
