// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterMongoDbContext.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.RegisterServices;

public static partial class ServiceCollectionExtensions
{
	private static void RegisterDbContextFactory(this WebApplicationBuilder builder)
	{
		
		// Get the MongoDbSettings section from the appsettings.json file.
		IConfigurationSection section = builder.Configuration.GetSection("MongoDbSettings")
		                                ?? throw new InvalidOperationException("Section 'MongoDbSettings' not found.");

		// Get the DatabaseSettings from the appsettings.json file.
		DatabaseSettings mongoSettings = section.Get<DatabaseSettings>() ?? throw new ArgumentNullException(nameof(mongoSettings.DatabaseName));
	
		// Register the IDatabaseSettings with the DI container.
		builder.Services.AddSingleton<IDatabaseSettings>(mongoSettings);
		
		var mongoClient = new MongoClient(mongoSettings.ConnectionStrings);

		// Register the AddDbContextFactory with the DI container.
		builder.Services.AddDbContextFactory<MongoDbContext>(opt =>
			opt.UseMongoDB(mongoClient, mongoSettings.DatabaseName));
		
	}

}