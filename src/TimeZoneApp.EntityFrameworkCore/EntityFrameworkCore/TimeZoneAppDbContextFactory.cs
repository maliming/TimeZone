﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TimeZoneApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class TimeZoneAppDbContextFactory : IDesignTimeDbContextFactory<TimeZoneAppDbContext>
{
    public TimeZoneAppDbContext CreateDbContext(string[] args)
    {
        TimeZoneAppEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<TimeZoneAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new TimeZoneAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TimeZoneApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
