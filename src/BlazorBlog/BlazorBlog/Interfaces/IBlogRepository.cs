namespace BlazorBlog.Interfaces;

public interface IBlogRepository
{
	Task ArchiveAsync(BlogPost post);

	Task CreateAsync(BlogPost post);

	Task<IEnumerable<BlogPost>?> GetAllAsync();

	Task<BlogPost?> GetByUrlAsync(string url);

	Task<BlogPost?> GetByAuthorAsync(string author);

	Task<BlogPost?> GetByTitleAsync(string title);

	Task UpdateAsync(BlogPost post);
}