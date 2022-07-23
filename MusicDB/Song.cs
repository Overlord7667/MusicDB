using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDB
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public List<Autor> Autors { get; set; } = new List<Autor>();
    }
}
