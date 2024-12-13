using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25_ELibrary.PreparForTable
{
    internal class Books
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public int YearOfRelease { get; set; }

        public string Author { get; set; }
        public string BookGenre {  get; set; }
        public List<Users> Users { get; set; }
    }
}
