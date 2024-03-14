// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BlogService.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

using BlazorBlog.Interfaces;

namespace BlazorBlog.Data.Services;

public class BlogService : IBlogService
{
	private readonly IBlogRepository _data;

	/// <summary>
	///   Initializes a new instance of the <see cref="BlogService" /> class with an instance of
	///   <see cref="IBlogRepository" />.
	/// </summary>
	/// <param name="data">The <see cref="IBlogRepository" /> instance to be used by this class.</param>
	public BlogService(IBlogRepository data)
	{
		_data = data;
	}

	/// <summary>
	///   Archives the specified blog post.
	/// </summary>
	/// <param name="post">The blog post to be archived.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	public Task ArchiveAsync(BlogPost post)
	{
		ArgumentNullException.ThrowIfNull(nameof(post));

		return _data.ArchiveAsync(post);
	}

	/// <summary>
	///   Creates a new blog post.
	/// </summary>
	/// <param name="post">The blog post to be created.</param>
	/// <returns>
	///   A task that represents the asynchronous operation. The task result contains the created
	///   <see cref="BlogPost" /> instance.
	/// </returns>
	public Task CreateAsync(BlogPost post)
	{
		ArgumentNullException.ThrowIfNull(nameof(post));

		return _data.CreateAsync(post);
	}

	/// <summary>
	///   Gets all the blog posts.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result contains a list of all the blog posts.</returns>
	public async Task<List<BlogPost>?> GetAllAsync()
	{
		return await _data.GetAllAsync() as List<BlogPost>;
	}

	/// <summary>
	///   Gets the blog post by the specified URL.
	/// </summary>
	/// <param name="url">The URL of the blog post to be retrieved.</param>
	/// <returns>
	///   A task that represents the asynchronous operation. The task result contains the retrieved
	///   <see cref="BlogPost" /> instance.
	/// </returns>
	public async Task<BlogPost?> GetByUrlAsync(string url)
	{
		ArgumentException.ThrowIfNullOrEmpty(nameof(url));
		return await _data.GetByUrlAsync(url);
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
	///   Updates the specified blog post.
	/// </summary>
	/// <param name="post">The blog post to be updated.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	public Task UpdateAsync(BlogPost post)
	{
		ArgumentNullException.ThrowIfNull(nameof(post));
		return _data.UpdateAsync(post);
	}
}