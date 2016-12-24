﻿using NoAdapterAPI.Models;
using NoAdapterAPI.Models.Fillers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoAdapterAPI.Controllers.ModelContollers
{
    /// <summary>
    /// Logic Controller for Customer Class
    /// </summary>
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        /// <summary>
        /// Gets ALL Customers from the Database
        /// </summary>
        /// <returns>A List of Customer Objects</returns>
        [HttpGet]
        public List<Customer> Get()
        {
            var temp = DatabaseManager.ExecuteReader("SELECT * FROM Customer");
            return Filler.FillList<Customer>(temp);
        }

        /// <summary>
        /// Gets the Customer Corrosponding to this ID 
        /// </summary>
        /// <param name="CustomerID">Customer ID</param>
        /// <returns>Customer with this ID or null if none exists</returns>
        [HttpGet]
        public Customer Get([FromUri]string CustomerID)
        {
            var temp = DatabaseManager.ExecuteReader(string.Format("SELECT * FROM Customer WHERE CustomerID = '{0}'", CustomerID));
            var list = Filler.FillList<Customer>(temp);
            if (list.Count == 0)
                return null;
            return list.First();
        }
        /// <summary>
        /// Inserts a new Customer
        /// </summary>
        /// <param name="temp">Customer data from the Request Body</param>
        /// <returns>A number more than ZERO if successful or -1 if failed(SSN Already Exists)</returns>
        [HttpPost]
        public int Post([FromBody]Customer temp)
        {
            var param = Filler.FillDictionary<Customer>(temp);
            param.Remove("@CustomerID");
            return (int)DatabaseManager.ExecuteProcedure("INSERT_CUSTOMER", param);
        }

        /// <summary>
        /// Edit Customer Data Except ID
        /// </summary>
        /// <param name="CustomerID">ID of Customer to edit</param>
        /// <param name="temp">New Data</param>
        /// <returns>A number more than ZERO if successful or -1 if failed</returns>
        [HttpPut]
        public int Put([FromUri]string CustomerID, [FromBody]Customer temp)
        {
            return DatabaseManager.ExecuteNonQuery(string.Format("Update Customer set UserName = '{1}', Password = '{2}', SSN = '{3}', Name = '{4}', Gender = '{5}', Age ={6}  where CustomerID = {0}",
                CustomerID,
                temp.UserName,
                temp.Password,
                temp.SSN,
                temp.Name,
                temp.Gender,
                temp.Age));
                }

        /// <summary>
        /// NOT WORKING YET....>FIX DATABASE
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        [HttpDelete]
        // DELETE api/<controller>/5
        public int Delete([FromUri]int CustomerID)
        {
            return DatabaseManager.ExecuteNonQuery(string.Format("Delete from Customer where CustomerID = '{0}'", CustomerID));
        }

        /// <summary>
        /// Checks if Customer Exists
        /// </summary>
        /// <param name="CustomerID">ID to Check</param>
        /// <returns>Boolean</returns>
        [HttpPatch]
        public bool check([FromUri]string CustomerID)
        {
            return (int)DatabaseManager.ExecuteScalar(string.Format("Select Count(*) from Customer where CustomerID = '{0}'", CustomerID)) > 0 ? true : false;
        }
    }
}