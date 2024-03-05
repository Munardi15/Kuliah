using System.ComponentModel.DataAnnotations;

namespace kuliah.Models
{
    public class Marakuliah
    {
        [Key]
        public int Kode_MK { get; set; }
        public string? Nama_MK { get; set; }
        public string? Sks { get; set; }
    }
}
