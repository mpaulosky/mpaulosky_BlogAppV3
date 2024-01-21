// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     ServiceCollectionExtensions.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

namespace BlazorBlog.RegisterServices;

public static partial class ServiceCollectionExtensions
{
	
	/// <summary>
	/// Configures services for the web application.
	/// </summary>
	/// <param name="builder">The web application builder.</param>
	public static void ConfigureServices(this WebApplicationBuilder builder)
	{

		builder.RegisterApplicationComponets();
		
		builder.RegisterAuthentication();
		
		builder.RegisterIdentityServer();
		
		builder.RegisterMongoDbContext();

		builder.RegisterDataSources();
		
	}
	
}