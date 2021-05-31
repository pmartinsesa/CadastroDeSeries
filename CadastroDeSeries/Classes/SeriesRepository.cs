using CadastroDeSeries.Interfaces;
using System.Collections.Generic;

namespace CadastroDeSeries.Classes
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> seriesList = new List<Series>();

        public void Create(Series serie)
        {
            seriesList.Add(serie);
        }

        public void Delete(int id)
        {
            seriesList[id].Delete();
        }

        public List<Series> List()
        {
            return seriesList;
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public Series ReturnById(int id)
        {
            return seriesList[id];
        }

        public void Update(int id, Series serie)
        {
            seriesList[id] = serie;
        }
    }
}
