using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace NotasDaFacul.Server.Data
{
    public class GradesContext : DbContext
    {
        public GradesContext(DbContextOptions<GradesContext> options)
            : base(options)
        {
        }

        public DbSet<NotasDaFacul.Server.Models.GradesModel> GradesModel { get; set; } = default!;
    }
}
