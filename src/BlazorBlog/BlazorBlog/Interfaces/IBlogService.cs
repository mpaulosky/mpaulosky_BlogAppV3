namespace BlazorBlog.Contracts;

public interface IBlogService
{
	Task ArchiveAsync(BlogPost post);

	Task CreateAsync(BlogPost post);

	Task<List<BlogPost>?> GetAllAsync();

	Task<BlogPost?> GetByUrlAsync(string url);

	Task<BlogPost?> GetByAuthorAsync(string author);

	Task<BlogPost?> GetByTitleAsync(string title);

	Task UpdateAsync(BlogPost post);
}