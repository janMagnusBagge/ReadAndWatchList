using ReadAndWatchList.DataAccessLayer;
using ReadAndWatchList.Models;
using ReadAndWatchList.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReadAndWatchList.Repositories
{
    public class MoviesAndBooksRepository
    {
        private ReadAndWatchContext _db;
        public MoviesAndBooksRepository()
        {
            _db = new ReadAndWatchContext();
        }

        #region hämtaRader
        public IEnumerable<MoviesAndBooks> GetAll()
        {
            return _db.MovieAndBook.ToList();
            //return books;
        }

        public IEnumerable<MultipleUpdateMoviesAndBooksViewModel> GetAllMultipleUpdateViewModel()
        {
            return 
            from mab in _db.MovieAndBook
            join main in _db.Categorie on mab.MainCategoryId equals main.Id into mainCateJoin
            from mainCategory in mainCateJoin.DefaultIfEmpty()

            join sub in _db.SubCategorie on mab.SubCategoryId equals sub.Id into subCateJoin
            from subCategory in subCateJoin.DefaultIfEmpty()

            join grade in _db.Grade on mab.GradeId equals grade.Id into gradeJoin
            from subGrade in gradeJoin.DefaultIfEmpty()

            join serie in _db.Serie on mab.SerieId equals serie.Id into serieJoin
            from subSerie in serieJoin.DefaultIfEmpty()
            select new MultipleUpdateMoviesAndBooksViewModel
            {
                Id = mab.Id,
                Name = mab.Name,
                GradeId = mab.GradeId,
                Grade =  (subGrade == null ? String.Empty : subGrade.Name), //grade.Name,
                SerieId = mab.SerieId,
                SerieName = (subSerie == null ? String.Empty : subSerie.SerieName),//serie.SerieName,
                MainCategoryId = mab.MainCategoryId,
                MainCategoryName = (mainCategory == null ? String.Empty : mainCategory.Name),//main.Name,
                SubCategoriId = mab.SubCategoryId,
                SubCategoryName = (subCategory == null ? String.Empty : subCategory.Name),//sub.Name,
                UpdateThis = false
            };
            //return books;
        }

        public MoviesAndBooks GetSpecifik(int? id)
        {

            if (id == null)
            {
                return null;
            }

            return _db.MovieAndBook.Find(id);
        }
        #endregion
        #region CRUD
        #region skapaRader
        //ändra så att man returnerar true om man lyckades och få meddelande om det
        public void Create(MoviesAndBooks movieAndBook)
        {

            _db.MovieAndBook.Add(movieAndBook);
            _db.SaveChanges();
            //return true;
        }
        
        public void Create(string Name, string Description, string OtherPlatforms, int? GradeId, bool PartOffSerie, int? SerieId, int? MainCategoryId, int? SubCategoriId)
        {

            MoviesAndBooks _MoviesAndBooks = new MoviesAndBooks();
            _MoviesAndBooks.Name = Name;
            _MoviesAndBooks .Description = Description;
            _MoviesAndBooks.OtherPlatforms = OtherPlatforms;
            _MoviesAndBooks.GradeId = GradeId;
            _MoviesAndBooks.PartOffSerie = PartOffSerie;
            _MoviesAndBooks.SerieId = SerieId;
            _MoviesAndBooks.MainCategoryId = MainCategoryId;
            _MoviesAndBooks.SubCategoryId = SubCategoriId;
            Create(_MoviesAndBooks);
        }
        #endregion
        #region uppdatera
        public void Edit(MoviesAndBooks movieAndBook)
        {
            _db.Entry(movieAndBook).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Edit(int Id, string Name, string Description, string OtherPlatforms, int? GradeId, bool PartOffSerie, int? SerieId, int? MainCategoryId, int? SubCategoriId)
        {

            MoviesAndBooks _MoviesAndBooks = new MoviesAndBooks();
            _MoviesAndBooks.Id = Id;
            _MoviesAndBooks.Name = Name;
            _MoviesAndBooks.Description = Description;
            _MoviesAndBooks.OtherPlatforms = OtherPlatforms;
            _MoviesAndBooks.GradeId = GradeId;
            _MoviesAndBooks.PartOffSerie = PartOffSerie;
            _MoviesAndBooks.SerieId = SerieId;
            _MoviesAndBooks.MainCategoryId = MainCategoryId;
            _MoviesAndBooks.SubCategoryId = SubCategoriId;
            Edit(_MoviesAndBooks);
        }

        public bool UpdateMeny(List<int> ToUpdate, int? Grade, int? Serie, int? MainCategory = null, int? SubCategory = null)
        {
            var doSave = false;
            if(Grade == null && Serie == null && MainCategory == null && SubCategory == null)
            {
                return false;
            }
            foreach(var id in ToUpdate)
            {
                var rowToUpdate = GetSpecifik(id);
                if(rowToUpdate != null)
                {
                    rowToUpdate.GradeId = (Grade != null && Grade != 0 ? Grade : rowToUpdate.GradeId);
                    rowToUpdate.SerieId = (Serie != null && Serie != 0 ? Serie : rowToUpdate.SerieId);
                    rowToUpdate.MainCategoryId = (MainCategory != null && MainCategory != 0 ? MainCategory : rowToUpdate.MainCategoryId);
                    rowToUpdate.SubCategoryId = (SubCategory != null && SubCategory != 0 ? SubCategory : rowToUpdate.SubCategoryId);
                    _db.Entry(rowToUpdate).State = EntityState.Modified;
                    doSave = true;
                }
            }
            if(doSave)
                _db.SaveChanges();
            return true;
        }
        #endregion

        //kanske ska göra så att man returnerar bool
        //och sedan använda att man lyckades ta bort
        public bool Delete(int id)
        {
            MoviesAndBooks _movieAndBook = GetSpecifik(id);
            if (_movieAndBook != null)
            {
                _db.MovieAndBook.Remove(_movieAndBook);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

    }
}