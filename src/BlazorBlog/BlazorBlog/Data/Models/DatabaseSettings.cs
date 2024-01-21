namespace BlazorBlog.Data.Models;

/// <summary>
///   DatabaseSettings class
/// </summary>
public class DatabaseSettings(string connectionStrings, string databaseName) : IDatabaseSettings
{
	public string ConnectionStrings { get; init; } = connectionStrings;

	public string DatabaseName { get; init; } = databaseName;
}