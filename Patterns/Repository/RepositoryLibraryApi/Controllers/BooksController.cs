using Microsoft.AspNetCore.Mvc;
using RepositoryData.Data.Interfaces;
using RepositoryData.Data.Model;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class BooksController: ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository) {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks() {
        return Ok(_bookRepository.GetAll());
    }
}