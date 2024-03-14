// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogRepository.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

using BlazorBlog.Interfaces;

namespace BlazorBlog.Data;

/// <summary>
///   Data access implementation for MongoDB with BlogPost collection
/// </summary>
public class BlogRepository : IBlogRepository
{
	private readonly IMongoCollection<BlogPost> _posts;

	/// <summary>
	///   MongoBlogPostData constructor
	/// </summary>
	/// <param name="context">IMongoDbContext</param>
	/// <exception cref="ArgumentNullException"></exception>
	public BlogRepository(IMongoDbContextFactory context)
	{
		ArgumentNullException.ThrowIfNull(nameof(context));

		string collectionName = CollectionNames.GetCollectionName(nameof(BlogPost));

		_posts = context.GetCollection<BlogPost>(collectionName);
	}

	/// <summary>
	///   Archives a BlogPost async
	/// </summary>
	/// <param name="post">The BlogPost object to be archived</param>
	/// <returns>A task placeholder for the async operation</returns>
	public Task ArchiveAsync(BlogPost post)
	{
		var filter = Builders<BlogPost>.Filter.Eq("Id", post.Id);
		return _posts.ReplaceOneAsync(filter, post, new ReplaceOptions { IsUpsert = true });
	}

	/// <summary>
	///   Creates a BlogPost async
	/// </summary>
	/// <param name="post">The BlogPost object to be created</param>
	/// <returns>A task placeholder for the async operation</returns>
	public Task CreateAsync(BlogPost post)
	{
		return _posts.InsertOneAsync(post);
	}

	Task<IEnumerable<BlogPost>?> IBlogRepository.GetAllAsync()
	{
		throw new NotImplementedException();
	}

	/// <summary>
	///   Gets all BlogPost objects async
	/// </summary>
	/// <returns>A List of all the BlogPost objects</returns>
	public async Task<List<BlogPost>> GetAllAsync()
	{
		var results = await _posts.FindAsync(_ => true);

		return results.ToList();
	}

	/// <summary>
	///   Gets a BlogPost object by looking up its URL async
	/// </summary>
	/// <param name="url">The URL of the BlogPost to look up</param>
	/// <returns>The BlogPost corresponding to the URL provided or null if it doesn't exist</returns>
	public async Task<BlogPost?> GetByUrlAsync(string url)
	{
		var results = await _posts.FindAsync(u => u.Url == url);
		return results.FirstOrDefault();
	}

	public Task<BlogPost?> GetByAuthorAsync(string author)
	{
		throw new NotImplementedException();
	}

	public Task<BlogPost?> GetByTitleAsync(string title)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	///   Updates a BlogPost asynchronously
	/// </summary>
	/// <param name="post">The BlogPost object to be updated</param>
	/// <returns>A task placeholder for the async operation</returns>
	public Task UpdateAsync(BlogPost post)
	{
		var filter = Builders<BlogPost>.Filter.Eq("Id", post.Id);
		return _posts.ReplaceOneAsync(filter, post, new ReplaceOptions { IsUpsert = true });
	}
}