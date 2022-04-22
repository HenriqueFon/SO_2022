using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO_Esteira
{
    class Program
    {
        static string filePath = "C:\\Users\\Noberto\\source\\repos\\SO_Esteira\\txt\\pedidos.txt";
        static void Main(string[] args)
        {
            int nPedidos = primeiraLinha(filePath);
            Pedido[] arrayDePedidos=new Pedido[nPedidos];
            int percorrer = 0;
            string[] texto = new string[2];
            //Lê todas as linhas do arquivo
            if (File.Exists(filePath))
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    int nProdutos, prazo;
                    string linha, nome;
                    while ((linha = file.ReadLine()) != null)
                    {
                        string remover = primeiraLinha(filePath).ToString();
                        if (String.Compare(linha, remover) == 0)
                        {
                            continue;
                        }
                        texto = linha.Split(';');
                        nome = texto[0];
                        nProdutos = Int32.Parse(texto[1]);
                        prazo = Int32.Parse(texto[2]);
                        arrayDePedidos[percorrer] = new Pedido(nome,nProdutos,prazo);
                        percorrer++;
                    }
                    file.Close();
                    //terminio da leitura do arquivo
                }
            }


            //Ordenar os arrays
            Ordenacao.Sort(arrayDePedidos);
            BracoMecanico.empacotar(arrayDePedidos);
        

            /*int resultado=0;
            for (int i = 0; i < arrayDePedidos.Length; i++)
            {
                resultado = resultado + arrayDePedidos[i].getnProdutos();
            }
            Console.WriteLine(resultado / 20);*/


           Console.ReadKey();
        }

        public static int primeiraLinha(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string primeiraString = lines[0];
            int primeiraLinha = Convert.ToInt32(primeiraString);
            return primeiraLinha;
        }

        
        /*public static void merge(Pedido[] arrayDePedidos, int left, int middle, int right)
        {
            //Transfere os elementos entre left e right para um array auxiliar
            int[] helper = new int[arrayDePedidos.Length];
            for(int contador = left; contador <= right; contador++)
            {
                helper[contador] = arrayDePedidos[contador].getPrazo();
            }
            //inicioMeio marca o início da primeira parte do array até o meio
            int inicioMeio = left;
            //meioFim marca o início da segunda parte do array até o fim
            int meioFim = middle + 1;
            //menor elemento entre a comparação dos arrays
            int contadorMenorElemento = left;

            while(inicioMeio <=middle && meioFim <= right)
            {
                if (helper[inicioMeio] < helper[meioFim]) { 
                    
                }
            }
        }
        public static void mergeSort(Pedido[]arrayDePedidos,int left,int right)
        {
            if (left < right)
            {
                int middle = ((left + right) / 2);
                mergeSort(arrayDePedidos, left, middle);
                mergeSort(arrayDePedidos, middle + 1, right);

                merge(arrayDePedidos, left, middle, right);
            }
            
        }*/
       
    }
}
