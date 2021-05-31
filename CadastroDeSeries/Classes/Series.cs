using CadastroDeSeries.Enums;
using System;

namespace CadastroDeSeries.Classes
{
    public class Series : BaseEntity
    {
        // Attributes
        private Genero Genero { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool isDeleted { get; set; }

        // Methods
        public Series(int id, Genero genero, string title, string description, int year)
        {
            this.Id = id;
            this.Genero = genero;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.isDeleted = false;
        }

        public override string ToString()
        {
            string textReturn = "";
            textReturn += "Gênero: " + this.Genero + Environment.NewLine;
            textReturn += "title: " + this.Title + Environment.NewLine;
            textReturn += "Descrição: " + this.Description + Environment.NewLine;
            textReturn += "Anp de Início: " + this.Year + Environment.NewLine;
            textReturn += "Excluido: " + this.isDeleted;
            return textReturn;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }
        public bool returnDelete()
        {
            return this.isDeleted;
        }
        public void Delete()
        {
            this.isDeleted = true;
        }
    }
}
