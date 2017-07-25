using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InfrastructureHelloWorld;


namespace HelloWorld.Controllers
{
    public class HelloWorldController : ApiController
    {
        public IEnumerable<ApiData> Get()
        {
            using (ProjectDBEntities entities = new ProjectDBEntities())
            {
                return entities.ApiDatas.ToList();
            }
        }

        public ApiData Get(int id)
        {
            using (ProjectDBEntities entities = new ProjectDBEntities())
            {
                return entities.ApiDatas.FirstOrDefault(e => e.ID == id);
            }
        }
    }
}
