using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9Assignment
{
    /// <summary>
    /// This is an interface which requires any classes which inherit from it to provide a Serialize and Deserialize method.
    /// </summary>
   
    interface Iserializer
    {
        /// <summary>
        /// Requires a method to use Seserialize.
        /// </summary>
        /// <param name="list">
        /// This is the collection which will be derialized.
        /// </param>
        /// <param name="path">
        /// This is the path of where to serialize to.
        /// </param>
        /// <returns>
        /// </returns>

        PersonList<Person> Serialize(PersonList<Person> list, string path);

        /// <summary>
        /// Requires a method to use Deserialize.
        /// </summary>
        /// <param name="path">
        /// This is the path of where to derialize to.
        /// </param>
        /// <returns>
        /// </returns>
        
        PersonList<Person> Deserialize(string path);
    }
}
