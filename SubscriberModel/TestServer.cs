using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using System.IO;

namespace OntologyEditor
{
    public class TestServer
    {
        const string URL_CLIPACK = "/asset/dynamic/clipack";
        const string URL_RANDOM_CASE = "/asset/dynamic/random_case";

        private Dictionary<string, string> MIMETYPES = new Dictionary<string, string>()
        {
            { ".html", "text/html" },
            { ".htm", "text/html" },
            { ".js", "text/javascript" },
            { ".css", "text/css" },
            { ".json", "application/json" },
        };

        HttpListener Listener = new HttpListener();

        public string RootDirectory { get; set; }

        public TestServer()
        {
            Listener.Prefixes.Add("http://+:8008/");
        }

        public async void Start()
        {
            //var response = "Hello internal server world!";

            Listener.Start();

            while(Listener.IsListening)
            {
                Task<HttpListenerContext> getCtx = Listener.GetContextAsync();
                var ctx = await getCtx;
                Console.Out.WriteLine(ctx.Request.RawUrl);
                HandleRequest(ctx.Request, ctx.Response);

                ctx.Response.Close();
            }
        }

        public void HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            switch (request.RawUrl)
            {
                case URL_CLIPACK:
                    response.ContentType = MIMETYPES[".json"];
                    SendString(Program.OntologyInstance.ExportClientPackage(), response);
                    break;
                    
                case URL_RANDOM_CASE:
                    response.ContentType = MIMETYPES[".json"];
                    SendString("Random case?", response);
                    break;

                default:
                    ServerFromRoot(request.RawUrl, response);
                    break;
            } 
        }

        private void ServerFromRoot(string rawUrl, HttpListenerResponse response)
        {
            // check root is set:
            if(RootDirectory == null)
            {
                SendString("File not found.  Root directory not set.", response);
                return;
            }

            // try to locate the file:
            var path = RootDirectory + "\\" + rawUrl.Replace("/", "\\");
            Console.WriteLine("Sending: " + path);
            if(File.Exists(path))
            {
                // set mimetype:
                foreach (var kvp in MIMETYPES)
                {
                    if (path.EndsWith(kvp.Key))
                        response.ContentType = kvp.Value;
                }

                // stream the file:
                using(var filestream = new FileStream(path, FileMode.Open))
                    filestream.CopyTo(response.OutputStream);
            }
            else
            {
                // notify user if no matching file was found:
                SendString("File not found (is root set correctly?): " + rawUrl, response);
                response.StatusCode = 404;
            }
        }

        public void SendString(string str, HttpListenerResponse response)
        {
            byte[] buf = Encoding.UTF8.GetBytes(str);
            response.ContentLength64 = buf.Length;
            response.OutputStream.Write(buf, 0, buf.Length);
        }

        public void Stop()
        {
            Listener.Stop();
        }
    }
}
