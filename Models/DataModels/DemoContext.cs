using System;
using Microsoft.EntityFrameworkCore;

namespace LoginRegistration.Models
{
  public class DemoContext : DbContext
  {
    public DemoContext(DbContextOptions options) : base(options) { }

    public DbSet<Villain> Villains { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<EvilGroup> EvilGroups { get; set; }
    public DbSet<VillainEvilGroup> VillainEvilGroups { get; set; }

  }
}