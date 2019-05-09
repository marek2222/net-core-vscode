using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using booklist.Models;

    public class FilmyContext : DbContext
    {
        public FilmyContext (DbContextOptions<FilmyContext> options)
            : base(options)
        {
        }

        public DbSet<booklist.Models.Book> Book { get; set; }
    }
