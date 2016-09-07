using ReadAndWatchList.DataAccessLayer;
using ReadAndWatchList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadAndWatchList.Repositories
{
    public class GradesRepository
    {
        private ReadAndWatchContext _db;
        public GradesRepository()
        {
            _db = new ReadAndWatchContext();
        }

        public IEnumerable<Grades> GetAll()
        {
            return _db.Grade.ToList();
            //return books;
        }

        public Grades GetSpecifik(int? id)
        {

            if (id == null)
            {
                return null;
            }

            return _db.Grade.Find(id);
        }

        //ändra så att man returnerar true om man lyckades och få meddelande om det
        public void Create(Grades grade)
        {

            _db.Grade.Add(grade);
            _db.SaveChanges();
            //return true;
        }
        public void Edit(Grades grade)
        {
            _db.Entry(grade).State = EntityState.Modified;
            _db.SaveChanges();
        }

        //kanske ska göra så att man returnerar bool
        //och sedan använda att man lyckades ta bort
        public bool Delete(int id)
        {
            Grades _grade = GetSpecifik(id);
            if (_grade != null)
            {
                _db.Grade.Remove(_grade);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        
    }
}