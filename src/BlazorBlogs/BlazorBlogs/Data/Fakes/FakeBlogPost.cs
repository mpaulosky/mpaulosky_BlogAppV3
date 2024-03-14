﻿// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeBlogPost.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using Bogus;

using MongoDB.Bson;

namespace BlazorBlogs.Data.Fakes;

public class FakeBlogPost
{
	/// <summary>
	///   Gets a new post.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <param name="useNewSeed">bool whether to use a seed other than 0</param>
	/// <returns>BlogPost</returns>
	public static BlogPost? GetNewBlogPost(bool keepId = false)
	{
		BlogPost? post = GenerateFake().Generate();

		if (!keepId)
		{
			post.Id = string.Empty;
		}

		post.IsArchived = false;
		post.ArchivedBy = new();

		return post;
	}

	public static List<BlogPost> GetNewBlogPosts(int numberOfPosts)
	{
		List<BlogPost>? posts = GenerateFake().Generate(numberOfPosts);

		foreach (BlogPost? post in posts)
		{
			post.IsPublished = false;
			post.IsArchived = false;
			post.ArchivedBy = new();
		}

		return posts;
	}

	/// <summary>
	///   Gets a IEnumerable list of posts.
	/// </summary>
	/// <param name="numberOfPosts">The number of posts.</param>
	/// <param name="useNewSeed">bool whether to use a seed other than 0</param>
	/// <returns>A IEnumerable List of BlogPost</returns>
	public static IEnumerable<BlogPost> GetIEnumerableBlogPosts(int numberOfPosts)
	{
		List<BlogPost>? posts = GenerateFake().Generate(numberOfPosts);

		foreach (BlogPost? post in posts)
		{
			if (post.IsArchived)
			{
				post.ArchivedBy = FakeBasicUser.GetBasicUser();
			}
			else
			{
				post.ArchivedBy = new BasicUser();
			}
		}

		return posts;
	}

	/// <summary>
	///   GenerateFake method
	/// </summary>
	/// <param name="useNewSeed">bool whether to use a seed other than 0</param>
	/// <returns>Fake BlogPost</returns>
	private static Faker<BlogPost> GenerateFake()
	{
		return new Faker<BlogPost>()
			.RuleFor(x => x.Id, new BsonObjectId(ObjectId.GenerateNewId()).ToString())
			.RuleFor(x => x.ObjectIdentifier, new BsonObjectId(ObjectId.GenerateNewId()).ToString())
			.RuleFor(c => c.Title, f => f.Lorem.Sentence(10))
			.RuleFor(x => x.Url, f => f.Internet.Url())
			.RuleFor(x => x.Description, f => f.Lorem.Paragraph(1))
			.RuleFor(x => x.Content, f => f.Lorem.Paragraphs(10))
			.RuleFor(x => x.Author, FakeBasicUser.GetBasicUser())
			.RuleFor(x => x.Created, f => f.Date.Past())
			.RuleFor(x => x.Updated, f => f.Date.Past())
			.RuleFor(x => x.IsPublished, f => f.Random.Bool())
			.RuleFor(x => x.IsArchived, f => f.Random.Bool())
			.RuleFor(x => x.Image, f => f.Image.PicsumUrl(1060, 300, false, false, 201));
	}
}