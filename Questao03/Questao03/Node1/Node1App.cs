using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node1
{
    class Node1App
    {
        static void Main(string[] args)
        {
            String hostNode1 = "127.0.0.1";
            String hostNode2 = "127.0.0.1";
            String hostNode3 = "127.0.0.1";
            

            int portaNode1 = 10999, portaNode2 = 10998, portaNode3 = 10997, portaNode4 = 10996;
            String op1 = "sum(2,2)";
            String op2 = "diff(2,2)";
            try
            {
                Console.WriteLine("Enviando mensagem");
                ConexaoSocket.EnviaDados(op1, hostNode3, portaNode3);
                ConexaoSocket.EnviaDados(op2, hostNode2, portaNode2);
                ConexaoSocket.EnviaDados("END", hostNode2, portaNode2);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
