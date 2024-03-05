using System.ComponentModel.DataAnnotations;

namespace kuliah.Models
{
    public class Dosen
    {
        [Key]
        public int Nip { get; set; }
        public string? Nama_Dosen { get; set; }
    }
}
