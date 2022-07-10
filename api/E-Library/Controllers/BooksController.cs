using ELibrary.DAL;
using ELibrary.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ELibrary.Controllers
{
    public class BooksController : ControllerBase
    {
        protected UnitOfWork UnitofWork { get; }

        public BooksController(UnitOfWork unitofWork)
        {
            UnitofWork = unitofWork;
        }

        public BookResponse? Get(int id)
        {
            var book = UnitofWork.BookRepository.GetById(id);
            if (book == null)
                return null;

            return new BookResponse(book);
        }

        public IEnumerable<BookResponse> GetAll() => UnitofWork.BookRepository.GetAll().Select(book => new BookResponse(book));

        public async Task<IActionResult> GetFile(int bookId)
        {
            var file = UnitofWork.BookFileRepository.GetById(bookId);
            if(file != null && file.FileContent?.Length > 0)
            {
                return File(file.FileContent, "application/pdf", file.FileType);
            }

            return NotFound();
        }

        public async Task<IActionResult> GetCover(int bookId)
        {
            var file = UnitofWork.BookFileRepository.GetById(bookId);
            if (file != null && file.CoverContent?.Length > 0)
            {
                return File(file.CoverContent, "image/jpeg", file.CoverType);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public BookResponse? Create([FromBody] BookRequest book)
        {
            var newBook = UnitofWork.BookRepository.Create(book.ISBN, book.Intro, book.Title, book.Description, book.Genres, book.Authors);
            if (newBook == null)
                return null;

            UnitofWork.SaveChanges();

            return new BookResponse(newBook);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public BookResponse? Update([FromBody]BookRequest book)
        {
            var updatedBook = UnitofWork.BookRepository.Update(book.Id, book.ISBN, book.Intro, book.Title, book.Description, book.Genres, book.Authors);
            if (updatedBook == null)
                return null;

            UnitofWork.SaveChanges();

            return new BookResponse(updatedBook);
        }

        [Authorize(Roles = "admin")]
        public BaseResponse UpdateFile(int bookId, IFormFile file)
        {
            if (file?.Length > 0)
            {
                using var stream = file.OpenReadStream();
                using var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                
                byte[] fileContent = memoryStream.ToArray();
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                
                UnitofWork.BookFileRepository.UpdateFile(bookId, fileContent, fileName);
                UnitofWork.SaveChanges();
            }
           
            return new BaseResponse() { IsOk = true };
        }

        [Authorize(Roles = "admin")]
        public BaseResponse UpdateCover(int bookId, IFormFile file)
        {
            if (file?.Length > 0)
            {
                using var stream = file.OpenReadStream();
                using var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);

                byte[] fileContent = memoryStream.ToArray();
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                UnitofWork.BookFileRepository.UpdateCover(bookId, fileContent, fileName);
                UnitofWork.SaveChanges();
            }

            return new BaseResponse() { IsOk = true };
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            UnitofWork.BookRepository.Delete(id);
            UnitofWork.SaveChanges();
            return Ok();
        }
    }
}