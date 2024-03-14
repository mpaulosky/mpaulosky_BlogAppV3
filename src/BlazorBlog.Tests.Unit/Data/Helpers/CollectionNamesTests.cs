// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     CollectionNamesTests.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

using BlazorBlogs.Data.Helpers;

using static BlazorBlogs.Data.Helpers.CollectionNames;

namespace BlazorBlog.Tests.Unit.Data.Helpers;

[TestSubject(typeof(CollectionNames))]
[ExcludeFromCodeCoverage]
public class CollectionNamesTests
{
	[Theory(DisplayName = "Helpers GetCollectionName Tests")]
	[InlineData("BlogPost", "posts")]
	public void GetCollectionName_WithValidInput_Should_ReturnExpectedValue(string entityName, string expected)
	{
		// Arrange

		// Act
		string result = GetCollectionName(entityName);

		// Assert
		result.Should().Be(expected);
	}
}