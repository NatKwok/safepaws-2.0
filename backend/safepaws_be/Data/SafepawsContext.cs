using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using safepaws_be.Models;

namespace safepaws_be.Data;

public partial class SafepawsContext : DbContext
{
    public SafepawsContext()
    {
    }

    public SafepawsContext(DbContextOptions<SafepawsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DogPark> DogParks { get; set; }

    public virtual DbSet<Hazard> Hazards { get; set; }

    public virtual DbSet<PetFriendly> PetFriendlies { get; set; }

    public virtual DbSet<Trail> Trails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=^ytrO524FD;Database=safepaws", x => x
                .UseNodaTime()
                .UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("postgis");

        modelBuilder.Entity<DogPark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DogParks_pkey");

            entity.HasIndex(e => e.Geom, "sidx_DogParks_geom").HasMethod("gist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasColumnType("character varying")
                .HasColumnName("category");
            entity.Property(e => e.CivicNo).HasColumnName("civic_no");
            entity.Property(e => e.ConstructionYear)
                .HasColumnType("character varying")
                .HasColumnName("construction_year");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasColumnType("character varying")
                .HasColumnName("create_date");
            entity.Property(e => e.DivisionResponsible)
                .HasColumnType("character varying")
                .HasColumnName("division_responsible");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(Polygon,4326)")
                .HasColumnName("geom");
            entity.Property(e => e.Landmark)
                .HasColumnType("character varying")
                .HasColumnName("landmark");
            entity.Property(e => e.Landmarkid).HasColumnName("landmarkid");
            entity.Property(e => e.LocationDescription)
                .HasColumnType("character varying")
                .HasColumnName("location_description");
            entity.Property(e => e.MapLabel)
                .HasColumnType("character varying")
                .HasColumnName("map_label");
            entity.Property(e => e.MunicipalFacility)
                .HasColumnType("character varying")
                .HasColumnName("municipal_facility");
            entity.Property(e => e.Objectid).HasColumnName("objectid");
            entity.Property(e => e.Ownership)
                .HasColumnType("character varying")
                .HasColumnName("ownership");
            entity.Property(e => e.Propertyunitid).HasColumnName("propertyunitid");
            entity.Property(e => e.Source)
                .HasColumnType("character varying")
                .HasColumnName("source");
            entity.Property(e => e.SourceDate)
                .HasColumnType("character varying")
                .HasColumnName("source_date");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");
            entity.Property(e => e.StatusDate)
                .HasColumnType("character varying")
                .HasColumnName("status_date");
            entity.Property(e => e.Street)
                .HasColumnType("character varying")
                .HasColumnName("street");
            entity.Property(e => e.Subcategory)
                .HasColumnType("character varying")
                .HasColumnName("subcategory");
            entity.Property(e => e.Tag1)
                .HasColumnType("character varying")
                .HasColumnName("tag1");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("character varying")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<Hazard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Hazards_pkey");

            entity.HasIndex(e => e.Geom, "sidx_Hazards_geom").HasMethod("gist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("character varying")
                .HasColumnName("date");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(Point,4326)")
                .HasColumnName("geom");
            entity.Property(e => e.GlassTrash)
                .HasColumnType("character varying")
                .HasColumnName("glass_trash");
            entity.Property(e => e.NearestIntersection)
                .HasColumnType("character varying")
                .HasColumnName("nearest_intersection");
            entity.Property(e => e.UniqueId).HasColumnName("unique_id");
        });

        modelBuilder.Entity<PetFriendly>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PetFriendly_pkey");

            entity.ToTable("PetFriendly");

            entity.HasIndex(e => e.Geom, "sidx_PetFriendly_geom").HasMethod("gist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Businessname)
                .HasColumnType("character varying")
                .HasColumnName("businessname");
            entity.Property(e => e.Date)
                .HasColumnType("character varying")
                .HasColumnName("date");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(Point,4326)")
                .HasColumnName("geom");
            entity.Property(e => e.MarkerColor)
                .HasColumnType("character varying")
                .HasColumnName("marker-color");
            entity.Property(e => e.MarkerSize)
                .HasColumnType("character varying")
                .HasColumnName("marker-size");
            entity.Property(e => e.MarkerSymbol)
                .HasColumnType("character varying")
                .HasColumnName("marker-symbol");
            entity.Property(e => e.UniqueId).HasColumnName("unique id");
        });

        modelBuilder.Entity<Trail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Trails_pkey");

            entity.HasIndex(e => e.Geom, "sidx_Trails_geom").HasMethod("gist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comments)
                .HasColumnType("character varying")
                .HasColumnName("comments");
            entity.Property(e => e.Conditionrating)
                .HasColumnType("character varying")
                .HasColumnName("conditionrating");
            entity.Property(e => e.Consequenceoffailure).HasColumnName("consequenceoffailure");
            entity.Property(e => e.Contractnumber)
                .HasColumnType("character varying")
                .HasColumnName("contractnumber");
            entity.Property(e => e.Createddate).HasColumnName("createddate");
            entity.Property(e => e.Createduser)
                .HasColumnType("character varying")
                .HasColumnName("createduser");
            entity.Property(e => e.Estimatedservicelife).HasColumnName("estimatedservicelife");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiLineString,4326)")
                .HasColumnName("geom");
            entity.Property(e => e.Inlucity).HasColumnName("inlucity");
            entity.Property(e => e.Installdate).HasColumnName("installdate");
            entity.Property(e => e.Lastediteddate).HasColumnName("lastediteddate");
            entity.Property(e => e.Lastediteduser)
                .HasColumnType("character varying")
                .HasColumnName("lastediteduser");
            entity.Property(e => e.Lastinspection)
                .HasColumnType("character varying")
                .HasColumnName("lastinspection");
            entity.Property(e => e.Lastsyncdate).HasColumnName("lastsyncdate");
            entity.Property(e => e.LengthM).HasColumnName("length_m");
            entity.Property(e => e.Lifestatus)
                .HasColumnType("character varying")
                .HasColumnName("lifestatus");
            entity.Property(e => e.Lucityautoid).HasColumnName("lucityautoid");
            entity.Property(e => e.Maintainedby)
                .HasColumnType("character varying")
                .HasColumnName("maintainedby");
            entity.Property(e => e.Municipality)
                .HasColumnType("character varying")
                .HasColumnName("municipality");
            entity.Property(e => e.Notes)
                .HasColumnType("character varying")
                .HasColumnName("notes");
            entity.Property(e => e.Objectid).HasColumnName("objectid");
            entity.Property(e => e.Obstructions)
                .HasColumnType("character varying")
                .HasColumnName("obstructions");
            entity.Property(e => e.Onoffroad)
                .HasColumnType("character varying")
                .HasColumnName("onoffroad");
            entity.Property(e => e.Ownedby)
                .HasColumnType("character varying")
                .HasColumnName("ownedby");
            entity.Property(e => e.Replacementcost).HasColumnName("replacementcost");
            entity.Property(e => e.Rmwid)
                .HasColumnType("character varying")
                .HasColumnName("rmwid");
            entity.Property(e => e.Segmentlucityautoid).HasColumnName("segmentlucityautoid");
            entity.Property(e => e.Settlement)
                .HasColumnType("character varying")
                .HasColumnName("settlement");
            entity.Property(e => e.Shapestlength).HasColumnName("shapestlength");
            entity.Property(e => e.Streetname)
                .HasColumnType("character varying")
                .HasColumnName("streetname");
            entity.Property(e => e.Surfacematerial)
                .HasColumnType("character varying")
                .HasColumnName("surfacematerial");
            entity.Property(e => e.Trailname)
                .HasColumnType("character varying")
                .HasColumnName("trailname");
            entity.Property(e => e.Trailtype)
                .HasColumnType("character varying")
                .HasColumnName("trailtype");
            entity.Property(e => e.WidthM).HasColumnName("width_m");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
