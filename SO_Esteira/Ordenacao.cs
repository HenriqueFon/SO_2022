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
            ArrayList pedidos = new ArrayList();
            int tamanhoArray = array.Length;
            VetorPedidoAuxiliar Auxiliar;


            for (int percorrer=0;percorrer<= tamanhoArray; percorrer++)
            {
                for(int j = 0; j+1 < tamanhoArray; j++)
                {
                    if (array[j].getnPacotes() > array[j+1].getnPacotes())
                    {
                        //Salva em uma variável auxiliar o valor que será substituido pelo menor objeto
                        Auxiliar = new VetorPedidoAuxiliar(array[j].getNome(), array[j].getnPacotes(), array[j].getPrazo());
                        array[j] = new Pedido(array[j + 1].getNome(), array[j + 1].getnPacotes(), array[j + 1].getPrazo());
                        array[j + 1] = new Pedido(Auxiliar.getNome(), Auxiliar.getnPacotes(), Auxiliar.getPrazo());
                        
                    }
                }
               
                
                
            }
            Printar(array);
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
