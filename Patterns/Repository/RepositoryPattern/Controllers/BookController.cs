using Microsoft.AspNetCore.Mvc;
using RepositoryData.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RepositoryData.Data.Interfaces;
using RepositoryData.Data.Model;

namespace RepositoryPattern.Controllers
{
    public class BookController: Controller
    {
        protected IBookRepository _repository;
        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        public IActionResult GetBooks()
        {
            var books = _repository.GetAll();

            return View(books);
        }

        public IActionResult GetBooksWithAuthor(string bookName) 
        {
             var books =  _repository.FindWithAuthor(b => b.Name == bookName);

            return View(books);
        }
    }
}