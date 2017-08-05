using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;

namespace IFT630_TP02
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Console.WriteLine("Hello, World! from rank " + Communicator.world.Rank + " (running on " + MPI.Environment.ProcessorName + ")");
            }
        }
    }
}
