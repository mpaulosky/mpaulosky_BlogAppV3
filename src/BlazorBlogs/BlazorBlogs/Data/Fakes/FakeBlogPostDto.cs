// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeBlogPostDto.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using Bogus;

namespace BlazorBlogs.Data.Fakes;

public class FakeBlogPostDto
{
	/// <summary>
	///   Gets a new post dto.
	/// </summary>
	/// <returns>BlogPostDto</returns>
	public static BlogPostDto GetNewBlogPostDto()
	{
		BlogPostDto? post = GenerateFake().Generate();

		return post;
	}

	/// <summary>
	///   GenerateFake method
	/// </summary>
/// <returns>Fake BlogPostDto</returns>
	private static Faker<BlogPostDto> GenerateFake()
	{
		return new Faker<BlogPostDto>()
			.RuleFor(x => x.Url, f => $"{f.Name.FirstName()}-{f.Name.LastName()}")
			.RuleFor(c => c.Title, f => f.Lorem.Sentence(10))
			.RuleFor(x => x.Description, f => f.Lorem.Paragraph(1))
			.RuleFor(x => x.Content, f => f.Lorem.Paragraphs(10))
			.RuleFor(x => x.Author, FakeBasicUser.GetBasicUser())
			.RuleFor(x => x.Created, f => f.Date.Past())
			.RuleFor(x => x.IsPublished, f => f.Random.Bool())
			.RuleFor(x => x.IsArchived, f => f.Random.Bool())
			.RuleFor(x => x.Image, f => f.Image.PicsumUrl(1060, 300, false, false, 12));
	}
}