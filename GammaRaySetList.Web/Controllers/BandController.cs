﻿using GammaRaySetlist.Model;
using GammaRaySetList.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace GammaRaySetList.Web.Controllers
{
    public class BandController : BaseApiController
    {
        public BandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/band
        public IEnumerable<Band> Get()
        {
            return _unitOfWork.Bands.GetAll().Include("Songs");
        }
    }
}
