using System;

namespace Conteudo
{
    class Program
    {
        static ConteudoRepositorio repositorio = new ConteudoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarConteudo();
						break;
					case "2":
						InserirConteudo();
						break;
					case "3":
						AtualizarConteudo();
						break;
					case "4":
						ExcluirConteudo();
						break;
					case "5":
						VisualizarConteudo();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirConteudo()
		{
			Console.Write("Digite o id da conteúdo: ");
			int indiceConteudo = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceConteudo);
		}

        private static void VisualizarConteudo()
		{
			Console.Write("Digite o id da conteúdo: ");
			int indiceConteudo = int.Parse(Console.ReadLine());

			var conteudo = repositorio.RetornaPorId(indiceConteudo);

			Console.WriteLine(conteudo);
		}

        private static void AtualizarConteudo()
		{
			Console.Write("Digite o id da conteúdo: ");
			int indiceConteudo = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da conteúdo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da conteúdo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da conteúdo: ");
			string entradaDescricao = Console.ReadLine();

			Conteudo atualizaConteudo = new Conteudo(id: indiceConteudo,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										tipo: (Tipo)entradaTipo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceConteudo, atualizaConteudo);
		}
        private static void ListarConteudo()
		{
			Console.WriteLine("Listar conteúdos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma conteúdo cadastrada.");
				return;
			}

			foreach (var conteudo in lista)
			{
                var excluido = conteudo.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} - {2} {3}", conteudo.retornaId(), conteudo.retornaTipo(), conteudo.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirConteudo()
		{
			Console.WriteLine("Inserir novo conteúdo");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
				foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da conteúdo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da conteúdo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da conteúdo: ");
			string entradaDescricao = Console.ReadLine();

			Conteudo novoConteudo = new Conteudo(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										tipo: (Tipo)entradaTipo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoConteudo);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO conteúdos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar conteúdos");
			Console.WriteLine("2- Inserir novo conteúdo");
			Console.WriteLine("3- Atualizar conteúdo");
			Console.WriteLine("4- Excluir conteúdo");
			Console.WriteLine("5- Visualizar conteúdo");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
