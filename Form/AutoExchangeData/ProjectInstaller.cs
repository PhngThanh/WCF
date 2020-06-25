using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace AutoExchangeData
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private readonly ServiceProcessInstaller processInstaller;
        private readonly System.ServiceProcess.ServiceInstaller serviceInstaller;
        public ProjectInstaller()
        {
            InitializeComponent();
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new System.ServiceProcess.ServiceInstaller();

            // Service will run under system account
            processInstaller.Account = ServiceAccount.LocalSystem;

            // Service will have Start Type of Manual
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            serviceInstaller.ServiceName = "Windows Automatic Start Service";

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
            serviceInstaller.AfterInstall += serviceInstaller1_AfterInstall;
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            var service = new ServiceController(serviceInstaller.ServiceName);
            if (service.Status != ServiceControllerStatus.Running)
            {
                service.Start();
            }
        }
    }
}
