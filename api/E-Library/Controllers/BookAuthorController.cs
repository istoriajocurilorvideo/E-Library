using ELibrary.DAL;
using ELibrary.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.Controllers
{
    public class BookAuthorController : ControllerBase
    {
        protected UnitOfWork UnitofWork { get; }

        public BookAuthorController(UnitOfWork unitofWork)
        {
            UnitofWork = unitofWork;
        }

        public BookAuthorResponse? Get(int id)
        {
            var bookAuthor = UnitofWork.BookAuthorRepository.GetById(id);
            if (bookAuthor == null)
                return null;

            return new BookAuthorResponse(bookAuthor);
        }

        public IEnumerable<BookAuthorResponse> GetAll() => UnitofWork.BookAuthorRepository.GetAll().Select(b => new BookAuthorResponse(b));

        public IEnumerable<BookAuthorSummaryResponse> GetSummary() => UnitofWork.BookAuthorRepository.GetSummary().Select(x => new BookAuthorSummaryResponse(new BookAuthorResponse(x.Item1), x.Item2)).ToList();

        public BookAuthorResponse? Update(int id, string name)
        {
            var updatedBookAuthor = UnitofWork.BookAuthorRepository.Update(id, name);
            if (updatedBookAuthor == null)
                return null;

            UnitofWork.SaveChanges();

            return new BookAuthorResponse(updatedBookAuthor);
        }

        public IActionResult Delete(int id)
        {
            UnitofWork.BookGenreRepository.Delete(id);
            UnitofWork.SaveChanges();
            return Ok();
        }
    }
}