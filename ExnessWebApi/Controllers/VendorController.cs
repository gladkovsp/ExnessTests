using System;
using System.Net;
using System.Web.Http;

using Exness.Models;
using Exness.DataRepository;

namespace Exness.Controllers
{
    [RoutePrefix("api/vendor")]
    public class VendorController : ApiController
    {
        protected VendorRepository vendorRepository;

		public VendorController()
        {
            vendorRepository = new VendorRepository();
        }

        // GET: api/vendor/{id}
        [Route("{id}")] 
        public IHttpActionResult GetVendor(string id)
        {
			Guid guid;
			bool GuidIsValid = Guid.TryParse(id, out guid);

			var vendor = vendorRepository.GetVendorById(guid);
			if (vendor == null || !GuidIsValid)
			{
				return Content(HttpStatusCode.NotFound, new { message = $"Vendor {id} is not found" });
			}

			return Ok(vendor);
        }

		// POST: api/vendor
		[Route(""), HttpPost]
		public void CreateVendor(Vendor vendor)
		{
			vendorRepository.AddVendorToDb(vendor);
		}

		// DELETE: api/vendor
		[Route(""), HttpDelete]
		public void CleanUp()
		{
			vendorRepository.CleanUpDb();
		}
	}
}