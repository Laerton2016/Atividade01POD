using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Node1;

namespace Node2
{
    class Node2App
    {
        static void Main(string[] args)
        {
            String hostNode2 = "127.0.0.1";
            String hostNode3 = "127.0.0.1";
            String hostNode4 = "127.0.0.1";


            int  portaNode2 = 10998, portaNode3 = 10997, portaNode4 = 10996;
            String mensage = "";
            try
            {
                Console.WriteLine("Conexão aberta.");
                Boolean para = true;
                while (para)
                {
                    mensage = ConexaoSocket.ReceberMensagem(hostNode2, portaNode2);// recebe dados
                    if (mensage.Equals("END"))
                    {
                        ConexaoSocket.EnviaDados(mensage, hostNode4, portaNode4);
                        ConexaoSocket.EnviaDados(mensage, hostNode3, portaNode3);
                        para = false;
                    }
                    else if (mensage.Contains("sum"))
                    {
                        ConexaoSocket.EnviaDados(mensage, hostNode4, portaNode4);

                    }else if (mensage.Contains("diff"))
                    {
                        ConexaoSocket.EnviaDados(mensage, hostNode3, portaNode3);
                    }
                    Console.WriteLine("A operação " + mensage + " foi enviada.");
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
