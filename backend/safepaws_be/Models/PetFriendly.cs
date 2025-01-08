using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace safepaws_be.Models;

public partial class PetFriendly
{
    public int Id { get; set; }

    public Point? Geom { get; set; }

    public string? MarkerColor { get; set; }

    public string? MarkerSize { get; set; }

    public string? MarkerSymbol { get; set; }

    public string? Businessname { get; set; }

    public string? Date { get; set; }

    public int? UniqueId { get; set; }
}
