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
		private int nPacotes;
		private int prazo;

		//Construtor
		public VetorPedidoAuxiliar(string nome, int nPacotes, int prazo)
		{
			this.nome = nome;
			this.nPacotes = nPacotes;
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
		public int getnPacotes()
		{
			return nPacotes;
		}
		public void setPacotes(int Pacotes)
		{
			this.nPacotes = Pacotes;
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
			return "Nome:" + nome + " nPacotes:" + nPacotes + "Prazo:" + prazo;

		}
	}
}
