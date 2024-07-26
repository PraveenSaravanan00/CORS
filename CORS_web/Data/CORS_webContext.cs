    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using CORS_web.Model;

namespace CORS_web.Data
{
    public class CORS_webContext : DbContext
    {
        public CORS_webContext (DbContextOptions<CORS_webContext> options)
            : base(options)
        {
        }

        public DbSet<CORS_web.Model.login> login { get; set; } = default!;
        public DbSet<CORS_web.Model.register> register { get; set; } = default!;
    }
}
