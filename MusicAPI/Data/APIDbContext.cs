using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAPI.Data
{
    public class APIDbContext : DbContext
    {
        public DbSet<SongModel> Songs { get; set; }

        public APIDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
