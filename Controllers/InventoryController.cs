using System.Linq;
using Microsoft.AspNetCore.Mvc;
using apiinventory.Models;

namespace apiinventory.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class InventoryController : ControllerBase
  {

    [HttpGet]
    public ActionResult GetAllitems()
    {
     
      var db = new DatabaseContext();
      return Ok(db.Items.OrderBy(item => item.Name));
    }
    [HttpGet("{id}")]
    public ActionResult GetOneItem(int id)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(it => it.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(item);
      }
    }


    [HttpPost]
    public ActionResult CreateItem(Item item)
    {
      var db = new DatabaseContext();
      db.Items.Add(item);
      db.SaveChanges();
      return Ok(item);
    }

      [HttpGet("sku/{sku}")]
       public ActionResult GetOneItem(float sku)
       {
         var db = new DatabaseContext();
         var item = db.Items.FirstOrDefault(it => it.sku == sku);
         if (item == null)
         {
           return NotFound();
         }
         else
         {
           return Ok(item);
         }
       } 


    [HttpGet("outofstock")]

    public ActionResult GetOutOfStockitems()
    {
      var db = new DatabaseContext();
      var items = db.Items.Where(item => item.NumberInStock == 0);
      return Ok(items);
    }




    [HttpPut("{id}")]
    public ActionResult UpdateItem(Item item)
    {
      var db = new DatabaseContext();
      var prevItem = db.Items.FirstOrDefault(it => it.Id == item.Id);
      if (prevItem == null)
      {
        return NotFound();
      }
      else
      {
        prevItem.Name = item.Name;
        prevItem.Discription = item.Discription;
        prevItem.NumberInStock = item.NumberInStock;
        prevItem.Price = item.Price;
        prevItem.DateOrdered = item.DateOrdered;
        prevItem.sku = item.sku;
        db.SaveChanges();
        return Ok(prevItem);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult DeleteItem(int id)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(st => st.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        db.Items.Remove(item);
        db.SaveChanges();
        return Ok();
      }

    }

  }
}