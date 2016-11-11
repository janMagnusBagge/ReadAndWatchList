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
    public class CategoriesRepository
    {
        private ReadAndWatchContext _db;
        public CategoriesRepository()
        {
            _db = new ReadAndWatchContext();
        }

        public IEnumerable<Categories> GetAll()
        {
            return _db.Categorie.ToList();
            //return books;
        }

        public SelectList GetAllForSelectList()
        {
            SelectListViewModel item = new SelectListViewModel { Value = 0, Text = "Select category to update to" };
            List<SelectListViewModel> items = new List<SelectListViewModel>();
            items.Add(item);
            items.AddRange(_db.Categorie.Select(a => new SelectListViewModel { Value = a.Id, Text = a.Name }));

            SelectList returnSelect = new SelectList(items.Select(g => new { Value = g.Value, Text = g.Text }), "Value", "Text", 0);

            return returnSelect;
        }

        public Categories GetSpecifik(int? id)
        {

            if (id == null)
            {
                return null;
            }

            return _db.Categorie.Find(id);
        }

        //ändra så att man returnerar true om man lyckades och få meddelande om det
        public void Create(Categories categorie)
        {

            _db.Categorie.Add(categorie);
            _db.SaveChanges();
            //return true;
        }
        public void Edit(Categories categorie)
        {
            _db.Entry(categorie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        //kanske ska göra så att man returnerar bool
        //och sedan använda att man lyckades ta bort
        public bool Delete(int id)
        {
            Categories _categorie = GetSpecifik(id);
            if (_categorie != null)
            {
                _db.Categorie.Remove(_categorie);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
    
}