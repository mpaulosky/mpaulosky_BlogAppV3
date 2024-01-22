using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace BlazorBlog.Data;

public class MongoDbContext : DbContext
{
	
	public DbSet<BlogPost>? BlogPosts { get; init; }

	public MongoDbContext(DbContextOptions<MongoDbContext> options)
		: base(options)
	{
		Debug.WriteLine($"{ContextId} context created.");
	}
	
	public static MongoDbContext CreateContext(IMongoDatabase database)
	{
		return new MongoDbContext(new DbContextOptionsBuilder<MongoDbContext>()
			.UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
			.Options);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		
		base.OnModelCreating(modelBuilder);
		
		modelBuilder.Entity<BlogPost>().ToCollection("posts");

	}
	
	// Dispose pattern.
	public override void Dispose()
	{
		Debug.WriteLine($"{ContextId} context disposed.");
		base.Dispose();
	}

	// Dispose pattern.
	public override ValueTask DisposeAsync()
	{
		Debug.WriteLine($"{ContextId} context disposed async.");
		return base.DisposeAsync();
	}

}