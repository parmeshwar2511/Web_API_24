using CrudUsing_EF.Models;
using CrudUsing_EF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CrudUsing_EF.Controllers
{
    
    public class CategoryController : ApiController
    {
        ProductDbContext dbContext = new ProductDbContext();

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Category>))]
        public IHttpActionResult GetAll()
        {
            var categories = dbContext.categories.ToList();
            return Ok(categories);
        }

        [HttpGet]

        public IHttpActionResult GetById([FromUri] int? id)

        {
            if (id > 0)
            {
                Category category = dbContext.categories.Find(id);

                if (category != null)
                {
                    return Ok(category);//200
                }

                else
                {
                    return NotFound();  // 404
                }

            }
            return BadRequest("Category Id should be greter then 0");  // 400
        }

        [HttpPost]

        public IHttpActionResult Create([FromBody] Category category)
        {
            if (category != null)
            {
                dbContext.categories.Add(category);
                dbContext.SaveChanges();

                return Created("DefaultApi", category);
            }
            return BadRequest();  // 400
        }

        [HttpPut]
        public IHttpActionResult Update([FromUri] int? id, [FromBody] Category category)
        {
            if (id > 0)
            {
                if (id == category.Id)
                {
                    Category dbCategory = dbContext.categories.Find(id);

                    if (dbCategory != null)
                    {
                        dbCategory.Name = category.Name;
                        dbCategory.Rating = category.Rating;

                        dbContext.SaveChanges();

                        return Ok();   // 200
                    }
                    return NotFound();   // 404
                }
                return BadRequest();   // 400
            }
            return BadRequest();  // 400
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
          if (id > 0)
            {
                Category category = dbContext.categories.Find(id);

                if (category != null)
                {
                    dbContext.categories.Remove(category);
                    dbContext.SaveChanges();

                    return Ok();  // 200
                }
                return NotFound();   // 404
            }
            return BadRequest();    // 400
                
        }
    }
}
