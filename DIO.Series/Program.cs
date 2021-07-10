using System;
using System.Collections;

namespace DIO.Series.Filmes
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();          

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        opcaoUsuario = ObterOpcaoUsuarioSerie();                      
                        while (opcaoUsuario.ToUpper() != "X")
                            {
                                switch (opcaoUsuario)
                                {
                                    case "1":                   
                                        ListarSeries();
                                        break;                                 
                                    case "2":
                                        InserirSerie();
                                        break;
                                    case "3":
                                        AtualizarSerie();
                                        break;
                                    case "4":
                                        ExcluirSerie();
                                        break;
                                    case "5":
                                        VizualizarSerie();
                                        break;
                                    case "C":
                                        Console.Clear();
                                        break;

                                    default:
                                        Console.WriteLine("Erro: Opção Inválida.");
                                        break;                       
                                        //throw new ArgumentOutOfRangeException();     
                                }
                                opcaoUsuario = ObterOpcaoUsuarioSerie();
                                Console.WriteLine();
                            }
                        break;                                 
                    case "2":
                        opcaoUsuario = ObterOpcaoUsuarioFilme(); 
                        while (opcaoUsuario.ToUpper() != "X")
                            {
                                switch (opcaoUsuario)
                                {
                                    case "1":                   
                                        ListarFilmes();
                                        break;                                 
                                    case "2":
                                        InserirFilme();
                                        break;
                                    case "3":
                                        AtualizarFilme();
                                        break;
                                    case "4":
                                        ExcluirFilme();
                                        break;
                                    case "5":
                                        VizualizarFilme();
                                        break;
                                    case "C":
                                        Console.Clear();
                                        break;

                                    default:
                                        Console.WriteLine("Erro: Opção Inválida.");
                                        break;                       
                                        //throw new ArgumentOutOfRangeException();     
                                }
                                opcaoUsuario = ObterOpcaoUsuarioFilme();
                                Console.WriteLine();
                            }
                        break;

                    case "3":
                        Creditos();
                        break;

                    default:
                        Console.WriteLine("Erro: Opção Inválida.");
                        break;                       
                        //throw new ArgumentOutOfRangeException();                       
                }
                opcaoUsuario = ObterOpcaoUsuario();
                Console.WriteLine();
            }  
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorioSerie.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} - {2} - {3}.", serie.retornaId(),
                                                                 serie.retornaTitulo(),
                                                                 serie.retornaTemporadas() + " Temporada(s)",
                                                                 (excluido ? "[Excluído]" : "[Disponível]") );
            }
            Console.WriteLine();
        }       

        private static void InserirSerie()
        {
            
            Console.WriteLine("Inserir nova série");           

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Escolha o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTítulo = Console.ReadLine();

            Console.WriteLine("Insira o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Escreva a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Insira a quantidade de Temporadas da Série: ");
            int entradaTemporadas = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTítulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        temporadas: entradaTemporadas);

            repositorioSerie.Insere(novaSerie);
             Console.WriteLine();                           
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar série");
            Console.WriteLine("Digite o ID da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Escolha o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTítulo = Console.ReadLine();

            Console.WriteLine("Insira o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Escreva a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Insira a quantidade de Temporadas da Série: ");
            int entradaTemporadas = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTítulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        temporadas: entradaTemporadas);

            repositorioSerie.Atualiza(indiceSerie, novaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            repositorioSerie.Exclui(indiceSerie);
            Console.WriteLine();
        }

        private static void VizualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorId(indiceSerie);
            Console.WriteLine();
            Console.WriteLine(serie);

        }
        // -----------------Filmes--------------

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar Filmes");

            var lista = repositorioFilme.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }
            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} - {2} - {3}.", filme.retornaId(),
                                                                 filme.retornaTitulo(),
                                                                 filme.retornaDuracao() + " hrs.",
                                                                 (excluido ? "[Excluído]" : "[Disponível]") );
            }
            Console.WriteLine();
        }       
         private static void InserirFilme()
        {
            
            Console.WriteLine("Inserir novo Filme");           

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Escolha o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do Filme: ");
            string entradaTítulo = Console.ReadLine();

            Console.WriteLine("Insira o Ano de início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Escreva a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Insira a duração do Filme: ");
            double entradaDuracao = int.Parse(Console.ReadLine());

            Filme novoFilme = new Filme(id: repositorioSerie.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTítulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        duracao: entradaDuracao);

            repositorioFilme.Insere(novoFilme);
             Console.WriteLine();                           
        }

        private static void AtualizarFilme()
        {
            Console.WriteLine("Atualizar Filme");
            Console.WriteLine("Digite o ID do Filme");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Escolha o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título do Filme: ");
            string entradaTítulo = Console.ReadLine();

            Console.WriteLine("Insira o Ano de início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Escreva a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Insira a duração do Filme (horas inteiras): ");
            double entradaDuracao = int.Parse(Console.ReadLine());

            Filme novoFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTítulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        duracao: entradaDuracao);

            repositorioFilme.Atualiza(indiceFilme, novoFilme);
        }

        private static void ExcluirFilme()
        {
            Console.WriteLine("Digite o ID do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            
            repositorioSerie.Exclui(indiceFilme);
            Console.WriteLine();
        }

        private static void VizualizarFilme()
        {
            Console.WriteLine("Digite o ID do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);
            Console.WriteLine();
            Console.WriteLine(filme);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo(a)!!!");
            Console.WriteLine("Informe a opção desejada.");

            Console.WriteLine("1- Aba de Séries.");
            Console.WriteLine("2- Aba de Filmes.");
            Console.WriteLine("3- Créditos.");
            
            Console.WriteLine("X- Sair.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }

        private static string ObterOpcaoUsuarioSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Página de Séries!!!");
            Console.WriteLine("Informe a opção desejada.");

            Console.WriteLine("1- Listar séries.");
            Console.WriteLine("2- Inserir nova série.");
            Console.WriteLine("3- Atualizar série.");
            Console.WriteLine("4- Excluir série.");
            Console.WriteLine("5- Vizualizar informações da série.");
            Console.WriteLine("C- Limpar tela.");
            Console.WriteLine("X- Voltar.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
        private static string ObterOpcaoUsuarioFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Página de Filmes!!!");
            Console.WriteLine("Informe a opção desejada.");

            Console.WriteLine("1- Listar filmes.");
            Console.WriteLine("2- Inserir novo filme.");
            Console.WriteLine("3- Atualizar filme.");
            Console.WriteLine("4- Excluir filme.");
            Console.WriteLine("5- Vizualizar informações do filme.");
            Console.WriteLine("C- Limpar tela.");
            Console.WriteLine("X- Voltar.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }

        private static void Creditos()
        {
            Console.WriteLine();
            Console.WriteLine("Codigo Original: Dev Eliézer Zarpelão - DigitalInnovationOne [Bootcamp GFT START #2 .NET].");
            Console.WriteLine("Implementações no Projeto: Gabriel Claudino Leão Feitosa - Data: 10/07/2021.");
            Console.WriteLine();
        }

    }
}
