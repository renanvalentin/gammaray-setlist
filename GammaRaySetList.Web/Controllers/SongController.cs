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
    public class SongController : BaseApiController
    {
        public SongController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/song
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/song
        public HttpResponseMessage Post(Song song)
        {
            song.Band = _unitOfWork.Bands.GetById(song.Band.Id);

            _unitOfWork.Songs.Add(song);
            _unitOfWork.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, song);

            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = song.Id }));

            return response;
        }

        // PUT api/song/5
        public HttpResponseMessage Put(Song song)
        {
            _unitOfWork.Songs.Update(song);
            _unitOfWork.Commit();

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/song/5
        public HttpResponseMessage Delete(int id)
        {
            _unitOfWork.Songs.Delete(id);
            _unitOfWork.Commit();

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}