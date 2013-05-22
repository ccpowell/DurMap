using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

using DurMap.Site.Models;
using DurMap.Site.Models.GeoJson;
namespace DurMap.Site.Data
{
    public class Repository
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["States"].ConnectionString;


        /// <summary>
        /// Get an open connection using the configured connection string.
        /// </summary>
        /// <returns>open connection</returns>
        private SqlConnection GetOpenConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public FeatureCollection GetStates(Models.BoundingBox bbox)
        {
            var features = new List<Feature>();

            var fc = new FeatureCollection() { features = features.ToArray() };
            return fc;
        }
    }
}