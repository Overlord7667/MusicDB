using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDB
{
    public class Autor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
