// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     RegisterApplicationComponets.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

namespace BlazorBlog.RegisterServices;

public static partial class ServiceCollectionExtensions
{
	
	/// <summary>
	/// Registers the application components.
	/// </summary>
	/// <param name="builder">The web application builder.</param>
	public static void RegisterApplicationComponets(this WebApplicationBuilder builder)
	{
		
		builder.Services.AddRazorComponents()
			.AddInteractiveServerComponents()
			.AddInteractiveWebAssemblyComponents();
		
	}
	
}