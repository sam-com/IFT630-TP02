using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MPI;

namespace IFT630_TP02
{
    enum IdMessage { Movement, Meow }

    struct Config {
        public readonly uint ratNumber;
        public readonly uint hunterNumber;
        public readonly string mapFilePath;

        public Config(uint ratNumber, uint hunterNumber, string mapFileName) {
            this.ratNumber = ratNumber;
            this.hunterNumber = hunterNumber;
            this.mapFilePath = mapFileName;
        }
    }

    struct Message {
        public readonly IdMessage tag;
        public readonly int rankSender;
    }

    struct Response
    {
        public readonly IdMessage tag;
        public char[][] map;
    }

    class Program
    {
        const int ROOT_INIT_FINISHED = 9;

        static void Main(string[] args)
        {
            Config config = checkConfig(args);
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;


                // MAP
                if (comm.Rank == 0)
                {
                    if (comm.Size != config.ratNumber + config.hunterNumber + 1)
                        throw new Exception("The number of process must be equal to the number of rat + number of hunter + 1");

                    char[,] map = readMapFile(config.mapFilePath);

                    for (int i = 1; i < comm.Size; ++i) {
                        // send map and their position to every process
                    }

                    Message msg = comm.Receive<Message>(Communicator.anySource, Communicator.anyTag);

                    if (msg.tag == IdMessage.Movement)
                    {
                        Message response = new Message();

                        Random rand = new Random();
                        int action = rand.Next(0,5);

                        switch (action) {
                            case 0: // movement valid

                                break;
                            case 1: // movement valid - rat exit

                                break;
                            case 2: // movement valid - rat captured

                                break;
                            case 3: // movement valid - cheese eated

                                break;
                            case 4: // movement invalid
                                comm.Send<Message>(response, msg.rankSender, 0);
                                break;
                        }



                    }
                    else if (msg.tag == IdMessage.Meow)
                    {

                    }
                    else
                    {
                        throw new Exception("Unknow message tag");
                    }


                }
                // RAT
                //else if (comm.Rank <= config.ratNumber)
                else if (comm.Rank == 1)
                {

                }
                //HUNTER
                else
                {

                }
            }
        }

        private static Config checkConfig(string[] args) {
            Config config;
            if (args.Length != 3)
                //throw new Exception("The program need 3 arguments : 1- number of rats 2- number of hunters 3- file name for the map");
                config = new Config(4, 3, "todo");
            else
            config = new Config(UInt32.Parse(args[0]), UInt32.Parse(args[1]), args[2]);

            //if(!System.IO.File.Exists(config.mapFileName))
                //throw new Exception("The path for the map file doesn't exist");
            
            return config;
        }

        private static char[,] readMapFile(string mapFilePath) {
            return new char[1,1];
        }
    }
}
