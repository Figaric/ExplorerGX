using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace ExplorerGX.Core
{
    public class SideToolBarViewModel : BaseViewModel
    {
        public string Link { get; set; }

        public async Task DownloadIconAsync()
        {
            var client = new WebClient();

            await Task.Run(() => client.DownloadFileAsync(
                new Uri(Link),
                Assembly.GetEntryAssembly().Location));
        }
    }
}
