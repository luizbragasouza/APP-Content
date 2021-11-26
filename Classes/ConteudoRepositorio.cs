using System;
using System.Collections.Generic;
using Conteudo.Interfaces;

namespace Conteudo
{
	public class ConteudoRepositorio : IRepositorio<Conteudo>
	{
    private List<Conteudo> listaConteudo = new List<Conteudo>();
		public void Atualiza(int id, Conteudo objeto)
		{
			listaConteudo[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaConteudo[id].Excluir();
		}

		public void Insere(Conteudo objeto)
		{
			listaConteudo.Add(objeto);
		}

		public List<Conteudo> Lista()
		{
			return listaConteudo;
		}

		public int ProximoId()
		{
			return listaConteudo.Count;
		}

		public Conteudo RetornaPorId(int id)
		{
			return listaConteudo[id];
		}
	}
}