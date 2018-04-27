using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ASN
{
    /// <summary>
    /// Serializes objects into a flatfile format.
    /// </summary>
    public static class DataSerializer
    {
        /// <summary>
        /// Serializes a collection object.
        /// </summary>
        /// <param name="o">The collection object to serialize.</param>
        public static void SerializeUsers(List<User> o)
        {
            var formatter = new BinaryFormatter();

            using (var stream = File.Create("users.txt"))
            {
                formatter.Serialize(stream, o);
            }
        }

        /// <summary>
        /// Deserializes a collection object.
        /// </summary>
        /// <param name="o">The collection object to deserialize.</param>
        public static List<User> DeserializeUsers()
        {
            try
            {
                var formatter = new BinaryFormatter();

                List<User> users = null;
                using (var reader = File.OpenRead("users.txt"))
                {
                    users = formatter.Deserialize(reader) as List<User>;
                }

                return users;
            }
            catch (FileNotFoundException)
            {
                return new List<User>();
            }
        }

        /// <summary>
        /// Serializes a collection object.
        /// </summary>
        /// <param name="o">The collection object to serialize.</param>
        public static void SerializePosts(List<Post> o)
        {
            var formatter = new BinaryFormatter();

            using (var stream = File.Create("posts.txt"))
            {
                formatter.Serialize(stream, o);
            }
        }

        /// <summary>
        /// Deserializes a collection object.
        /// </summary>
        /// <param name="o">The collection object to deserialize.</param>
        public static List<Post> DeserializePosts()
        {
            try
            {
                var formatter = new BinaryFormatter();

                List<Post> posts = null;
                using (var reader = File.OpenRead("posts.txt"))
                {
                    posts = formatter.Deserialize(reader) as List<Post>;
                }

                return posts;
            }
            catch (FileNotFoundException)
            {
                return new List<Post>();
            }
        }
    }
}
