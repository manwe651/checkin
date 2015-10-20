using CheckInWeb.Data.Context;
using CheckInWeb.Data.Entities;
using CheckInWeb.Data.Repositories;
using CheckInWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckInWeb.Controllers
{
    public class AjaxLocationController : ApiController
    {
        #region Fields...

        IRepository _repository;

        #endregion

        #region Constructors...

        public AjaxLocationController()
            : this(new Repository(new CheckInDatabaseContext()))
        {

        }

        public AjaxLocationController(IRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public string Get()
        {
            return "Hello World";
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]Location location)
        {
            
            _repository.Insert<Location>(location);
            _repository.SaveChanges();
            var response = Request.CreateResponse(HttpStatusCode.Created, location);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("AjaxLocation/{0}", location.Id));
            return response;
        }
    }
}