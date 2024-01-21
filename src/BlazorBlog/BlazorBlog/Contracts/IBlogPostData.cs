namespace BlazorBlog.Contracts;

public interface IBlogPostData
{
	Task ArchiveAsync(BlogPost post);

	Task CreateAsync(BlogPost post);

	Task<BlogPost?> GetByUrlAsync(string url);

	Task<List<BlogPost>?> GetAllAsync();

	Task UpdateAsync(BlogPost post);
}