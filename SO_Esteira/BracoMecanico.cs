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
        private static int contadorPrazosNãoAtendidos = 0;//Conta pedidos que não foram atendidos dentro do prazo
        private static int tempoEmpacotamentoPedido = 0;//Conta o tempo de empacotamento do pedido
        private static int printarPacotesMeioDia = 0;
        private static int pedidosNaoAtendidos = 0;//variavel para mostrar quantos pedidos não foram atendidos se o tempo de empacotamento passar o permitido

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
                tempoEmpacotamentoPedido += esteiraMovendo;
            }
            pedidoFinalizado++;
            //Se existir um prazo no pedido e ele não for concluído a tempo, contador aumenta
            if (Array[i].getPrazo() != 0 && Array[i].getPrazo() < ((tempoEmpacotamentoPedido/60)/1000))//converte valor milisegundos para minutos
            {
                contadorPrazosNãoAtendidos++;
            }
            Console.WriteLine("Pedido Nº" + pedidoFinalizado + " finalizado no tempo:"+ horarioInicioExpediente);
        }
        
        public static void funcionar(Pedido[] Array)
        {
            //enquanto o galpão não fechar ou os pacotes não tiverem terminados de serem embalados
            while (i<tamanhoListaPedido)
            {
                if (horarioInicioExpediente > meioDia && contadorMeioDia == 0)
                {
                    printarPacotesMeioDia = pacotesEntregues;
                    contadorMeioDia++;
                }
                if (horarioInicioExpediente > horarioTerminioExpediente)
                {
                    pedidosNaoAtendidos = tamanhoListaPedido - pedidoFinalizado;//tamanho da lista de pedido - pedidos que foram entregues até o momento
                    Console.WriteLine("Pedidos não foram atendidos até a data limite. Faltaram:"+pedidosNaoAtendidos + " pedidos ");
                    break;
                }
                empacotar(Array, i);
                i++;
            }
            Console.WriteLine("Prazos não atendidos:" + contadorPrazosNãoAtendidos);
            Console.WriteLine("Pacotes embalados até meio dia " + printarPacotesMeioDia);
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
