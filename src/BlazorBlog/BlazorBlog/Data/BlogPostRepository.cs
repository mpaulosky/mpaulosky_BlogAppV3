using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Data;

/// <summary>
///   Data access implementation for MongoDB with BlogPost collection
/// </summary>
public class BlogPostRepository : IBlogPostRepository
{
	
	private readonly IDbContextFactory<MongoDbContext> _dbContextFactory;
	
	/// <summary>
	///   MongoBlogPostData constructor
	/// </summary>
	/// <param name="dbFactory">IDbContextFactory MongoDbContext</param>
	/// <exception cref="ArgumentNullException"></exception>
	public BlogPostRepository(IDbContextFactory<MongoDbContext> dbFactory)
	{
		
		_dbContextFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
		
	}

	/// <summary>
	///   Archives a BlogPost async
	/// </summary>
	/// <param name="post">The BlogPost object to be archived</param>
	/// <returns>A task placeholder for the async operation</returns>
	public async Task ArchiveAsync(BlogPost post)
	{
		
		await using var context = await _dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);
		 context.BlogPosts?.Attach(post);
		 context.BlogPosts?.Update(post);
		 await context.SaveChangesAsync();
		 
	}

	/// <summary>
	///   Creates a BlogPost async
	/// </summary>
	/// <param name="post">The BlogPost object to be created</param>
	/// <returns>A task placeholder for the async operation</returns>
	public async Task CreateAsync(BlogPost post)
	{
		
		await using var context = await _dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);
		context.BlogPosts?.Add(post);
		await context.SaveChangesAsync();
		
	}

	/// <summary>
	///   Gets all BlogPost objects async
	/// </summary>
	/// <returns>A List of all the BlogPost objects</returns>
	public async Task<IEnumerable<BlogPost>?> GetAllAsync()
	{
		
		await using var context = await _dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);
		var result = await (context.BlogPosts ?? throw new InvalidOperationException()).ToListAsync();
		return result;

	}

	/// <summary>
	///   Gets a BlogPost object by looking up its URL async
	/// </summary>
	/// <param name="url">The URL of the BlogPost to look up</param>
	/// <returns>The BlogPost corresponding to the URL provided or null if it doesn't exist</returns>
	public async Task<BlogPost?> GetByUrlAsync(string url)
	{
		
		await using var context = await _dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);
		return await (context.BlogPosts ?? throw new InvalidOperationException()).FirstOrDefaultAsync(b => b.Url == url);
		
	}

	/// <summary>
	///   Updates a BlogPost asynchronously
	/// </summary>
	/// <param name="post">The BlogPost object to be updated</param>
	/// <returns>A task placeholder for the async operation</returns>
	public async Task UpdateAsync(BlogPost post)
	{
		
		await using var context = await _dbContextFactory.CreateDbContextAsync().ConfigureAwait(false);
		context.BlogPosts?.Attach(post);
		context.BlogPosts?.Update(post);
		await context.SaveChangesAsync();
		
	}
}