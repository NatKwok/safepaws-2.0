using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using NodaTime;

namespace safepaws_be.Models;

public partial class Trail
{
    public int Id { get; set; }

    public MultiLineString? Geom { get; set; }

    public int? Objectid { get; set; }

    public string? Trailtype { get; set; }

    public string? Trailname { get; set; }

    public string? Streetname { get; set; }

    public string? Municipality { get; set; }

    public string? Settlement { get; set; }

    public string? Ownedby { get; set; }

    public string? Maintainedby { get; set; }

    public string? Onoffroad { get; set; }

    public string? Surfacematerial { get; set; }

    public string? Obstructions { get; set; }

    public LocalDateTime? Installdate { get; set; }

    public double? WidthM { get; set; }

    public double? LengthM { get; set; }

    public string? Notes { get; set; }

    public string? Lifestatus { get; set; }

    public string? Rmwid { get; set; }

    public string? Createduser { get; set; }

    public LocalDateTime? Createddate { get; set; }

    public string? Lastediteduser { get; set; }

    public LocalDateTime? Lastediteddate { get; set; }

    public int? Lucityautoid { get; set; }

    public int? Inlucity { get; set; }

    public LocalDateTime? Lastsyncdate { get; set; }

    public int? Segmentlucityautoid { get; set; }

    public string? Contractnumber { get; set; }

    public string? Comments { get; set; }

    public int? Estimatedservicelife { get; set; }

    public double? Replacementcost { get; set; }

    public int? Consequenceoffailure { get; set; }

    public string? Lastinspection { get; set; }

    public string? Conditionrating { get; set; }

    public double? Shapestlength { get; set; }
}
