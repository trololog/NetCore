using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryApi.Models;
using RepositoryApi.Repository.Interfaces;

namespace RepositoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController: ControllerBase
    {
        private readonly IBlogRepository _repository;

        public BlogController(IBlogRepository repository) {
            _repository = repository;

            if(_repository.GetAll().Count() == 0) {
                var blog = new Blog {
                                    BlogId=1,
                                    Url= "www.test.com",
                                    Posts = new List<Post> {
                                        new Post {
                                            PostId =1,
                                            Title = "Test",
                                            Content = "Test",
                                            BlogId = 1
                                        }
                                    }
                                };
                
                _repository.Create(blog);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetAllBlogs() {
            return await Task.Run(() => _repository.GetAllWithPost().ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id) {
            var blog = await Task.Run(() => _repository.GetById(id));

            if(blog==null)
                return NotFound();
            
            return blog;
        }


    }
}