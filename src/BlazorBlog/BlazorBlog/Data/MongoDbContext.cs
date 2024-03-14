// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     MongoDbContext.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

using Microsoft.EntityFrameworkCore;

using MongoDB.EntityFrameworkCore.Extensions;

namespace BlazorBlog.Data;

public class MongoDbContext : DbContext
{
	public MongoDbContext(DbContextOptions options)
		: base(options)
	{
	}

	public DbSet<BlogPost> BlogPosts { get; init; }

	public static MongoDbContext Create(IMongoDatabase database)
	{
		return new MongoDbContext(new DbContextOptionsBuilder<MongoDbContext>()
			.UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
			.Options);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<BlogPost>()
			.HasQueryFilter(x => x.IsArchived == false)
			.ToCollection("posts");
	}
}