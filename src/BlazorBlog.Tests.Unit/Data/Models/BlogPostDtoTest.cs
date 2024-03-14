// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostDtoTest.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

using NSubstitute;

namespace BlazorBlog.Tests.Unit.Data.Models;

[TestSubject(typeof(BlogPostDto))]
[ExcludeFromCodeCoverage]
public class BlogPostDtoTest
{
	[Fact]
	public void TestBlogPostDtoCreation()
	{
		var blogPostDto = new BlogPostDto();
		Assert.NotNull(blogPostDto);
	}

	[Fact]
	public void TestDateTimeNotNull()
	{
		var dateTimeWrapper = Substitute.For<IDateTimeWrapper>();
		dateTimeWrapper.Now.Returns(new DateTime(2024, 01, 01, 10, 00, 00));
		var blogPostDto = new BlogPostDto { Created = dateTimeWrapper.Now };
		blogPostDto.Created.Should().Be(dateTimeWrapper.Now);
	}

	[Fact]
	public void TestIsPublishedDefaultValue()
	{
		var blogPostDto = new BlogPostDto();
		blogPostDto.IsPublished.Should().BeFalse();
	}

	[Fact]
	public void TestFieldsAfterInitialization()
	{
		var blogPostDto = new BlogPostDto();
		blogPostDto.Image.Should().BeEmpty();
		blogPostDto.IsArchived.Should().BeFalse();
	}

	[Fact]
	public void TestAuthorAfterInitialization()
	{
		var blogPostDto = new BlogPostDto();
		blogPostDto.Author.Should().NotBeNull();
	}
}