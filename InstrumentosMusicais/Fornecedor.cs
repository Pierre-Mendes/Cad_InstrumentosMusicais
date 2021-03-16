using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentosMusicais {
    class Fornecedor
    {
        public string nomeForne { get; set; }
        public string nomeCont { get; set; }
        public string foneCont { get; set; }

        public void Cadastrar() {
            Console.Write("Nome fornecedor: ");
            nomeForne = Console.ReadLine();

            Console.Write("Nome do Contato: ");
            nomeCont = Console.ReadLine();

            Console.Write("Fone do Contato: ");
            foneCont = Console.ReadLine();

            StreamWriter gravar = new StreamWriter("Fornecedor.txt", true);

            
            gravar.WriteLine(nomeForne + ";"+ nomeCont + ";" + foneCont);

            gravar.Close();
            Console.WriteLine("Cadastro realizado com sucesso! [aperte alguma tecla...]");
            Console.ReadKey();
        }       
        public void Listar () {
            StreamReader ler = new StreamReader("Fornecedor.txt");
            
            Console.Clear();
            while(!ler.EndOfStream) {
                Console.WriteLine(ler.ReadToEnd());                 
            }            
            ler.Close();
            Console.ReadKey();            
        }

        public string Procurar( string nome) {
             string linha = "";
             string linhaReturn = "";
            StreamReader ler = new StreamReader("Fornecedor.txt");           
            while(!ler.EndOfStream) { 
                linha = ler.ReadLine();
                string[] array = linha.Split(';');           
                if(array[0].ToUpper() == nome.ToUpper()) {
                   Console.WriteLine(linha); 
                   Console.ReadKey(); 
                   linhaReturn = linha; 
                    break;                  
                }                        
            } 
            ler.Close();           
            return linhaReturn;
            
        }       
    }
}