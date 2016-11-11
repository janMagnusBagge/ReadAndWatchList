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
    public class SubCategoriesRepository
    {
        private ReadAndWatchContext _db;
        public SubCategoriesRepository()
        {
            _db = new ReadAndWatchContext();
        }

        public IEnumerable<SubCategories> GetAll()
        {
            return _db.SubCategorie.ToList();
            //return books;
        }
        public SelectList GetAllForSelectList()
        {
            SelectListViewModel item = new SelectListViewModel { Value = 0, Text = "Select category to update to" };
            List<SelectListViewModel> items = new List<SelectListViewModel>();
            items.Add(item);
            items.AddRange(_db.SubCategorie.Select(a => new SelectListViewModel { Value = a.Id, Text = a.Name }));

            SelectList returnSelect = new SelectList(items.Select(g => new { Value = g.Value, Text = g.Text }), "Value", "Text", 0);

            return returnSelect;
        }
        public SubCategories GetSpecifik(int? id)
        {

            if (id == null)
            {
                return null;
            }

            return _db.SubCategorie.Find(id);
        }

        //ändra så att man returnerar true om man lyckades och få meddelande om det
        public void Create(SubCategories subCategorie)
        {

            _db.SubCategorie.Add(subCategorie);
            _db.SaveChanges();
            //return true;
        }
        public void Edit(SubCategories subCategorie)
        {
            _db.Entry(subCategorie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        //kanske ska göra så att man returnerar bool
        //och sedan använda att man lyckades ta bort
        public bool Delete(int id)
        {
            SubCategories _subCategorie = GetSpecifik(id);
            if (_subCategorie != null)
            {
                _db.SubCategorie.Remove(_subCategorie);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}