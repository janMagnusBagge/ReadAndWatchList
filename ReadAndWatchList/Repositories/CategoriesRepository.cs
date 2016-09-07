using ReadAndWatchList.DataAccessLayer;
using ReadAndWatchList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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