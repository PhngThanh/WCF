using Microsoft.Owin.Hosting;
using System;
using System.ServiceModel;
using WcfAndSignalr.signalr;
using System.Runtime.InteropServices;
namespace WcfAndSignalr
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            using (ServiceHost host = new ServiceHost(typeof(WcfAndSignalr.LocalService)))
            {
             
                using (ServiceHost cateHost = new ServiceHost(typeof(WcfAndSignalr.Implements.CategoryService)))
                {
                    using (ServiceHost promotionDetailHost = new ServiceHost(typeof(WcfAndSignalr.Implements.PromotionDetailService)))
                    {
                        using (ServiceHost promotionHost = new ServiceHost(typeof(WcfAndSignalr.Implements.PromotionService)))
                        {
                            using (ServiceHost tableHost = new ServiceHost(typeof(WcfAndSignalr.Implements.TableService)))
                            {
                                using (ServiceHost productHost = new ServiceHost(typeof(WcfAndSignalr.Implements.ProductService)))
                                {
                                    using (ServiceHost storetHost = new ServiceHost(typeof(WcfAndSignalr.Implements.StoreService)))
                                    {

                                        host.Open();
                                        productHost.Open();
                                        cateHost.Open();
                                        promotionDetailHost.Open();
                                        promotionHost.Open();
                                        tableHost.Open();
                                        storetHost.Open();
                                        Console.ReadLine();
                                    }
                                }
                            }
                        }
                    }
                }
     
            }
        }
    }
}
