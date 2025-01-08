using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace safepaws_be.Models;

public partial class DogPark
{
    public int Id { get; set; }

    public Polygon? Geom { get; set; }

    public int? Objectid { get; set; }

    public int? Landmarkid { get; set; }

    public string? Landmark { get; set; }

    public string? Category { get; set; }

    public string? Subcategory { get; set; }

    public int? Propertyunitid { get; set; }

    public int? CivicNo { get; set; }

    public string? Street { get; set; }

    public string? Status { get; set; }

    public string? StatusDate { get; set; }

    public string? MunicipalFacility { get; set; }

    public string? LocationDescription { get; set; }

    public string? DivisionResponsible { get; set; }

    public string? Ownership { get; set; }

    public string? ConstructionYear { get; set; }

    public string? Tag1 { get; set; }

    public string? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }

    public string? Source { get; set; }

    public string? SourceDate { get; set; }

    public string? MapLabel { get; set; }
}
