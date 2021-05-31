using CadastroDeSeries.Classes;
using CadastroDeSeries.Enums;
using System;

namespace CadastroDeSeries
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
			string userOption = getUserOption();

			while (userOption.ToUpper() != "X")
			{
				switch (userOption)
				{
					case "1":
						listSeries();
						break;
					case "2":
						createNewSerie();
						break;
					case "3":
						updateSerie();
						break;
					case "4":
						deleteSerie();
						break;
					case "5":
						visualizeSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userOption = getUserOption();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void deleteSerie()
		{
			Console.Write("Digite o id da série: ");
			int serieIndex = int.Parse(Console.ReadLine());

			repository.Delete(serieIndex);
		}

		private static void visualizeSerie()
		{
			Console.Write("Digite o id da série: ");
			int serieIndex = int.Parse(Console.ReadLine());

			var serie = repository.ReturnById(serieIndex);

			Console.WriteLine(serie);
		}

		private static void updateSerie()
		{
			Console.Write("Digite o id da série: ");
			int serieIndex = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Series atualizaSerie = new Series(id: serieIndex,
										genero: (Genero)entradaGenero,
										title: entradaTitulo,
										year: entradaAno,
										description: entradaDescricao);

			repository.Update(serieIndex, atualizaSerie);
		}
		private static void listSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repository.List();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.returnDelete();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void createNewSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Series novaSerie = new Series(id: repository.NextId(),
										genero: (Genero)entradaGenero,
										title: entradaTitulo,
										year: entradaAno,
										description: entradaDescricao);

			repository.Create(novaSerie);
		}

		private static string getUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
	}
}