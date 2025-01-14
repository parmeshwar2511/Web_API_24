using CrudUsing_EF.Models;
using CrudUsing_EF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CrudUsing_EF.Controllers
{
    public class CategoryV2Controller : ApiController
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
        [ResponseType(typeof(Category))]

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

        //manage api for create / update/ delete category
        [HttpPost]
        public IHttpActionResult Manage(Category category)
        {
            if (category.IsCreate && category.IsUpdate &&
                  category.IsDelete)
            {
                return BadRequest("create / update / delete all operations not allowed at same time");
            }
            else if (!category.IsCreate && !category.IsUpdate &&
                  !category.IsDelete)
            {
                return BadRequest(" at least create / update / delete all operations mandatory at a time");
            }

            else if (category.IsCreate && category.IsUpdate &&
                 !category.IsDelete)
            {
                return BadRequest("create /  delete all operations mandatory at a time");
            }

            else if (!category.IsCreate && !category.IsUpdate &&
                 category.IsDelete)
            {
                return BadRequest("  create /  delete all operations mandatory at a time");
            }

            else if (category.IsCreate && !category.IsUpdate &&
                 category.IsDelete)
            {
                // create operations
                return Ok();
            }
            else if (!category.IsCreate && category.IsUpdate &&
                 !category.IsDelete)
            {
                // Update Operations
                return Ok();
            }

            else if (!category.IsCreate && !category.IsUpdate &&
                 category.IsDelete)
            {
                //delete operation
                return Ok();
            }
            else 
            {
                return BadRequest();
            }

        }
    }
}
