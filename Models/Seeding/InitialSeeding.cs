using Microsoft.EntityFrameworkCore;

namespace Api.Models.Seeding
{
  public class InitialSeeding
  {
    public static void Seed(ModelBuilder modelBuilder)
    {
      var fibraOptica = new Category { Name = "Fibra Optica" };
      var rack = new Category { Name = "Accesorios de Rack" };
      var utp = new Category { Name = "UTP" };
      var matElectricos = new Category { Name = "Materiales electricos" };
      var canalizacion = new Category { Name = "Canalizacion"};

      modelBuilder.Entity<Category>().HasData(fibraOptica, rack, utp, matElectricos, canalizacion);
    }
  }
}
