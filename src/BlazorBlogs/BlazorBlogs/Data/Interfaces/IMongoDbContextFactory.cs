// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     IMongoDbContextFactory.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using MongoDB.Driver;

namespace BlazorBlogs.Data.Interfaces;

public interface IMongoDbContextFactory
{
	IMongoDatabase Database { get; }

	IMongoClient Client { get; }

	string ConnectionString { get; }

	string DbName { get; }

	IMongoCollection<BlogPost?> GetCollection<T>(string name);
}