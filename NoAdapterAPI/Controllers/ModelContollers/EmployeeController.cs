using NoAdapterAPI.Models;
using NoAdapterAPI.Models.Fillers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NoAdapterAPI.Controllers.ModelContollers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public List<Employee> Get()
        {
            var temp = DatabaseManager.ExecuteReader("Select * From Employee");
            return Filler.FillList<Employee>(temp);
        }
                
        [HttpGet]
        public Employee Get([FromUri]int EmployeeID)
        {
            var temp = DatabaseManager.ExecuteReader(string.Format("SELECT * FROM Employee WHERE EmployeeID = '{0}'", EmployeeID));
            var list = Filler.FillList<Employee>(temp);
            if (list.Count == 0)
                return null;
            return list.First();
        }

        [HttpPost]
        public int Post([FromBody]Employee temp)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
