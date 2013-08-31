using GammaRaySetlist.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GammaRaySetList.Web.Controllers
{
    public class BandController : BaseApiController
    {
        // GET api/band
        public IEnumerable<Band> Get()
        {
            return _unitOfWork.Bands.GetAll();
        }

        // POST api/band
        public void Post(Band band)
        {
        }

        // PUT api/band/5
        public void Put(Band band)
        {
        }
    }
}
