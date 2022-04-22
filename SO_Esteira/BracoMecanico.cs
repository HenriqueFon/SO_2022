using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO_Esteira
{
    class BracoMecanico
    {
        private int horarioInicioExpediente = 28800;//8 horas em segundo
        private int meioDia = 43200;//meio dia em segundo
        private int horarioTerminioExpediente = 61200;//17 horas em segundo
        private static int pacotesEntregues = 1;
        private static int produtosPorCaixa = 20;//(5000/25)
        private static int pedidoFinalizado = 0;

        public int getPacotesEntregues()
        {
            return pacotesEntregues;
        }
        
        public static void empacotar(Pedido[]Array)
        {
            int tamanhoArray = Array.Length;
            for (int i = 0; i < tamanhoArray; i++)
            {
                double empacotando = Array[i].getnProdutos();
                while (empacotando != 0)
                {
                    if (empacotando < 20)
                    {
                        empacotando = 0;
                        Console.WriteLine("Pacotes gerados:" + pacotesEntregues++);
                        break;
                    }
                    empacotando -= produtosPorCaixa;
                    Console.WriteLine("Pacotes gerados:" + pacotesEntregues++);
                }
                pedidoFinalizado++;
                Console.WriteLine("Pedidos Finalizados:" + pedidoFinalizado);
            }
        }
        public static void Printar(Pedido[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].toString());
            }
        }
    }

}
