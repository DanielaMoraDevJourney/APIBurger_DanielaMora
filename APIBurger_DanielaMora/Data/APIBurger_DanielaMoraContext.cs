using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIBurger_DanielaMora.Data.Models;

namespace APIBurger_DanielaMora.Data
{
    public class APIBurger_DanielaMoraContext : DbContext
    {
        public APIBurger_DanielaMoraContext (DbContextOptions<APIBurger_DanielaMoraContext> options)
            : base(options)
        {
        }

        public DbSet<APIBurger_DanielaMora.Data.Models.Burger> Burger { get; set; } = default!;
    }
}
