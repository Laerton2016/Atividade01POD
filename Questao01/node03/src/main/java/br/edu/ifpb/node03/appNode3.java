/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.edu.ifpb.node03;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author laerton
 */
public class appNode3 {
    public static void main(String[] args) {
        try {
            String[] dados = ConexSocket.receberDados().split(",");// recebe os dados de node 2
            System.out.println(dados[0] + dados[1] );
            int a = Integer.parseInt(dados[0]),b = Integer.parseInt(dados[1]);
            int result = (int) (Math.pow(b,b) + Math.pow(a,a));// Executa a operacao
            ConexSocket.enviaDados(String.valueOf(result));// Encaminha de volta para node2
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        
        
    }
}
