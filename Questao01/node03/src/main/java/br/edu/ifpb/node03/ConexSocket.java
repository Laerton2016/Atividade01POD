package br.edu.ifpb.node03;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */



import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import javax.net.ssl.SSLSocket;

/**
 *
 * @author laerton
 */
public class ConexSocket {
    
    
    private static final int PORTA_NODE1 = 10999;
    private static final String HOST_NODE1 = "localhost";
    private static final int PORTA_NODE2 = 10998;
    private static final String HOST_NODE2 = "localhost";
    private static final int PORTA_NODE3 = 10997;
    private static final String HOST_NODE3 = "localhost";
    
    public static String enviaDados(String dados) throws IOException, Exception{
        return enviaDados(dados, PORTA_NODE2, HOST_NODE2);
        
    }
    
    
    public static String receberDados () throws IOException{
        String mensagem = "";
        System.out.println("Servidor ativo!");
        ServerSocket server = new ServerSocket(PORTA_NODE3);
        while(true){
            Socket sock = server.accept();
            InputStream in = sock.getInputStream();
            byte[] b = new byte[1024];
            in.read(b);
            mensagem = new String(b).trim();
            sock.close();
            server.close();
            System.out.println("Servidor encerrado!");
            return mensagem;
        }
        
    }

    static String enviaDados(String dados, int porta, String host) throws IOException, Exception {
        String retorno = "";
        Socket sock = new Socket(host, porta);
        OutputStream out = sock.getOutputStream();
        out.write(dados.getBytes());
        //tratando o retorno
        InputStream in = sock.getInputStream();
        byte[] b = new byte[1024];
        in.read(b);
        retorno = new String(b);
        if (retorno.contains("ERROR")){ 
            throw  new Exception("Conexão com NODE2 foi recusada");
        }
        sock.close();
        return retorno.trim();
    }
        
    
        
    
    
}
