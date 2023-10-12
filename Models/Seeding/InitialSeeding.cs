using Microsoft.EntityFrameworkCore;

namespace Api.Models.Seeding
{
  public class InitialSeeding
  {
    public static void Seed(ModelBuilder modelBuilder)
    {
      var fibraOptica = new Category { Id = 1, Name = "Fibra Optica" };
      var rack = new Category { Id = 2, Name = "Accesorios de Rack" };
      var utp = new Category { Id = 3, Name = "UTP" };
      var matElectricos = new Category { Id = 4, Name = "Materiales electricos" };
      var canalizacion = new Category { Id = 5, Name = "Canalizacion"};

      modelBuilder.Entity<Category>().HasData(fibraOptica, rack, utp, matElectricos, canalizacion);


      var metros = new Unit { Id = 1, Description = "Metros" };
      var cajas = new Unit { Id = 2, Description = "Cajas" };

      modelBuilder.Entity<Unit>().HasData(metros, cajas);
    }
  }
}
