// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeBlogPostTests.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

namespace BlazorBlog.Tests.Unit.Data.Fakes;

[TestSubject(typeof(FakeBlogPost))]
[ExcludeFromCodeCoverage]
public class FakeBlogPostTests
{
	[Theory(DisplayName = "FakeBlogPost GetNewBlogPost Test")]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewBlogPost_With_IncludeID_TrueOrFalse_Test(bool expected)
	{
		// Arrange
		var blogpost = FakeBlogPost.GetNewBlogPost(expected);

		// Act
		var result = blogpost;

		// Assert
		if (!expected)
		{
			result.Id.Should().BeNullOrWhiteSpace();
			result.Should().BeEquivalentTo(blogpost);
		}
		else
		{
			result.Id.Should().NotBeNullOrWhiteSpace();
			result.Should().BeEquivalentTo(blogpost);
		}
	}


	[Theory(DisplayName = "FakeBlogPost GetNewBlogPosts Test")]
	[InlineData(1)]
	[InlineData(5)]
	public void GetBasicUsers_With_Count_Should_Return_Requested_Number_Of_BlogPosts_Test(int expectedCount)
	{
		// Arrange
		var expected = FakeBlogPost.GetNewBlogPosts(expectedCount);
		
		// Act
		var result = expected;

		// Assert
		result.Count.Should().Be(expectedCount);
		result.Should().BeEquivalentTo(expected);
	}

	[Theory(DisplayName = "FakeBlogPost GetIEnumerableBlogPosts Test")]
	[InlineData(1)]
	[InlineData(5)]
	public void GetIEnumerableBlogPosts_With_Count_Should_Return_Requested_Number_Of_BlogPosts_Test(int expectedCount)
	{
		// Arrange
		var expected = FakeBlogPost.GetIEnumerableBlogPosts(expectedCount);
		
		// Act
		var result = expected;
		
		// Assert
		result.Count().Should().Be(expectedCount);
		result.Should().BeEquivalentTo(expected);
	}
}