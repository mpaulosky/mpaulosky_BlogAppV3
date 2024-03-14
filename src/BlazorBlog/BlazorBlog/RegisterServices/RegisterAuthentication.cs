// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterAuthentication.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorBlog.RegisterServices;

public static partial class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers the necessary services for authentication.
	/// </summary>
	/// <param name="builder">The <see cref="WebApplicationBuilder"/> instance used to configure the application.</param>
	private static void RegisterAuthentication(this WebApplicationBuilder builder)
	{

		builder.Services.AddCascadingAuthenticationState();
		builder.Services.AddScoped<IdentityUserAccessor>();
		builder.Services.AddScoped<IdentityRedirectManager>();
		builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

		builder.Services.AddAuthentication(options =>
			{
				options.DefaultScheme = IdentityConstants.ApplicationScheme;
				options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
			})
			.AddIdentityCookies();

	}

}