using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using TestKatana.hubs;
using TestKatana.Logic;
using TestKatana.Model;

namespace TestKatana.controllers
{
    public class BugsController : ApiController
    {
        private readonly BugsRepository _bugsRepository;
        private IHubContext _hub;

        public BugsController()
        {
            _bugsRepository = new BugsRepository();
            _hub = GlobalHost.ConnectionManager.GetHubContext<BugHub>();
        }
        

        // GET api/<controller>
        public IEnumerable<Bug> Get()
        {
            return _bugsRepository.GetBugs();
        }

        // GET api/<controller>/5
        public Bug Get(int id)
        {
            _hub.Clients.All.sayHello("from signalR");
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