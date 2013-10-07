using System.Threading;
using Topshelf;

namespace CreateRequest.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Sim State Service Main Thread";
            HostFactory.Run(x =>
            {
                x.Service<CreateRequestWindowsService>();
                x.RunAsLocalSystem();
                x.SetDescription("Create Request Windows Service");
                x.SetDisplayName(typeof(CreateRequestWindowsService).Namespace);
                x.SetServiceName(typeof(CreateRequestWindowsService).Namespace);
                x.UseNLog();
            });
        }
    }
}
