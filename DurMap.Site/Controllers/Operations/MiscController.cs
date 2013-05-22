using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DurMap.Site.Models;
using DurMap.Site.Models.GeoJson;
using DurMap.Site.Data;

namespace DurMap.Site.Controllers.Operations
{
    public class MiscController : ApiController
    {

        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private Repository Repository { get; set; }

        public MiscController(Repository repo)
        {
            Repository = repo;
            Logger.Debug("created");
        }

        [HttpPost]
        public FeatureCollection GetStates(Models.BoundingBox bbox)
        {
            return Repository.GetStates(bbox);
        }
    }
}
