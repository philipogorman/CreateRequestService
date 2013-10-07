using System.Threading;
using Topshelf;

namespace CreateRequestServiceTester.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Sim State Service Main Thread";
            HostFactory.Run(x =>
            {
                x.Service<CreateRequestServiceTesterWindowsService>();
                x.RunAsLocalSystem();
                x.SetDescription("Create Request Windows Service");
                x.SetDisplayName(typeof(CreateRequestServiceTesterWindowsService).Namespace);
                x.SetServiceName(typeof(CreateRequestServiceTesterWindowsService).Namespace);
                x.UseNLog();
            });
        }
    }
}
