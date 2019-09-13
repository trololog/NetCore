using RepositoryPattern.Controllers;
using RepositoryData.Data;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RepositoryTests
{
    public class BookControllerTests
    {
        BookController _bookController;

        public BookControllerTests() {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
            optionsBuilder.UseInMemoryDatabase("LibraryContext");
            var _dbContext = new Mock<LibraryDbContext>(optionsBuilder).Object; 

            var repository = new BookRepositoryMock(_dbContext);
            _bookController = new BookController(repository);
        }

        [Fact]
        public void Get_Books_ReturnsOkResult() {
            var okResult = _bookController.GetBooks();

            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}