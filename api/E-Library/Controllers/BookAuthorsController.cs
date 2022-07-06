using ELibrary.DAL;
using ELibrary.DAL.Models;
using ELibrary.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.Controllers
{
    public class BookAuthorsController : ControllerBase
    {
        protected UnitOfWork UnitofWork { get; }

        public BookAuthorsController(UnitOfWork unitofWork)
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

        [Authorize(Roles = "admin")]
        public BookAuthorResponse? Create([FromBody] BookAuthor newAuthor)
        {
            var updatedBookAuthor = UnitofWork.BookAuthorRepository.Create(newAuthor.Name);
            UnitofWork.SaveChanges();

            return new BookAuthorResponse(updatedBookAuthor);
        }

        [Authorize(Roles = "admin")]
        public BookAuthorResponse? Update([FromBody]BookAuthor updatedAuthor)
        {
            var updatedBookAuthor = UnitofWork.BookAuthorRepository.Update(updatedAuthor.Id, updatedAuthor.Name);
            if (updatedBookAuthor == null)
                return null;

            UnitofWork.SaveChanges();

            return new BookAuthorResponse(updatedBookAuthor);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            UnitofWork.BookAuthorRepository.Delete(id);
            UnitofWork.SaveChanges();
            return Ok();
        }
    }
}