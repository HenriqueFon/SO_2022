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
            Pedido[] ArrayDePedidos=new Pedido[nPedidos];
            BracoMecanico.setTamanhoListaPedido(nPedidos);
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
                        ArrayDePedidos[percorrer] = new Pedido(nome, nProdutos, prazo);
                        percorrer++;
                    }
                    file.Close();
                    //terminio da leitura do arquivo
                }
            }
            //Ordenar os arrays
            Ordenacao.Sort(ArrayDePedidos);
            BracoMecanico.funcionar(ArrayDePedidos);
            Console.WriteLine("Trabalho Prático parte 1 feito por Henrique Fonseca Araújo e Ferlanio Duarte");
            Console.ReadKey();
        }
        public static int primeiraLinha(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string primeiraString = lines[0];
            int primeiraLinha = Convert.ToInt32(primeiraString);
            return primeiraLinha;
        }
    }
}
