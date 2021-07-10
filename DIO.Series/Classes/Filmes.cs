using System;
namespace DIO.Series.Filmes
{
    public class Filme : EntidadeBase
    {
        private Genero Genero {get; set; } 
        public double Duracao { get; set; }

        public Filme(int id, Genero genero, string titulo, string descricao, int ano, double duracao)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Duracao = duracao;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Duração do filme: " + this.Duracao + Environment.NewLine;
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
        public double retornaDuracao()
        {
            return this.Duracao;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }


    }
}