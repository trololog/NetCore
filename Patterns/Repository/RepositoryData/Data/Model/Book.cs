using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryData.Data.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("AuthorId")]
        public IEnumerable<Author> Authors {get; set;}

        [ForeignKey("BorrowerId")]
        public IEnumerable<Borrower> Borrowers {get;set;}
    }
}