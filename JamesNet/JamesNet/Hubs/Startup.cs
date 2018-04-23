using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JamesNet.Hubs.Startup))]
namespace JamesNet.Hubs
{
    /// <summary>
    /// Startup class for SignalR.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Maps SignalR hubs to the given app stream.
        /// </summary>
        /// <param name="app">The app stream to map SignalR hubs to.</param>
        public void Configuration(IAppBuilder app)
        {
            Models.Encryptor.GenerateIV();
            app.MapSignalR();
        }
    }
}