﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mimirorg.TypeLibrary.Enums;
using TypeLibrary.Core.Extensions;
using TypeLibrary.Data;
using TypeLibrary.Data.Contracts;
using TypeLibrary.Data.Models;
using TypeLibrary.Services.Contracts;
using TypeLibrary.Services.Services;
using TypeLibrary.Services.Tests.Repositories;

namespace TypeLibrary.Services.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add in memory database
            var options = new DbContextOptionsBuilder<TypeLibraryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TypeLibraryDbContext(options);

            // Create some initial data

            #region RDS

            var rdsCategory = new RdsCategoryLibDm
            {
                Id = "Fake_Rds_Category",
                Name = "Fake Rds Category",
                Created = DateTime.Now,
                CreatedBy = "Test Tester"
            };

            var rds = new RdsLibDm
            {
                Id = "Fake_Rds",
                Name = "Fake Rds",
                Iri = @"https://rds.fake.com/Fake Rds",
                RdsCategoryId = "Fake_Rds_Category",
                Code = "FR",
                Aspect = Aspect.Function
            };

            context.RdsCategory.Add(rdsCategory);
            context.Rds.Add(rds);

            #endregion

            #region Purpose

            var purpose = new PurposeLibDm
            {
                Id = "Fake_Purpose",
                Name = "Fake Purpose",
                Iri = @"https://purpose.fake.com/Fake Purpose",
                Discipline = Discipline.Electrical,
                Created = DateTime.Now,
                CreatedBy = "Test Tester"
            };

            context.Purpose.Add(purpose);

            #endregion

            context.SaveChanges();
            services.AddSingleton(context);

            services.AddSingleton<IAttributeRepository, FakeAttributeRepository>();
            services.AddSingleton<INodeRepository, FakeNodeRepository>();
            services.AddSingleton<ISimpleRepository, FakeSimpleRepository>();
            services.AddSingleton<ITransportRepository, FakeTransportRepository>();
            services.AddSingleton<ILibraryService, LibraryService>();

            // Add auto-mapper configurations
            services.AddAutoMapperConfigurations();
        }
    }
}