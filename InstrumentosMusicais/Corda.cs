using System;
using System.IO;

namespace InstrumentosMusicais
{
 
    class Corda : Instrumento  {       
        string linhaGravar = "";
        bool aux = false;
        private decimal PrecoDolar {get; set;}
        private string TipoInstru { get; set; }
        private string TipoCorda { get; set; }
        private int NumCorda {get; set;}
        
        public Corda(string tipo) : base(tipo) {  
                 
        }
        public Corda(string tipo, decimal precoDolar) : base(tipo) {  
                              
            PrecoDolar = precoDolar;
        }
        public void Entrada()  {           
            base.Cadastrar(PrecoDolar);

            Console.Write("Insria o tipo de instrumento: ");
            TipoInstru = Console.ReadLine();
            Console.Write("Insria o tipo de corda: ");
            TipoCorda = Console.ReadLine();
            Console.Write("Insriai o número de cordas: ");
            NumCorda = int.Parse(Console.ReadLine());

            linhaGravar = base.Modelo + ";" + base.PrecoCusto + ";" + base.PorcLucro + ";" + base.ValorVenda + ";" + base.DescForn + ";" + base.Tipo + ";" + TipoInstru + ";" + TipoCorda + ";" + NumCorda;
            aux = Gravar(linhaGravar); 
            if(aux) {
                Console.WriteLine("Cadastro realizado com sucesso! [aperte alguma tecla...]");
                Console.ReadKey();
            }            
        }
        private bool Gravar(string linha) {
            StreamWriter gravar = new StreamWriter("Instrumento.txt", true); 
            gravar.WriteLine(linha);           
            gravar.Close();
            return true;
        }    

    }
}