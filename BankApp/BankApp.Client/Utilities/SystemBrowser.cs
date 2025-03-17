using Duende.IdentityModel.OidcClient.Browser;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Client.Utilities
{
    public class SystemBrowser : IBrowser
    {
        public int Port { get; }

        private readonly string _path;
        public SystemBrowser(int? port = null, string path = null)
        {
            // TODO: implement system browser logic
            ;
        }

        private int GetRandomUnusedPort()
        {
            // TODO: load random unused port
            return default !;
        }

        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            // TODO: implement invoke logic
            return default !;
        }

        private static void OpenBrowser(string url)
        {
            // TODO: implement open browser logic
            ;
        }
    }

    public class LoopbackHttpListener : IDisposable
    {
        private const int DefaultTimeout;
        private readonly HttpListener _listener;
        private readonly string _url;
        public LoopbackHttpListener(int port, string path = null)
        {
            // TODO: implement loopback http listener logic
            ;
        }

        public async Task<string> WaitForCallbackAsync(int timeoutInSeconds = DefaultTimeout)
        {
            // TODO: implement wait for callback logic
            return default !;
        }

        public void Dispose()
        {
            // TODO: implement dispose logic
            ;
        }
    }
}