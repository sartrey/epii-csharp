using System.Net;

namespace EPII.Http
{
    public class Server
    {
        private HttpListener _Listener 
            = new HttpListener();
        private Loop _ListenLoop = null;
        private Loop _ProcessLoop = null;
        private Pipe<HttpListenerContext> _Pipe = null;

        public bool IsListening 
        {
            get { return _Listener.IsListening; }
        }

        public Server() 
        {
            _Listener.AuthenticationSchemes 
                = AuthenticationSchemes.Anonymous;
            _ListenLoop = new Loop(ListenRoutine);
            _ProcessLoop = new Loop(ProcessRoutine);
            _Pipe = new Pipe<HttpListenerContext>();
        }

        protected void ListenRoutine()
        {
            if (!_Listener.IsListening)
                return;
            var context = _Listener.GetContext();
            _Pipe.Push(context);
        }

        protected void ProcessRoutine()
        {
            //todo: release process
        }

        public void Bind(int port, string prefix, bool local = true) 
        {
            if (!_Listener.IsListening) {
                _Listener.Prefixes.Clear();
                _Listener.Prefixes.Add(
                    string.Format("http://{0}:{1}/{2}", 
                        local ? "localhost" : "*", port, prefix));
            }
        }

        public void Start()
        {
            _ListenLoop.Start();
            _ProcessLoop.Start();
            _Listener.Start();
        }

        public void Stop() 
        {
            _ListenLoop.Stop();
            _ProcessLoop.Stop();
            _Listener.Stop();
        }
    }
}