﻿// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     MongoDbServiceExtensions.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlogServiceApp
// Project Name :  BlogService.UI.Tests.Playwright
// =============================================

using BlazorBlog.Contracts;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorBlog;

[ExcludeFromCodeCoverage]
public static class MongoDbServiceExtensions
{
	private static void UpdateDatabaseServices(this IServiceCollection services, IDatabaseSettings settings)
	{
		//services.RemoveAll<IDatabaseSettings>();
		//services.RemoveAll<IMongoDbContextFactory>();

		//services.AddSingleton(_ => settings);

		//services.AddSingleton<IMongoDbContextFactory>(_ => new MongoDbContextFactory(settings));
	}

	public static IHostBuilder UpdateDatabaseServices(this IHostBuilder builder, IDatabaseSettings settings) =>
		builder.ConfigureServices(services => services.UpdateDatabaseServices(settings));

	public static IWebHostBuilder UpdateDatabaseServices(this IWebHostBuilder builder, IDatabaseSettings settings) =>
		builder.ConfigureServices(services => services.UpdateDatabaseServices(settings));
}