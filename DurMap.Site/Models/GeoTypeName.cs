using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Types;

namespace DurMap.Site.Models
{
    /// <summary>
    /// Type names used in SqlGeography types.
    /// </summary>
    public static class GeoTypeName
    {
        public const string Point = "POINT";
        public const string LineString = "LINESTRING";
        public const string Polygon = "POLYGON";
        public const string MultiLineString = "MULTILINESTRING";
        public const string MultiPolygon = "MULTIPOLYGON";
        public const string GeometryCollection = "GEOMETRYCOLLECTION";

        public static string GetGeoType(SqlGeography geo)
        {
            return geo.STGeometryType().ToString().ToUpper();
        }
        public static string GetGeoType(SqlGeometry geo)
        {
            return geo.STGeometryType().ToString().ToUpper();
        }
    }
}