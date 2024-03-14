// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeBlogPostDtoTests.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

namespace BlazorBlog.Tests.Unit.Data.Fakes;

[TestSubject(typeof(FakeBlogPostDto))]
[ExcludeFromCodeCoverage]
public class FakeBlogPostDtoTests
{
	[Theory(DisplayName = "FakeBlogPostDto GetNewBlogPostDto Test")]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewBlogPostDto_With_IncludeID_TrueOrFalse_Test(bool expected)
	{
		// Arrange
		var blogpost = FakeBlogPostDto.GetNewBlogPostDto();

		// Act
		var result = blogpost;

		// Assert
		if (!expected)
		{
			result.Should().BeEquivalentTo(blogpost);
		}
		else
		{
			result.Should().BeEquivalentTo(blogpost);
		}
	}
}