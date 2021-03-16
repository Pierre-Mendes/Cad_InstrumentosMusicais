using System;

namespace InstrumentosMusicais
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = 0;
            string importado = "";
            decimal valorDolar = 0;
            string nomeFornec = "";
            string modeloInstru = "";
            int tipo = 0;
            string tipoInstru = "";

            Fornecedor fornec = new Fornecedor();  
            Instrumento instru = new Instrumento();       

            do{
                Console.Clear();
                Console.WriteLine("**** Controle de Instrumentos Musicais ****");
                Console.WriteLine("1. Cadastro de Instrumentos");
                Console.WriteLine("2. Cadastro de Fornecedores");
                Console.WriteLine("3. Listagem Completa de Instrumentos");
                Console.WriteLine("4. Listagem por fornecedores");
                Console.WriteLine("5. Listagem Completa Fornecedores");
                Console.WriteLine("6. Consulta de Instrumentos");
                Console.WriteLine("7. Sair");
                op = int.Parse(Console.ReadLine());

                switch (op) {
                        case 1:                            
                            Console.Write(" O instrumento é importado? [S/N:] ");
                            importado =Console.ReadLine();
                            if(importado.ToUpper() == "S") {
                                Console.Write(" Digite o valor do dólar: ");
                                valorDolar = decimal.Parse(Console.ReadLine());
                            }

                            Console.WriteLine(" Qual o Tipo do instrumento ");
                            Console.WriteLine("1. Corda");
                            Console.WriteLine("2. Percussão");
                            Console.WriteLine("3. Sopro");
                            tipo = int.Parse(Console.ReadLine());
                            if(tipo == 1) {
                                tipoInstru = "Corda";
                                if(importado.ToUpper() == "S") {                               
                                    Corda corda = new Corda(tipoInstru, valorDolar);
                                    corda.Entrada();
                                } else {
                                    Corda corda = new Corda(tipoInstru);
                                    corda.Entrada();
                                }                                                         
                                break;

                            } else if(tipo == 2) {
                                tipoInstru = "Percussão"; 
                                if(importado.ToUpper() == "S") {
                                    Percusao percu = new Percusao(tipoInstru, valorDolar);
                                    percu.Entrada();
                                } else {
                                    Percusao percu = new Percusao(tipoInstru);
                                    percu.Entrada();
                                }                                
                                break;

                            } else {
                                tipoInstru = "Sopro";
                                if(importado.ToUpper() == "S") {                                   
                                    Sopro sopro = new Sopro(tipoInstru, valorDolar);
                                    sopro.Entrada();
                                }else {
                                    Sopro sopro = new Sopro(tipoInstru);
                                    sopro.Entrada();
                                }                                
                                break;
                            }

                        case 2:                            
                            fornec.Cadastrar();
                            break;

                        case 3:
                            instru.Listar();
                            break;

                        case 4:
                            Console.Write(" Digite o nome do fornecedor: ");
                            nomeFornec = Console.ReadLine();
                            string aux2 = fornec.Procurar(nomeFornec);
                            if(aux2 == "") {
                                Console.WriteLine(" Fornecedor não encontrado.");
                                Console.ReadKey();
                            }
                            break;

                        case 5:
                            fornec.Listar();
                            break;  

                        case 6:
                            Console.Write(" Digite o modelo do instrumento: ");
                            modeloInstru = Console.ReadLine();
                            bool aux1 = instru.Consular(modeloInstru);
                            if(!aux1){
                                Console.WriteLine(" Instrumento não encontrado.");
                                Console.ReadKey();
                            }
                            break;                        
                    }
            } while(op != 7);
            
        }
    }
}
