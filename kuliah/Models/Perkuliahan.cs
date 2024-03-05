using System.ComponentModel.DataAnnotations;

namespace kuliah.Models
{
    public class Perkuliahan
    {
        [Key]
        public int Nim { get; set; }
        public int Kode_MK { get; set; }
        public int Nip { get; set; }
        public string? Nilai { get; set; }

    }
}
