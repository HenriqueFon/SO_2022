using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO_Esteira
{
    class VetorPedidoAuxiliar
    {
		private string nome;
		private int nProdutos;
		private int prazo;
		

		//Construtor
		public VetorPedidoAuxiliar(string nome, int nProdutos, int prazo)
		{
			this.nome = nome;
			this.nProdutos = nProdutos;
			this.prazo = prazo;
		}

		//Getters
		public string getNome()
		{
			return nome;
		}
		public void setNome(string Nome)
		{
			this.nome = Nome;
		}
		public int getnProdutos()
		{
			return nProdutos;
		}
		public void setProdutos(int Produtos)
		{
			this.nProdutos = Produtos;
		}
		public int getPrazo()
		{
			return prazo;
		}
		public void setPrazo(int Prazo)
		{
			this.prazo = Prazo;
		}
		
		public string toString()
		{
			return "Nome:" + nome + " nPacotes:" + nProdutos + "Prazo:" + prazo;

		}
	}
}
