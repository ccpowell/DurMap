using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

using DurMap.Site.Models;
using DurMap.Site.Models.GeoJson;
using Microsoft.SqlServer.Types;
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

        public FeatureCollection GetStates(Models.BoundingBox bbox, int zoom)
        {
            var features = new List<Feature>();

            // HACK! limit West to date line
            var inbox = bbox;
            if (bbox.West > bbox.East)
            {
                inbox = new BoundingBox()
                {
                    North = bbox.North,
                    South = bbox.South,
                    West = -179.999,
                    East = bbox.East
                };
            }
            var box = GeoJsonConvert.GeometryFromBoundingBox(inbox);
            using (var conn = GetOpenConnection())
            {
                using (var cmd = new SqlCommand(@"GetStatesWithinBox", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Bounds", System.Data.SqlDbType.Udt)
                    {
                        UdtTypeName = "geometry",
                        Value = box
                    });
                    cmd.Parameters.AddWithValue("@Zoom", zoom);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var border = (SqlGeometry)rdr["Border"];
                            var properties = new Dictionary<string, string>();
                            properties.Add("name", (String)rdr["Name"]);
                            features.Add(new Feature()
                            {
                                geometry = GeoJsonConvert.GeoJsonMultiPolygonFromGeometry(border),
                                properties = properties
                            });
                        }
                    }
                }
            }
            var fc = new FeatureCollection() { features = features.ToArray() };
            return fc;
        }
    }
}