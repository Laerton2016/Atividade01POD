/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.edu.ifpb.node01;

import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author laerton
 */
public class appNode1 {
    public static void main(String[] args) 
    {
        int a,b;
        Random r = new Random();
        a = r.nextInt(100);
        b = r.nextInt(100);
        String dado = a + "," + b;
        System.out.println(dado);
        try {
            ConexSocket.enviaDados(dado);//Envia para node 2
            System.out.println("Resposta : " + ConexSocket.receberDados());//Recebe a respota de node2
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        
    }
}
