/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.edu.ifpb.node02;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author laerton
 */
public class appNode2 {
    public static void main(String[] args)  {
        try {
            String resposta = "0";
            String[] dado = ConexSocket.receberDados().split(",");
            System.out.println(dado[0] + dado[1]);
            int a = Integer.parseInt(dado[0]), b= Integer.parseInt(dado[1]);
            if (a !=b){
                ConexSocket.enviaDados(dado[0] +"," + dado[1]); //Envia para node3
                resposta = ConexSocket.receberDados(); // Recebe de Node3
            }
            ConexSocket.enviaDados(resposta, 10999, "localhost");//Retorna para node1
            
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        
    }
   
}
