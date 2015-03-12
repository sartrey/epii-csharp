using EPII.Http;

namespace EPII.Test
{
    public class HttpTest : Test
    {
        public override string Id
        {
            get { return "http"; }
        }

        public override void Prepare()
        {
            AddAction(StartHttp);
        }

        public void StartHttp() 
        {
            var server = new Server();
            server.Bind(8000, null, true);
            server.Start();
        }
    }
}
