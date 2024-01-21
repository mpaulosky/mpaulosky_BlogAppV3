// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterIdentityServer.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.RegisterServices;

public static partial class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers the Identity Server configuration and services.
	/// </summary>
	/// <param name="builder">The web application builder.</param>
	/// <exception cref="InvalidOperationException">Thrown when the connection string 'DefaultConnection' is not found.</exception>
	public static void RegisterIdentityServer(this WebApplicationBuilder builder)
	{
		
		var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
		                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

		builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(connectionString));

		builder.Services.AddDatabaseDeveloperPageExceptionFilter();

		builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddSignInManager()
			.AddDefaultTokenProviders();

		builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
		
	}
	
}