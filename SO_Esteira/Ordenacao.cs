using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO_Esteira
{
    class Ordenacao
    {
        public static void Sort(Pedido[]array)
        {
            int tamanhoArray = array.Length;
            VetorPedidoAuxiliar Auxiliar;


            for (int percorrer=0;percorrer<= tamanhoArray; percorrer++)
            {
                for(int j = 0; j+1 < tamanhoArray; j++)
                {
                    if (array[j].getnProdutos() > array[j+1].getnProdutos())
                    {
                        //Salva em uma variável auxiliar o valor que será substituido pelo menor objeto
                        Auxiliar = new VetorPedidoAuxiliar(array[j].getNome(), array[j].getnProdutos(), array[j].getPrazo());
                        array[j] = new Pedido(array[j + 1].getNome(), array[j + 1].getnProdutos(), array[j + 1].getPrazo());
                        array[j + 1] = new Pedido(Auxiliar.getNome(), Auxiliar.getnProdutos(), Auxiliar.getPrazo());
                        
                    }
                }  
            }
            
        }
        public static void Printar(Pedido[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].toString());
            }
        }

     
    }

}
