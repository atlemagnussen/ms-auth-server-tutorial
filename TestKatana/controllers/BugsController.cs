using System.Collections.Generic;
using System.Web.Http;
using TestKatana.Logic;
using TestKatana.Model;

namespace TestKatana.controllers
{
    public class BugsController : ApiController
    {
        readonly BugsRepository _bugsRepository = new BugsRepository();

        // GET api/<controller>
        public IEnumerable<Bug> Get()
        {
            return _bugsRepository.GetBugs();
        }

        // GET api/<controller>/5
        public Bug Get(int id)
        {
            return _bugsRepository.Get(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}