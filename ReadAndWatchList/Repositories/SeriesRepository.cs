using ReadAndWatchList.DataAccessLayer;
using ReadAndWatchList.Models;
using ReadAndWatchList.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public SelectList GetAllForSelectList()
        {
            SelectListViewModel item = new SelectListViewModel { Value = 0, Text = "Select serie to update to" };
            List<SelectListViewModel> items = new List<SelectListViewModel>();
            items.Add(item);
            items.AddRange(_db.Serie.Select(a => new SelectListViewModel { Value = a.Id, Text = a.SerieName }));

            SelectList returnSelect = new SelectList(items.Select(g => new { Value = g.Value, Text = g.Text }), "Value", "Text", 0);

            return returnSelect;
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