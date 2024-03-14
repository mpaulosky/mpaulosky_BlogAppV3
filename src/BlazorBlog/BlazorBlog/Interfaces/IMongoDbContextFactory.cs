// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     IMongoDbContextFactory.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

namespace BlazorBlog.Interfaces;

public interface IMongoDbContextFactory
{
	string ConnectionString { get; }

	string DbName { get; }

	IMongoDatabase Database { get; }

	MongoClient Client { get; }

	IMongoCollection<T> GetCollection<T>(string name);
}