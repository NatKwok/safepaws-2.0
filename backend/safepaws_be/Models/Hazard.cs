using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace safepaws_be.Models;

public partial class Hazard
{
    public int Id { get; set; }

    public Point? Geom { get; set; }

    public int? UniqueId { get; set; }

    public string? NearestIntersection { get; set; }

    public string? GlassTrash { get; set; }

    public string? Date { get; set; }
}
