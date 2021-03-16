using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentosMusicais {
    class Instrumento { 
        Fornecedor fornec = new Fornecedor(); 
        string nomeFornec = "";    
        string nomeFornecAux = ""; 
        bool controll = false;  
        public string Modelo { get; set; }       
        public decimal PrecoCusto { get; set; }
        public decimal PorcLucro { get; set; }
        public decimal ValorVenda { get; set; }       
        public decimal ValorDolar { get; set; }       
        public string Tipo { get; set; }
        public string DescForn { get; set; }

        public Instrumento( string tipo) {
            Tipo = tipo;
        }        
        public Instrumento() {
            
        }        
        public virtual void Cadastrar( decimal dolar) {  
            Console.Write(" Insira o modelo: ");
            Modelo = Console.ReadLine();
            Console.Write(" Insira preço de custo: ");
            PrecoCusto = decimal.Parse(Console.ReadLine());
            Console.Write(" Insira % de lucro: ");
            PorcLucro = decimal.Parse(Console.ReadLine());
            if(dolar > 0) {
                ValorVenda = ((dolar * PrecoCusto) / PorcLucro) + (PrecoCusto * dolar);
            } else {
                ValorVenda = (PrecoCusto / PorcLucro) + PrecoCusto;
            }        
            Console.WriteLine("Preço de venda: {0}", ValorVenda);
            do {               
                Console.Write(" Nome fornecedor: ");                
                nomeFornecAux = Console.ReadLine();
                nomeFornec = fornec.Procurar(nomeFornecAux);
                if(nomeFornec != "") {                   
                    string[] array = nomeFornec.Split(';');
                    DescForn = array[0];
                    controll = true;                    
                } else {
                    Console.WriteLine("Fornecedor não encontrado <tecle algo>");
                    Console.ReadKey();
                }                
            }while(!controll);            
        }

        public void Listar () { 
            StreamReader ler = new StreamReader("Instrumento.txt");
            
            Console.Clear();
            while(!ler.EndOfStream) {
                Console.WriteLine(ler.ReadToEnd());              
            }            
            ler.Close();
            Console.ReadKey();            
        }
        public bool Consular (string Modelo) {         
            string linha = "";
            bool auxBool = false;
            string[] array;
            StreamReader ler = new StreamReader("Instrumento.txt");                      
            while(!ler.EndOfStream) {                
                linha = ler.ReadLine();  
                array = linha.Split(';');
               if(array[0].ToUpper() == Modelo.ToUpper()) {
                   Console.WriteLine(linha); 
                   Console.ReadKey(); 
                   auxBool = true;
                   break;                 
                }                                               
            }               
            ler.Close();
            return auxBool;            
        }

    }
}
