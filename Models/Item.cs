using System;

namespace apiinventory.Models
{
  public class Item
  {

    public int Id { get; set; }
    public string Name { get; set; }

    public string Discription { get; set; }

    public int NumberInStock { get; set; }

    public decimal  Price { get; set; }


    public float  sku { get; set; }

    public DateTime DateOrdered { get; set; }
  }
}