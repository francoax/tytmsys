﻿namespace Api.Models
{
  public class Item : ModelBase
  {
    public string Name { get; set; } = null!;
    public List<ItemSupplier> ItemsSuppliers { get; set; } = new List<ItemSupplier>();
    public int UnitId { get; set; }
    public Unit Unit { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public List<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
  }
}
