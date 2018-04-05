using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExercise
{
    /// <summary>
    /// A laptop with a screen that can turn on and off and has a width/height ratio.
    /// </summary>
    public class Laptop
    {
        public float ScreenPixelRatio { get; set; }
        public bool ScreenOn { get; set; }

        /// <summary>
        /// The default laptop constructor class.
        /// </summary>
        /// <param name="ratio">The screen ratio.</param>
        /// <param name="screenOn">Whether or not the screen is on.</param>
        public Laptop(float ratio, bool screenOn)
        {
            ScreenPixelRatio = ratio;
            ScreenOn = screenOn;
        }

        /// <summary>
        /// Turn the screen on or off.
        /// </summary>
        /// <returns>The new state of the screen.</returns>
        public bool PressPowerButton()
        {
            ScreenOn = !ScreenOn;
            return ScreenOn;
        }
    }
}
