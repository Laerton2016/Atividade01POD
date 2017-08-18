using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Node1
{
    public class ConexaoSocket
    {

        public static void EnviaDados(String dados, String host, int porta)
        {
            TcpClient client = new TcpClient();
            Console.WriteLine("Estabelecendo conexão com o servidor");
            client.Connect(host, porta);
            NetworkStream stream = client.GetStream();
            if (stream.CanRead && stream.CanWrite)
            {
                byte[] sendBytes = Encoding.ASCII.GetBytes(dados);
                stream.Write(sendBytes, 0, sendBytes.Length);

            }
            else
            {
                if (!stream.CanRead)
                {
                    Console.WriteLine("Não foi possível enviar os dados para o host informado.");
                }
                else
                {
                    if (!stream.CanWrite)
                    {
                        Console.WriteLine("Não foi possível ler os dados para do host informado.");
                    }
                }
                client.Close();
            }
            Console.ReadLine();
        }

        public static String ReceberMensagem(String host, int porta)
        {
            
            String mensagem= "";
            TcpListener listener = new TcpListener(porta);
            listener.Start();
            Console.WriteLine("Aguardando conexão");
            try
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Conexão Aceita");
                NetworkStream stream = client.GetStream();
                Byte[] dados = new byte[client.ReceiveBufferSize];
                stream.Read(dados, 0, (int) client.ReceiveBufferSize);
                mensagem = Encoding.ASCII.GetString(dados).Trim();
                client.Close();
                listener.Stop();
                Console.WriteLine("Conexão encerrada.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            
            return mensagem.Replace("\0", "");
        }
    }
}
