using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;
using System.IO;
using System.Xml.Serialization;

using cbox.system;
using cbox.model;
using cbox.generation;
using cbox.server.responses;

namespace cbox.server
{
    public class Server
    {
        HttpListener Listener = new HttpListener();
        Config Config;
        CBoxSystem System;
        //Random Random = new Random();
        Random Random = Tools.Random;

        private int NextGameID_ = 0;

        public Server(Config config)
        {
            this.Config = config;
            this.System = new CBoxSystem(config.SystemPath);
            Listener.Prefixes.Add("http://+:8008/");
        }


        public int NextSessionID { 
            get
            {
                NextGameID_ += 1;
                return NextGameID_;
            }

        
        }

        public void Start()
        {
            Listener.Start();

            while (Listener.IsListening)
            {
                var ctx = Listener.GetContext();
                Console.Out.WriteLine(ctx.Request.RawUrl);

                if(ctx.Request.RawUrl == "/service/xml/case/random")
                {
                    // pick random model:
                    var model_path = this.System.Models[this.Random.Next(0, this.System.Models.Count)].Path;
                    var model = Model.FromXML(File.ReadAllText(model_path));
                    var case_ = model.RandomCase(this.System);

                    // write xml:
                    var writer = new StringWriter();
                    var serializer = new XmlSerializer(typeof(cbox.model.Case));
                    serializer.Serialize(writer, case_);

                    SendString(writer.ToString(), ctx.Response);
                }

                else if (ctx.Request.RawUrl == "/service/clipack/get")
                {
                    // send client package:
                    ctx.Response.ContentType = "application/json";
                    //SendString(this.System.Ontology.ExportClientPackageString(), ctx.Response);

                    // prepare envelope:
                    var response = new ResponseEnvelope<Ontology>()
                    {
                        type = "client-package",
                        data = this.System.Ontology
                    };

                    SendString(response.ToJSON(), ctx.Response);
                }

                else if (ctx.Request.RawUrl == "/service/game/new")
                {
                    var session = new GameSession() 
                    {
                        SessionID = NextSessionID,
                        Case = this.System.GetRandomCase()
                    };
                    
                    var data = new NewGameData(session.SessionID);
                    
                    var response = new ResponseEnvelope<NewGameData>() 
                    {
                        type = "new-game",
                        data = data
                    };
                    SendString(response.ToJSON(), ctx.Response);
                }

                else
                {
                    ServerFromRoot(ctx.Request.RawUrl, ctx.Response);
                }

                ctx.Response.Close();
            }
        }


        public void SendString(string str, HttpListenerResponse response)
        {
            byte[] buf = Encoding.UTF8.GetBytes(str);
            response.ContentLength64 = buf.Length;
            response.OutputStream.Write(buf, 0, buf.Length);
        }


        private void ServerFromRoot(string rawUrl, HttpListenerResponse response)
        {
            // check root is set:
            if (Config.DocumentRoot == null)
            {
                SendString("File not found.  Root directory not set.", response);
                return;
            }

            // try to locate the file:
            var path = Config.DocumentRoot + "\\" + rawUrl.Replace("/", "\\");
            Console.WriteLine("Sending: " + path);
            if (File.Exists(path))
            {
                // set mimetype:
                foreach (var kvp in Config.Mimetypes)
                {
                    if (path.EndsWith(kvp.Key))
                        response.ContentType = kvp.Value;
                }

                // stream the file:
                using (var filestream = new FileStream(path, FileMode.Open))
                    filestream.CopyTo(response.OutputStream);
            }
            else
            {
                // notify user if no matching file was found:
                SendString("File not found (is root set correctly?): " + rawUrl, response);
                response.StatusCode = 404;
            }
        }
    }
}
