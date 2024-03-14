// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     CollectionNames.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

namespace BlazorBlogs.Data.Helpers;

/// <summary>
///   CollectionNames class
/// </summary>
public static class CollectionNames
{
	/// <summary>
	///   GetCollectionName method
	/// </summary>
	/// <param name="entityName">string</param>
	/// <returns>string collection name</returns>
	public static string GetCollectionName(string entityName)
	{
		return entityName switch
		{
			"BlogPost" => "posts",
			_ => ""
		};
	}
}