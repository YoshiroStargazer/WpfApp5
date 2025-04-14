﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp5.Models;

public partial class _1Context : DbContext
{
    public _1Context()
    {
    }

    public _1Context(DbContextOptions<_1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-2MRBCQD7;Initial Catalog=1;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>(entity =>
        {
            entity.ToTable("Driver");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.AddressLife_)
                .HasMaxLength(255)
                .HasColumnName("AddressLife]");
            entity.Property(e => e.Company).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.JobName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.PassportNumber).HasMaxLength(50);
            entity.Property(e => e.PassportSerial).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PhotoDescription).HasMaxLength(255);
            entity.Property(e => e.PostCode).HasMaxLength(50);
            entity.Property(e => e.middlename).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}