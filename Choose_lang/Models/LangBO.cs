using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choose_lang.Models
{
  public  class LangBO
    {
        [PrimaryKey, AutoIncrement]
        public int ID
        { get; set; }
        public string Language
        { get; set; }
        public bool Read
        { get; set; }
        public bool Write
        { get; set; }
        public bool Speak
        { get; set; }
    }
}
