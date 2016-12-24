using NoAdapterAPI.Models;
using System;
using System.Web.Http;

namespace NoAdapterAPI.Controllers.Database
{
    public class DatabaseController : ApiController
    {
        [HttpGet, Route("api/Database/Initiate")]
        public IHttpActionResult Initiate()
        {
            if (DatabaseManager.InitiateConnection())
                
                return Ok();
            else
                return InternalServerError(new Exception("Database Connection Failed\nCheck Log File.\nP.S. Sameh Rocks"));
        }

        [HttpGet, Route("api/Database/Terminate")]
        public IHttpActionResult Terminate()
        {
            if (DatabaseManager.CloseConnection())
                return Ok();
            else
                return InternalServerError(new Exception("Database Connection Termination Failed\nCheck Log File.\nP.S. Sameh Rocks"));
        }

    }
}