using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO_Esteira
{
    class ListaPedidos
    {
        public ListaPedidos(string arquivo)
        {
            LerArquivo(arquivo);
        }

        private void LerArquivo(string arquivo)
        {
            int nPedidos = primeiraLinha(arquivo);
            Pedido[] arrayDePedidos = new Pedido[nPedidos];
            List<Pedido> pedidosOrdenados = new List<Pedido>();
            int percorrer = 0;
            string[] texto = new string[2];
            //Lê todas as linhas do arquivo
            if (File.Exists(arquivo))
            {
                using (StreamReader file = new StreamReader(arquivo))
                {
                    int nPacotes, prazo;
                    string linha, nome;
                    while ((linha = file.ReadLine()) != null)
                    {
                        string remover = primeiraLinha(arquivo).ToString();
                        if (String.Compare(linha, remover) == 0)
                        {
                            continue;
                        }
                        texto = linha.Split(';');
                        nome = texto[0];
                        nPacotes = Int32.Parse(texto[1]);
                        prazo = Int32.Parse(texto[2]);
                        arrayDePedidos[percorrer] = new Pedido(nome, nPacotes, prazo);
                        var pedido1 = new Pedido(nome, nPacotes, prazo);
                        pedidosOrdenados.Add(pedido1);
                        percorrer++;
                    }
                    file.Close();
                    //terminio da leitura do arquivo
                }
            }

        }
        private int primeiraLinha(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string primeiraString = lines[0];
            int primeiraLinha = Convert.ToInt32(primeiraString);
            return primeiraLinha;
        }
    }
}



