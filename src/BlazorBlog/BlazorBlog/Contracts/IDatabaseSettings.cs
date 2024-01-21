namespace BlazorBlog.Contracts;

public interface IDatabaseSettings
{
	string ConnectionStrings { get; init; }

	string DatabaseName { get; init; }
}