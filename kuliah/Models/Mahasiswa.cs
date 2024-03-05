using System.ComponentModel.DataAnnotations;

namespace kuliah.Models
{
    public class Mahasiswa
    {
        [Key]
        public int Nim { get; set; }
        public string? Nama_Msh { get; set; }

        [DataType(DataType.Date)]
        public DateTime Tgl_Lahir { get; set; }
        public string? Alamat { get; set; }
        public string? Jenis_Kelamin { get; set; }
    }
}
