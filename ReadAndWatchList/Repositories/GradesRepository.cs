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

        public SelectList GetAllForSelectList()
        {
            SelectListViewModel item = new SelectListViewModel { Value = 0, Text = "Select to update to" };
            List<SelectListViewModel> items = new List<SelectListViewModel>();
            items.Add(item);
            items.AddRange(_db.Grade.Select(a => new SelectListViewModel { Value = a.Id, Text = a.Name }));

            SelectList returnSelect = new SelectList(items.Select(g => new { Value = g.Value, Text = g.Text }), "Value", "Text",0);

            return returnSelect;
            //return new SelectList(items.Select(g => new { Value = g.Id, Text = g.Name }), "Value", "Text", items.FirstOrDefault(e => e.Id == id));
            //return _db.Grade.ToList();
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