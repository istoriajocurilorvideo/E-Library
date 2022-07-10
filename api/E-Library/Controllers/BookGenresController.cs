using ELibrary.DAL;
using ELibrary.DAL.Models;
using ELibrary.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.Controllers
{
    public class BookGenresController : ControllerBase
    {
        protected UnitOfWork UnitofWork { get; }

        public BookGenresController(UnitOfWork unitofWork)
        {
            UnitofWork = unitofWork;
        }

        public BookGenreResponse? Get(int id)
        {
            var bookGenre = UnitofWork.BookGenreRepository.GetById(id);
            if (bookGenre == null)
                return null;

            return new BookGenreResponse(bookGenre);
        }

        public IEnumerable<BookGenreResponse> GetAll() => UnitofWork.BookGenreRepository.GetAll().Select(b => new BookGenreResponse(b));
        
        public IEnumerable<BookGenreSummaryResponse> GetSummary() => UnitofWork.BookGenreRepository.GetSummary().Select(x => new BookGenreSummaryResponse(new BookGenreResponse(x.Item1), x.Item2)).ToList();

        [Authorize(Roles = "admin")]
        public BookGenreResponse? Create([FromBody] BookGenre newGenre)
        {
            var updatedBookGenre = UnitofWork.BookGenreRepository.Create(newGenre.Name);
            UnitofWork.SaveChanges();

            return new BookGenreResponse(updatedBookGenre);
        }

        [Authorize(Roles = "admin")]
        public BookGenreResponse? Update([FromBody]BookGenre bookGenre)

        {
            var updatedBookGenre = UnitofWork.BookGenreRepository.Update(bookGenre.Id, bookGenre.Name);
            if (updatedBookGenre == null)
                return null;

            UnitofWork.SaveChanges();

            return new BookGenreResponse(updatedBookGenre);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            UnitofWork.BookGenreRepository.Delete(id);
            UnitofWork.SaveChanges();
            return Ok();
        }
    }
}