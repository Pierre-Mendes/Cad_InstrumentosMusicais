using System;
using System.IO;

namespace InstrumentosMusicais
{
 
    class Percusao : Instrumento  {       
        string linhaGravar = "";
        bool aux = false;
        private decimal PrecoDolar {get; set;}    
        private string TipoInstru { get; set; }
        private string EquipPerc { get; set; }
        private string EquipRece {get; set;}
        
        public Percusao(string tipo) : base(tipo) {           
        }
        public Percusao(string tipo, decimal precoDolar) : base(tipo) {                      
            PrecoDolar = precoDolar;
        }
        public void Entrada()  {           
            base.Cadastrar(PrecoDolar);

            Console.Write("Insria o tipo de instrumento: ");
            TipoInstru = Console.ReadLine();
            Console.Write("Insira equipamento de percussão: ");
            EquipPerc = Console.ReadLine();
            Console.Write("Insira o equipamento de recepção: ");
            EquipRece = Console.ReadLine();

            linhaGravar = base.Modelo + ";" + base.PrecoCusto + ";" + base.PorcLucro + ";" + base.ValorVenda + ";" + base.DescForn + ";"  + base.Tipo + ";"+ TipoInstru + ";" + EquipPerc + ";" + EquipRece;
            aux = Gravar(linhaGravar); 
            if(aux) {
                Console.WriteLine(" Cadastro realizado com sucesso! [aperte alguma tecla...] ");
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