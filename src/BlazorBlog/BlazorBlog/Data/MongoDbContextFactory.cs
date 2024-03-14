// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     MongoDbContextFactory.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlog
// =============================================

using BlazorBlog.Interfaces;

namespace BlazorBlog.Data;

/// <summary>
///   MongoDbContext class
/// </summary>
public class MongoDbContextFactory : IMongoDbContextFactory
{
	/// <summary>
	///   MongoDbContextFactory constructor
	/// </summary>
	/// <param name="settings">IDatabaseSettings</param>
	public MongoDbContextFactory(IDatabaseSettings settings)
	{
		ConnectionString = settings.ConnectionStrings;

		DbName = settings.DatabaseName;

		Client = new MongoClient(settings.ConnectionStrings);

		Database = Client.GetDatabase(settings.DatabaseName);
	}

	/// <summary>
	///   Gets the client.
	/// </summary>
	/// <value>
	///   The client.
	/// </value>
	private MongoClient Client { get; }

	/// <summary>
	///   Gets the database.
	/// </summary>
	/// <value>
	///   The database.
	/// </value>
	private IMongoDatabase Database { get; }

	/// <summary>
	///   Gets the connection string.
	/// </summary>
	/// <value>
	///   The connection string.
	/// </value>
	public string ConnectionString { get; }

	/// <summary>
	///   Gets the name of the database.
	/// </summary>
	/// <value>
	///   The name of the database.
	/// </value>
	public string DbName { get; }

	IMongoDatabase IMongoDbContextFactory.Database => throw new NotImplementedException();

	MongoClient IMongoDbContextFactory.Client => throw new NotImplementedException();

	/// <summary>
	///   GetCollection method
	/// </summary>
	/// <param name="name">string collection name</param>
	/// <typeparam name="T">The Entity Name cref="CategoryModel"</typeparam>
	/// <returns>IMongoCollection</returns>
	/// <exception cref="ArgumentNullException"></exception>
	public IMongoCollection<T> GetCollection<T>(string name)
	{
		ArgumentException.ThrowIfNullOrEmpty(nameof(name));

		IMongoCollection<T> collection = Database.GetCollection<T>(name);

		return collection;
	}
}