using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.SqlServer.Types;

namespace DurMap.Site.Data
{
    /// <summary>
    /// This class contains conversion methods for going from SqlGeography types
    /// to GeoJson types and vice versa.
    /// </summary>
    public static class GeoJsonConvert
    {
        public static readonly int SRID = 4326;

        /// <summary>
        /// Build an SqlGeography Point from a GeoJson Point.
        /// </summary>
        /// <param name="point">GeoJson Point</param>
        /// <returns>SqlGeography Point</returns>
        public static SqlGeography GeographyFromGeoJsonPoint(DurMap.Site.Models.GeoJson.Point point)
        {
            var geob = new SqlGeographyBuilder();
            geob.SetSrid(SRID);
            geob.BeginGeography(OpenGisGeographyType.Point);
            geob.BeginFigure(point.coordinates[1], point.coordinates[0]);
            geob.EndFigure();
            geob.EndGeography();
            var geog = geob.ConstructedGeography;
            //Trace.WriteLine(geog.AsGml().Value);
            return geog;
        }

        /// <summary>
        /// Build a Point geography
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns>constructed geography</returns>
        public static SqlGeography GeographyFromPoint(double latitude, double longitude)
        {
            var geob = new SqlGeographyBuilder();
            geob.SetSrid(SRID);
            geob.BeginGeography(OpenGisGeographyType.Point);
            geob.BeginFigure(latitude, longitude);
            geob.EndFigure();
            geob.EndGeography();
            var geog = geob.ConstructedGeography;
            //Trace.WriteLine(geog.AsGml().Value);
            return geog;
        }


        /// <summary>
        /// Build an SqlGeography Polygon from a GeoJson Polygon.
        /// </summary>
        /// <param name="poly">GeoJson Polygon</param>
        /// <returns>SqlGeography Polygon</returns>
        public static SqlGeography GeographyFromGeoJsonPolygon(DurMap.Site.Models.GeoJson.Polygon poly)
        {
            var geob = new SqlGeographyBuilder();
            geob.SetSrid(SRID);
            geob.BeginGeography(OpenGisGeographyType.Polygon);
            geob.BeginFigure(poly.coordinates[0][0][1], poly.coordinates[0][0][0]);
            foreach (var pair in poly.coordinates[0].Skip(1))
            {
                geob.AddLine(pair[1], pair[0]);
            }
            geob.EndFigure();
            geob.EndGeography();
            var geog = geob.ConstructedGeography;
            //Trace.WriteLine(geog.AsGml().Value);
            return geog;
        }

        /// <summary>
        /// Build an SqlGeography Polygon from a bounding box.
        /// </summary>
        /// <param name="box">Bounding Box</param>
        /// <returns>SqlGeography Polygon</returns>
        public static SqlGeography GeographyFromBoundingBox(Models.BoundingBox box)
        {
            var geob = new SqlGeographyBuilder();
            geob.SetSrid(SRID);
            geob.BeginGeography(OpenGisGeographyType.Polygon);
            geob.BeginFigure(box.South, box.West);
            geob.AddLine(box.South, box.East);
            geob.AddLine(box.North, box.East);
            geob.AddLine(box.North, box.West);
            geob.AddLine(box.South, box.West);
            geob.EndFigure();
            geob.EndGeography();
            var geog = geob.ConstructedGeography;
            //Trace.WriteLine("GeographyFromBoundingBox : " + geog.AsGml().Value);
            return geog;
        }

        /// <summary>
        /// Build an SqlGeometry Polygon from a bounding box.
        /// </summary>
        /// <param name="box">Bounding Box</param>
        /// <returns>SqlGeometry Polygon</returns>
        public static SqlGeometry GeometryFromBoundingBox(Models.BoundingBox box)
        {
            var geob = new SqlGeometryBuilder();
            geob.SetSrid(SRID);
            geob.BeginGeometry(OpenGisGeometryType.Polygon);
            geob.BeginFigure(box.West, box.South);
            geob.AddLine(box.East, box.South);
            geob.AddLine(box.East, box.North);
            geob.AddLine(box.West, box.North);
            geob.AddLine(box.West, box.South);
            geob.EndFigure();
            geob.EndGeometry();
            var geom = geob.ConstructedGeometry;
            //Trace.WriteLine("GeometryFromBoundingBox : " + geom.AsGml().Value);
            return geom;
        }

        /// <summary>
        /// Make a point from latitude and longitude
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns>geometry</returns>
        public static SqlGeometry GeometryFromLatLong(double latitude, double longitude)
        {
            var geob = new SqlGeometryBuilder();
            geob.SetSrid(SRID);
            geob.BeginGeometry(OpenGisGeometryType.Point);
            geob.BeginFigure(longitude, latitude);
            geob.EndFigure();
            geob.EndGeometry();
            var geom = geob.ConstructedGeometry;
            //Trace.WriteLine("GeometryFromLatLong : " + geom.AsGml().Value);
            return geom;
        }

        /// <summary>
        /// Make a point from a location
        /// </summary>
        /// <param name="location"></param>
        /// <returns>geometry</returns>
        public static SqlGeometry GeometryFromLocation(Models.Location location)
        {
            return GeometryFromLatLong(location.Latitude, location.Longitude);
        }


        /// <summary>
        /// Build a BoundingBox from two SqlGeography Points
        /// </summary>
        /// <param name="northwest"></param>
        /// <param name="southeast"></param>
        /// <returns>BoundingBox</returns>
        public static Models.BoundingBox BoundingBoxFromGeoPoints(SqlGeography northwest, SqlGeography southeast)
        {
            return new Models.BoundingBox()
            {
                North = (double)northwest.Lat,
                West = (double)northwest.Long,
                South = (double)southeast.Lat,
                East = (double)southeast.Long
            };
        }

        /// <summary>
        /// Build an SqlGeography Polygon from a bounding box given in discrete coordinates.
        /// </summary>
        /// <param name="nwLat">Northwest Latitude</param>
        /// <param name="nwLong">Northwest Longitude</param>
        /// <param name="seLat">Southeast Latitude</param>
        /// <param name="seLong">Southeast Longitude</param>
        /// <returns>SqlGeography Polygon</returns>
        public static SqlGeography GeographyFromBoundingBoxNwSe(double nwLat, double nwLong, double seLat, double seLong)
        {
            return GeographyFromBoundingBox(new Models.BoundingBox()
            {
                East = seLong,
                North = nwLat,
                South = seLat,
                West = nwLong
            });
        }
        /// <summary>
        /// Build an SqlGeometry Polygon from a bounding box given in discrete coordinates.
        /// </summary>
        /// <param name="nwLat">Northwest Latitude</param>
        /// <param name="nwLong">Northwest Longitude</param>
        /// <param name="seLat">Southeast Latitude</param>
        /// <param name="seLong">Southeast Longitude</param>
        /// <returns>SqlGeometry Polygon</returns>
        public static SqlGeometry GeometryFromBoundingBoxNwSe(double nwLat, double nwLong, double seLat, double seLong)
        {
            return GeometryFromBoundingBox(new Models.BoundingBox()
            {
                East = seLong,
                North = nwLat,
                South = seLat,
                West = nwLong
            });
        }

        /// <summary>
        /// Build an SqlGeography LineString from a GeoJson LineString.
        /// </summary>
        /// <param name="line">GeoJson LineString</param>
        /// <returns>SqlGeography LineString</returns>
        public static SqlGeography GeographyFromGeoJsonLineString(DurMap.Site.Models.GeoJson.LineString line)
        {
            var geob = new SqlGeographyBuilder();
            geob.SetSrid(SRID);
            geob.BeginGeography(OpenGisGeographyType.LineString);
            geob.BeginFigure(line.coordinates[0][1], line.coordinates[0][0]);
            foreach (var pair in line.coordinates.Skip(1))
            {
                geob.AddLine(pair[1], pair[0]);
            }
            geob.EndFigure();
            geob.EndGeography();
            var geog = geob.ConstructedGeography;
            //Trace.WriteLine(geog.AsGml().Value);
            return geog;
        }


        private static void CheckGeoType(SqlGeography geography, params string[] permitted)
        {
            string stype = (string)geography.STGeometryType();
            if (!permitted.Contains(stype))
            {
                throw new ArgumentException("This conversion cannot handle " + stype + ", it can only handle the following types: " + string.Join(",", permitted));
            }
        }


        private static void CheckGeoType(SqlGeometry geography, params string[] permitted)
        {
            string stype = (string)geography.STGeometryType();
            if (!permitted.Contains(stype))
            {
                throw new ArgumentException("This conversion cannot handle " + stype + ", it can only handle the following types: " + string.Join(",", permitted));
            }
        }

        /// <summary>
        /// Build a GeoJson Point from an SqlGeography Point.
        /// </summary>
        /// <param name="geography"SqlGeography Point></param>
        /// <returns>GeoJson Point</returns>
        public static DurMap.Site.Models.GeoJson.Point GeoJsonPointFromGeography(SqlGeography geography)
        {
            CheckGeoType(geography, "Point");
            return GeoJsonPointFromLocation((double)geography.Lat, (double)geography.Long);
        }

        /// <summary>
        /// Build a GeoJson Point from an SqlGeometry Point.
        /// </summary>
        /// <param name="geography"SqlGeometry Point></param>
        /// <returns>GeoJson Point</returns>
        public static DurMap.Site.Models.GeoJson.Point GeoJsonPointFromGeometry(SqlGeometry geography)
        {
            CheckGeoType(geography, "Point");
            return GeoJsonPointFromLocation((double)geography.STY, (double)geography.STX);
        }

        /// <summary>
        /// Build a GeoJson Point from latitude and longitude.
        /// </summary>
        /// <returns>GeoJson Point</returns>
        public static DurMap.Site.Models.GeoJson.Point GeoJsonPointFromLocation(double latitude, double longitude)
        {
            var point = new DurMap.Site.Models.GeoJson.Point()
            {
                coordinates = new double[2]
            };
            //we can safely round the lat/long to 5 decimal places as thats 1.11m at equator, reduces data transfered to client
            point.coordinates[0] = Math.Round(longitude, 5);
            point.coordinates[1] = Math.Round(latitude, 5);
            return point;
        }

        /// <summary>
        ///  Build a GeoJson LineString from an SqlGeography LineString.
        /// </summary>
        /// <param name="geography">SqlGeography LineString</param>
        /// <returns>GeoJson LineString</returns>
        public static DurMap.Site.Models.GeoJson.LineString GeoJsonLineStringFromGeography(SqlGeography geography)
        {
            CheckGeoType(geography, "LineString");

            var points = new List<double[]>();
            for (int i = 1; i <= geography.STNumPoints(); i++)
            {
                var point = new double[2];
                var sp = geography.STPointN(i);
                //we can safely round the lat/long to 5 decimal places as thats 1.11m at equator, reduces data transfered to client
                point[0] = Math.Round((double)sp.Long, 5);
                point[1] = Math.Round((double)sp.Lat, 5);
                points.Add(point);
            }
            return new DurMap.Site.Models.GeoJson.LineString()
            {
                coordinates = points.ToArray()
            };
        }

        /// <summary>
        ///  Build a GeoJson MultiLineString from an SqlGeography LineString or MultiLineString.
        /// </summary>
        /// <param name="geography">SqlGeography LineString or MultiLineString</param>
        /// <returns>GeoJson MultiLineString</returns>
        public static DurMap.Site.Models.GeoJson.MultiLineString GeoJsonMultiLineStringFromGeography(SqlGeography geography)
        {
            if ((string)geography.STGeometryType() == "LineString")
            {
                var points = new List<double[]>();
                for (int i = 1; i <= geography.STNumPoints(); i++)
                {
                    var point = new double[2];
                    var sp = geography.STPointN(i);
                    //we can safely round the lat/long to 5 decimal places as thats 1.11m at equator, reduces data transfered to client
                    point[0] = Math.Round((double)sp.Long, 5);
                    point[1] = Math.Round((double)sp.Lat, 5);
                    points.Add(point);
                }
                var mls = new DurMap.Site.Models.GeoJson.MultiLineString()
                {
                    coordinates = new double[1][][]
                };
                mls.coordinates[0] = points.ToArray();
                return mls;
            }

            if ((string)geography.STGeometryType() == "MultiLineString")
            {
                var lscoords = new List<double[][]>();
                for (var g = 1; g <= geography.STNumGeometries(); g++)
                {
                    var geo = geography.STGeometryN(g);
                    Debug.Assert((string)geo.STGeometryType() == "LineString");
                    var points = new List<double[]>();

                    for (int i = 1; i <= geo.STNumPoints(); i++)
                    {
                        var point = new double[2];
                        var sp = geography.STPointN(i);
                        //we can safely round the lat/long to 5 decimal places as thats 1.11m at equator, reduces data transfered to client
                        point[0] = Math.Round((double)sp.Long, 5);
                        point[1] = Math.Round((double)sp.Lat, 5);
                        points.Add(point);
                    }
                    lscoords.Add(points.ToArray());
                }
                var mls = new DurMap.Site.Models.GeoJson.MultiLineString()
                {
                    coordinates = lscoords.ToArray()
                };
                return mls;
            }

            throw new ArgumentException("GeoJsonMultiLineStringFromGeography will only convert MultiLineString and LineString geometries.");
        }


        private static double[][][] PolygonCoordinatesFromGeography(SqlGeography polygon)
        {
            Debug.Assert((string)polygon.STGeometryType() == "Polygon");

            // convert only the first (exterior) ring
            var ring = polygon.STGeometryN(1);
            var points = new List<double[]>();

            for (int i = 1; i <= ring.STNumPoints(); i++)
            {
                var point = new double[2];
                var sp = ring.STPointN(i);
                //we can safely round the lat/long to 5 decimal places as thats 1.11m at equator, reduces data transfered to client
                point[0] = Math.Round((double)sp.Long, 5);
                point[1] = Math.Round((double)sp.Lat, 5);
                points.Add(point);
            }

            var coordinates = new double[1][][];
            coordinates[0] = points.ToArray();
            return coordinates;
        }



        private static double[][][] PolygonCoordinatesFromGeometry(SqlGeometry polygon)
        {
            CheckGeoType(polygon, "Polygon");

            // convert only the first (exterior) ring
            var ring = polygon.STExteriorRing();
            var points = new List<double[]>();

            for (int i = 1; i <= ring.STNumPoints(); i++)
            {
                var point = new double[2];
                var sp = ring.STPointN(i);
                //we can safely round the lat/long to 5 decimal places as thats 1.11m at equator, reduces data transfered to client
                point[0] = Math.Round((double)sp.STX, 5);
                point[1] = Math.Round((double)sp.STY, 5);
                points.Add(point);
            }

            var coordinates = new double[1][][];
            coordinates[0] = points.ToArray();
            return coordinates;
        }

        /// <summary>
        /// Create a GeoJson MultiPolygon from an SQL Server geography type.
        /// States and Countries are MultiPolygons on the client since they can come in many pieces.
        /// In the database, the geography may be a MultiPolygon or Polygon.
        /// Due to reduction, the geography may be a GeometryCollection containing 
        /// any types. This method extracts all external polygons from a geography
        /// and constructs a GeoJsonMultiPolygon.
        /// 
        /// To keep things simple in the client, we treat a Polygon as a Multipolygon
        /// containing a single Polygon.
        /// </summary>
        /// <remarks>
        /// Indices in a MultiPolygon are:
        /// 1. polygon 
        /// 2. ring (only first ring is used since only exterior is drawn)
        /// 3. point
        /// 4. lat, long
        /// </remarks>
        /// <param name="geography">geography</param>
        /// <returns>MultiPolygon</returns>
        public static DurMap.Site.Models.GeoJson.MultiPolygon GeoJsonMultiPolygonFromGeography(SqlGeography geography)
        {
            var geoType = (string)geography.STGeometryType();
            var polycoords = new List<double[][][]>();
            if (geoType == "Polygon")
            {
                polycoords.Add(PolygonCoordinatesFromGeography(geography));
            }

            // For a MultiPolygon or GeometryCollection, the same is repeated for each contained polygon
            else if (geoType == "MultiPolygon" || geoType == "GeometryCollection")
            {
                for (var g = 1; g <= geography.STNumGeometries(); g++)
                {
                    var geo = geography.STGeometryN(g);
                    if ((string)geo.STGeometryType() == "Polygon")
                    {
                        polycoords.Add(PolygonCoordinatesFromGeography(geo));
                    }
                    else
                    {
                        //Trace.WriteLine("Ignoring " + (string)geo.STGeometryType());
                    }
                }
            }
            else
            {
                throw new ArgumentException("GeoJsonMultiPolygonFromGeography will only convert GeometryCollection, MultiPolygon and Polygon geometries.");
            }

            // return a MultiPolygon containing the coordinates of the polygons
            var mpoly = new DurMap.Site.Models.GeoJson.MultiPolygon()
            {
                coordinates = polycoords.ToArray()
            };
            return mpoly;
        }



        /// <summary>
        /// Create a GeoJson MultiPolygon from an SQL Server geography type.
        /// States and Countries are MultiPolygons on the client since they can come in many pieces.
        /// In the database, the geography may be a MultiPolygon or Polygon.
        /// Due to reduction, the geography may be a GeometryCollection containing 
        /// any types. This method extracts all external polygons from a geography
        /// and constructs a GeoJsonMultiPolygon.
        /// 
        /// To keep things simple in the client, we treat a Polygon as a Multipolygon
        /// containing a single Polygon.
        /// </summary>
        /// <remarks>
        /// Indices in a MultiPolygon are:
        /// 1. polygon 
        /// 2. ring (only first ring is used since only exterior is drawn)
        /// 3. point
        /// 4. lat, long
        /// </remarks>
        /// <param name="geometry">geometry</param>
        /// <returns>MultiPolygon</returns>
        public static DurMap.Site.Models.GeoJson.MultiPolygon GeoJsonMultiPolygonFromGeometry(SqlGeometry geometry)
        {
            var geoType = (string)geometry.STGeometryType();
            var polycoords = new List<double[][][]>();
            if (geoType == "Polygon")
            {
                polycoords.Add(PolygonCoordinatesFromGeometry(geometry));
            }

            // For a MultiPolygon or GeometryCollection, the same is repeated for each contained polygon
            else if (geoType == "MultiPolygon" || geoType == "GeometryCollection")
            {
                for (var g = 1; g <= geometry.STNumGeometries(); g++)
                {
                    var geo = geometry.STGeometryN(g);
                    if ((string)geo.STGeometryType() == "Polygon")
                    {
                        polycoords.Add(PolygonCoordinatesFromGeometry(geo));
                    }
                    else
                    {
                        //Trace.WriteLine("Ignoring " + (string)geo.STGeometryType());
                    }
                }
            }
            else
            {
                throw new ArgumentException("GeoJsonMultiPolygonFromGeometry will only convert GeometryCollection, MultiPolygon and Polygon geometries.");
            }

            // return a MultiPolygon containing the coordinates of the polygons
            var mpoly = new DurMap.Site.Models.GeoJson.MultiPolygon()
            {
                coordinates = polycoords.ToArray()
            };
            return mpoly;
        }

    }
}