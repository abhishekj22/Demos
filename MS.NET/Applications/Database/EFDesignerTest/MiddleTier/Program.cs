using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleTier
{
    using System.ServiceModel;

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(OrderManagerService));
            host.Open();
            Console.ReadKey(true);
            host.Close();
        }
    }
}
