using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Node1;

namespace Node4
{
    class Node4APP
    {
        static void Main(string[] args)
        {
            String hostNode4 = "127.0.0.1";


            int  portaNode4 = 10996;
            String mensage = "";
            try
            {
                Console.WriteLine("Conexão aberta.");
                Boolean para = true;
                while (para)
                {
                    mensage = ConexaoSocket.ReceberMensagem(hostNode4, portaNode4);// recebe dados
                    if (mensage.Equals("END"))
                    {
                        para = false;
                    }
                    Console.WriteLine(mensage);
                }



                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
