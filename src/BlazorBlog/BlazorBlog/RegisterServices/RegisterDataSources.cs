// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterDataSources.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

namespace BlazorBlog.RegisterServices;

public static partial class ServiceCollectionExtensions
{

	/// <summary>
	/// Register DataSources
	/// </summary>
	/// <param name="builder"></param>
	private static void RegisterDataSources(this WebApplicationBuilder builder)
	{

		// Add services to the container.
		builder.Services.AddSingleton<IBlogPostRepository, BlogPostRepository>();
		// builder.Services.AddSingleton<IBlogService, BlogPostService>();

	}

}