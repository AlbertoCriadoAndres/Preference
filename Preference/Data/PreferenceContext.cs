using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Preference.Models;

namespace Preference.Data
{
    public class PreferenceContext : DbContext
    {
        public PreferenceContext (DbContextOptions<PreferenceContext> options)
            : base(options)
        {
        }

        public DbSet<Preference.Models.Severity> Severity { get; set; }

        public DbSet<Preference.Models.Status> Status { get; set; }

        public DbSet<Preference.Models.Issue> Issue { get; set; }
    }
}
