// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogPostTest.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

using NSubstitute;

namespace BlazorBlog.Tests.Unit.Data.Models;

[TestSubject(typeof(BlogPost))]
[ExcludeFromCodeCoverage]
public class BlogPostTest
{
	[Fact]
	public void Id_ShouldGetAndSetId()
	{
		var bp = new BlogPost();
		bp.Id.Should().BeEmpty();

		bp.Id = "TestId";
		bp.Id.Should().Be("TestId");
	}

	[Fact]
	public void ObjectIdentifier_ShouldGetAndSetObjectIdentifier()
	{
		var bp = new BlogPost();
		bp.ObjectIdentifier.Should().BeEmpty();

		bp.ObjectIdentifier = "TestObjectIdentifier";
		bp.ObjectIdentifier.Should().Be("TestObjectIdentifier");
	}

	[Fact]
	public void Url_ShouldGetAndSetUrl()
	{
		var bp = new BlogPost();
		bp.Url.Should().BeEmpty();

		bp.Url = $"https://www.testurl.com";
		bp.Url.Should().Be($"https://www.testurl.com");
	}

	[Fact]
	public void Title_ShouldGetAndSetTitle()
	{
		var bp = new BlogPost();
		bp.Title.Should().BeEmpty();

		bp.Title = "TestTitle";
		bp.Title.Should().Be("TestTitle");
	}

	[Fact]
	public void Content_ShouldGetAndSetContent()
	{
		var bp = new BlogPost();
		bp.Content.Should().BeEmpty();

		bp.Content = "TestContent";
		bp.Content.Should().Be("TestContent");
	}

	[Fact]
	public void Created_ShouldGetAndSetCreated()
	{
		var dateTimeWrapper = Substitute.For<IDateTimeWrapper>();
		dateTimeWrapper.Now.Returns(new DateTime(2024, 01, 01, 10, 00, 00));

		var bp = new BlogPost();
		bp.Created.Should().BeNull();

		bp.Created = dateTimeWrapper.Now ;
		bp.Created.Should().Be(dateTimeWrapper.Now );
	}

	[Fact]
	public void Updated_ShouldGetAndSetUpdated()
	{
		var dateTimeWrapper = Substitute.For<IDateTimeWrapper>();
		dateTimeWrapper.Now.Returns(new DateTime(2024, 01, 01, 10, 00, 00));

		var bp = new BlogPost();
		bp.Updated.Should().BeNull();

		bp.Updated = dateTimeWrapper.Now ;
		bp.Updated.Should().Be(dateTimeWrapper.Now );
	}

	[Fact]
	public void Description_ShouldGetAndSetDescription()
	{
		var bp = new BlogPost();
		bp.Description.Should().BeEmpty();

		bp.Description = "TestDescription";
		bp.Description.Should().Be("TestDescription");
	}

	[Fact]
	public void Image_ShouldGetAndSetImage()
	{
		var bp = new BlogPost();
		bp.Image.Should().BeEmpty();

		bp.Image = "TestImage";
		bp.Image.Should().Be("TestImage");
	}

	[Fact]
	public void IsPublished_ShouldGetAndSetIsPublished()
	{
		var bp = new BlogPost();
		bp.IsPublished.Should().BeFalse();

		bp.IsPublished = true;
		bp.IsPublished.Should().Be(true);
	}

	[Fact]
	public void IsArchived_ShouldGetAndSetIsArchived()
	{
		var bp = new BlogPost();
		bp.IsArchived.Should().BeFalse();

		bp.IsArchived = true;
		bp.IsArchived.Should().Be(true);
	}
}