using GammaRaySetlist.Model;
using GammaRaySetList.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GammaRaySetList.Web.Controllers
{
    public class LookupsController : BaseApiController
    {
        public LookupsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/lookups
        public IEnumerable<Band> Get()
        {
            return _unitOfWork.Bands.GetAll();
        }
    }
}
