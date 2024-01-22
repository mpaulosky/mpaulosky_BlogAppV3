namespace BlazorBlog.Contracts;

public interface IBlogPostRepository
{
	Task ArchiveAsync(BlogPost post);

	Task CreateAsync(BlogPost post);

	Task<BlogPost?> GetByUrlAsync(string url);

	Task<IEnumerable<BlogPost>?> GetAllAsync();

	Task UpdateAsync(BlogPost post);
}