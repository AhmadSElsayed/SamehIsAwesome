using NoAdapterAPI.Models;
using NoAdapterAPI.Models.Fillers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NoAdapterAPI.Controllers.ModelContollers
{
    [RoutePrefix("api/Season")]
    public class SeasonController : ApiController
    {
        [HttpGet]
        public List<Season> Get()
        {
            var temp = DatabaseManager.ExecuteReader("SELECT * FROM SEASON");
            return Filler.FillList<Season>(temp);
        }

        [HttpGet]
        // GET api/<controller>/5
        public Season Get([FromUri]string SeasonName)
        {
            var temp = DatabaseManager.ExecuteReader(string.Format("SELECT * FROM SEASON WHERE SeasonName = '{0}'", SeasonName));
            var list = Filler.FillList<Season>(temp);
            if (list.Count == 0)
                return null;
            return list.First();
        }

        [HttpPost]
        // POST api/<controller>
        public int Post([FromBody]Season temp)
        {
          // Season temp = Newtonsoft.Json.JsonConvert.DeserializeObject<Season>(JSON);
           return DatabaseManager.ExecuteNonQuery(string.Format("INSERT INTO SEASON(SeasonName, StartDate, EndDate) VALUES('{0}', '{1}', '{2}')",
               temp.SeasonName, 
               temp.StartDate.ToShortDateString(), 
               temp.EndDate.ToShortDateString()));
        }

        [HttpPut]
        // PUT api/<controller>/5
        public int Put([FromUri]string SeasonName, [FromBody]Season temp)
        {
            return DatabaseManager.ExecuteNonQuery(string.Format("Update SEASON set StartDate = '{1}', EndDate = '{2}'  where SeasonName = '{0}'", 
                SeasonName, 
                temp.StartDate.ToShortDateString(), 
                temp.EndDate.ToShortDateString()));
        }

        [HttpDelete]
        // DELETE api/<controller>/5
        public int Delete([FromUri]string SeasonName)
        {
            return DatabaseManager.ExecuteNonQuery(string.Format("Delete from Season where SeasonName = '{0}'", SeasonName));
        }

        [HttpPatch]
        public bool check([FromUri]string SeasonName)
        {
            return (int)DatabaseManager.ExecuteScalar(string.Format("Select Count(*) from Season where SeasonName = '{0}'",SeasonName)) > 0 ? true : false ;
        }
    }
}