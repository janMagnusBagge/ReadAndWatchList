using ReadAndWatchList.DataAccessLayer;
using ReadAndWatchList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReadAndWatchList.Repositories
{
    public class SeriesRepository
    {
        private ReadAndWatchContext _db;
        public SeriesRepository()
        {
            _db = new ReadAndWatchContext();
        }

        public IEnumerable<Series> GetAll()
        {
            return _db.Serie.ToList();
            //return books;
        }

        public Series GetSpecifik(int? id)
        {

            if (id == null)
            {
                return null;
            }

            return _db.Serie.Find(id);
        }

        //ändra så att man returnerar true om man lyckades och få meddelande om det
        public void Create(Series Serie)
        {

            _db.Serie.Add(Serie);
            _db.SaveChanges();
            //return true;
        }
        public void Edit(Series Serie)
        {
            _db.Entry(Serie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        //kanske ska göra så att man returnerar bool
        //och sedan använda att man lyckades ta bort
        public bool Delete(int id)
        {
            Series _serie = GetSpecifik(id);
            if (_serie != null)
            {
                _db.Serie.Remove(_serie);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}