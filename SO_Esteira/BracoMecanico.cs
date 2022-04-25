using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO_Esteira
{
    class BracoMecanico
    {
        private static double horarioInicioExpediente = 28800000;//8 horas em milisegundos
        private static double meioDia = 43200000;//meio dia em milisegundos
        private static double horarioTerminioExpediente = 61200000;//17 horas em milisegundos
        private static int esteiraMovendo = 5500;//5,5 segundos em milisegundos
        private static int pacotesEntregues = 1;
        private static int produtosPorCaixa = 20;//(5000/25)
        private static int pedidoFinalizado = 0;
        private static int tamanhoListaPedido = 0;
        private static int i = 0;
        private static int contadorMeioDia = 0;
        private static int getPacotesEntregues()
        {
            return pacotesEntregues;
        }
        private static int getPedidoFinalizado()
        {
            return pedidoFinalizado;
        }
        private static int getTamanhoListaPedido()
        {
            return tamanhoListaPedido;
        }
        public static void setTamanhoListaPedido(int tamanho)
        {
            tamanhoListaPedido = tamanho;
        }

        private static void empacotar(Pedido[] Array, int i)
        {
            double empacotando = Array[i].getnProdutos();
            while (empacotando != 0)
            {
                if (empacotando < 20)
                {
                    empacotando = 0;
                    break;
                }

                empacotando -= produtosPorCaixa;
                pacotesEntregues++;
                horarioInicioExpediente += esteiraMovendo;
            }
            pedidoFinalizado++;
        }

        public static void funcionar(Pedido[] Array)
        {
            //enquanto o galpão não fechar ou os pacotes não tiverem terminados de serem embalados
            while (i<tamanhoListaPedido)
            {
                if (horarioInicioExpediente > meioDia && contadorMeioDia == 0)
                {
                    Console.WriteLine("Até o meio dia foram entregues " + pacotesEntregues);
                    contadorMeioDia++;
                }
                empacotar(Array, i);
                i++;
            }
            Console.WriteLine(horarioInicioExpediente);
        }
       
        

        private static double ConverterParaHoras(double tempo)
        {
            double resultado = (tempo / 1000);
            return resultado = (resultado / 3600);
        }
        private static void printarResultados()
        {
            Console.WriteLine("Número de pacotes gerados:"+getPacotesEntregues());
            Console.WriteLine("Número de pedidos finalizados:"+getPedidoFinalizado());
        }
        private static string produtosRestantes()
        {

            return "Pedidos não atendidos:" + (tamanhoListaPedido - getPedidoFinalizado());
                
        }
    }

}
