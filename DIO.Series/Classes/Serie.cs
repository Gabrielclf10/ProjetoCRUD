using System;
namespace DIO.Series.Filmes
{
    public class Serie : EntidadeBase
    {
        // Atributos
        private Genero Genero {get; set; } 
        public int Temporadas { get; set; }       

        // Métodos

        public Serie(int id, Genero genero, string titulo, string descricao, int ano, int temporadas)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Temporadas = temporadas;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Número de temporadas: " + this.Temporadas + Environment.NewLine;
            retorno += "Excluida: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public int retornaTemporadas()
        {
            return this.Temporadas;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}