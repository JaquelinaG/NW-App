using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CustomersController : ApiController
    {
        ICustomersLogic customersLogic;

        public CustomersController(ICustomersLogic logic)
        {
            this.customersLogic = logic;
        }
        // GET: api/Customers
        [Route("Northwind/Customers")]
        public IEnumerable<CustomerModel> GetCustomerModels()
        {
            List<CustomerModel> listCustomerModel = new List<CustomerModel>();

            var customers = this.customersLogic.GetAll();
            foreach (var customer in customers)
            {
                var model = new CustomerModel(customer);
                listCustomerModel.Add(model);
            }

            //return db.CustomerModels;
            return listCustomerModel;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult GetCustomerModel(string id)
        {
            var customer = this.customersLogic.GetCustomer(id);
            var customerModel = new CustomerModel(customer);
            //CustomerModel customerModel = db.CustomerModels.Find(id);
            if (customerModel == null)
            {
                return NotFound();
            }

            return Ok(customerModel);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerModel(string id, CustomerModel customerModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (id != customerModel.CustomerID)
            {
                return BadRequest();
            }

            //db.Entry(customerModel).State = EntityState.Modified;

            try
            {
                var customer = new Customers();
                customer.CompanyName = customerModel.CompanyName;
                customer.ContactName = customerModel.ContactName;
                this.customersLogic.UpdateCustomer(customer);                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        //// POST: api/Customers
        //[ResponseType(typeof(CustomerModel))]
        //public IHttpActionResult PostCustomerModel(CustomerModel customerModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //db.CustomerModels.Add(customerModel);

        //    try
        //    {
        //        //db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (CustomerModelExists(customerModel.CustomerID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = customerModel.CustomerID }, customerModel);
        //}

        //// DELETE: api/Customers/5
        //[ResponseType(typeof(CustomerModel))]
        //public IHttpActionResult DeleteCustomerModel(string id)
        //{
        //    //CustomerModel customerModel = db.CustomerModels.Find(id);
        //    //if (customerModel == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    ////db.CustomerModels.Remove(customerModel);
        //    ////db.SaveChanges();

        //    //return Ok(customerModel);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        //db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool CustomerModelExists(string id)
        {
            //return db.CustomerModels.Count(e => e.CustomerID == id) > 0;
            return true;
        }
    }
}