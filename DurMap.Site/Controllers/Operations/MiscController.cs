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

        public class BoundingBoxRequest
        {
            public class Location
            {
                public double latitude { get; set; }
                public double longitude { get; set; }
            }
            public class BoundingBox
            {
                public Location center { get; set; }
                public double width { get; set; }
                public double height { get; set; }
            }

            public int zoom { get; set; }
            public BoundingBox bounds { get; set; }
        }

        public static Models.BoundingBox ConvertBingBoundingBox(BoundingBoxRequest.BoundingBox bbox)
        {
            var bb = new Models.BoundingBox()
            {
                North = bbox.center.latitude + (bbox.height / 2),
                South = bbox.center.latitude - (bbox.height / 2),
                West = bbox.center.longitude - (bbox.width / 2),
                East = bbox.center.longitude + (bbox.width / 2)
            };
            return bb;
        }


        [HttpPost]
        public FeatureCollection GetStates(BoundingBoxRequest request)
        {
            return Repository.GetStates(ConvertBingBoundingBox(request.bounds), request.zoom);
        }
    }
}
