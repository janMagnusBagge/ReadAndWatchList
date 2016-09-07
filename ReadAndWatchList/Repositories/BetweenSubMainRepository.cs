using ReadAndWatchList.DataAccessLayer;
using ReadAndWatchList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReadAndWatchList.Repositories
{
    public class BetweenSubMainRepository
    {
        private ReadAndWatchContext _db;
        public BetweenSubMainRepository()
        {
            _db = new ReadAndWatchContext();
        }

        public IEnumerable<BetweenSubMainCategory> GetAll()
        {
            return _db.BetweenCategory.ToList();
            //return books;
        }

        public BetweenSubMainCategory GetSpecifik(int? id)
        {

            if (id == null)
            {
                return null;
            }

            return _db.BetweenCategory.Find(id);
        }

        //ändra så att man returnerar true om man lyckades och få meddelande om det
        public void Create(BetweenSubMainCategory betweenSubMain)
        {

            _db.BetweenCategory.Add(betweenSubMain);
            _db.SaveChanges();
            //return true;
        }
        public void Edit(BetweenSubMainCategory betweenSubMain)
        {
            _db.Entry(betweenSubMain).State = EntityState.Modified;
            _db.SaveChanges();
        }

        //kanske ska göra så att man returnerar bool
        //och sedan använda att man lyckades ta bort
        public bool Delete(int id)
        {
            BetweenSubMainCategory betweenSubMain = GetSpecifik(id);
            if (betweenSubMain != null)
            {
                _db.BetweenCategory.Remove(betweenSubMain);
                _db.SaveChanges();
                return true;
            }
            return false;
        }


    }
}