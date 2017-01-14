using ReadAndWatchList.DataAccessLayer;
using ReadAndWatchList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReadAndWatchList.Repositories
{
    public class ReadingListRepository
    {
        private ReadAndWatchContext _db;
        public ReadingListRepository()
        {
            _db = new ReadAndWatchContext();
        }

        public IEnumerable<ReadingList> GetAll()
        {
            return _db.ReadingList.ToList();
        }

        public IEnumerable<ReadingListRow> GetAllRows()
        {
            return _db.ReadingListRow.ToList();
        }

        public IEnumerable<ReadingListRow> GetAllReadingListRows(int ReadingListId)
        {
            return _db.ReadingListRow.Where(e => e.ReadingListId == ReadingListId);
        }
        public ReadingList GetSpecifik(int? id)
        {

            if (id == null)
            {
                return null;
            }

            return _db.ReadingList.Find(id);
        }

        public ReadingListRow GetSpecifikRow(int? id)
        {

            if (id == null)
            {
                return null;
            }

            return _db.ReadingListRow.Find(id);
        }

        public void Create(ReadingList readingList)
        {

            _db.ReadingList.Add(readingList);
            _db.SaveChanges();
            //return true;
        }
        public void Edit(ReadingList readingList)
        {
            _db.Entry(readingList).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public bool Delete(int id)
        {
            ReadingList _readingList = GetSpecifik(id);
            if (_readingList != null)
            {

                _db.ReadingList.Remove(_readingList);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}