using GammaRaySetList.Data;
using GammaRaySetList.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GammaRaySetList.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IUnitOfWork _unitOfWork { get; set; }

        public BaseApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
