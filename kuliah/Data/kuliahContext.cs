using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kuliah.Models;

namespace kuliah.Data
{
    public class kuliahContext : DbContext
    {
        public kuliahContext (DbContextOptions<kuliahContext> options)
            : base(options)
        {
        }

        public DbSet<kuliah.Models.Dosen> Dosen { get; set; } = default!;
        public DbSet<kuliah.Models.Mahasiswa> Mahasiswa { get; set; } = default!;
        public DbSet<kuliah.Models.Marakuliah> Marakuliah { get; set; } = default!;
        public DbSet<kuliah.Models.Perkuliahan> Perkuliahan { get; set; } = default!;
    }
}
