using BlazorBlogs.Data.Services;

namespace BlazorBlog.Tests.Unit.Data.Services;

[TestSubject(typeof(BlogService))]
[ExcludeFromCodeCoverage]
public class BlogServiceTest
{
	private readonly Mock<IBlogRepository> _dataMock = new();
	private readonly BlogService _service;

	public BlogServiceTest()
	{
		_service = new BlogService(_dataMock.Object);
	}

	[Fact]
	public async Task ArchiveAsync_PostIsNotNull_NoExceptionThrown()
	{
		var blogPost = new BlogPost();
		await _service.ArchiveAsync(blogPost);
		_dataMock.Verify(x => x.ArchiveAsync(blogPost), Times.Once);
	}

	[Fact]
	public async Task ArchiveAsync_PostIsNull_ThrowsArgumentNullException()
	{
		Func<Task> act = async () => await _service.ArchiveAsync(null);
		await act.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task CreateAsync_PostIsNotNull_NoExceptionThrown()
	{
		var blogPost = new BlogPost();
		await _service.CreateAsync(blogPost);
		_dataMock.Verify(x => x.CreateAsync(blogPost), Times.Once);
	}

	[Fact]
	public async Task CreateAsync_PostIsNull_ThrowsArgumentNullException()
	{
		Func<Task> act = async () => await _service.CreateAsync(null);
		await act.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task GetAllAsync_Should_Return_Results_TestAsync()
	{
		await _service.GetAllAsync();
		_dataMock.Verify(x => x.GetAllAsync(), Times.Once);
	}

	[Fact]
	public async Task GetByIdAsync_IdIsNotNullOrWhiteSpace_NoExceptionThrown()
	{
		var id = "testId";
		await _service.GetByIdAsync(id);
		_dataMock.Verify(x => x.GetByIdAsync(id), Times.Once);
	}

	[Fact]
	public async Task GetByIdAsync_IdIsNull_ThrowsArgumentException()
	{
		Func<Task> act = async () => await _service.GetByIdAsync(null);
		await act.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task GetByIdAsync_IdIsStringEmpty_ThrowsArgumentException()
	{
		Func<Task> act = async () => await _service.GetByIdAsync("");
		await act.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task GetByUrlAsync_UrlIsNotNullOrEmpty_NoExceptionThrown()
	{
		var url = "https://example.com";
		await _service.GetByUrlAsync(url);
		_dataMock.Verify(x => x.GetByUrlAsync(url), Times.Once);
	}

	[Fact]
	public async Task GetByUrlAsync_UrlIsNull_ThrowsArgumentException()
	{
		Func<Task> act = async () => await _service.GetByUrlAsync(null);
		await act.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task GetByUrlAsync_UrlIsEmpty_ThrowsArgumentException()
	{
		Func<Task> act = async () => await _service.GetByUrlAsync("");
		await act.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task GetByAuthorIdAsync_AuthorIdIsNotNullOrEmpty_NoExceptionThrown()
	{
		var authorId = "testAuthorId";
		await _service.GetByAuthorIdAsync(authorId);
		_dataMock.Verify(x => x.GetByAuthorIdAsync(authorId), Times.Once);
	}

	[Fact]
	public async Task GetByPublishedAsync_PublishedIsTrue_NoExceptionThrown()
	{
		await _service.GetByPublishedAsync();
		_dataMock.Verify(x => x.GetByPublishedAsync(true), Times.Once);
	}

	[Fact]
	public async Task GetByPublishedAsync_PublishedIsFalse_NoExceptionThrown()
	{
		await _service.GetByPublishedAsync(false);
		_dataMock.Verify(x => x.GetByPublishedAsync(false), Times.Once);
	}

	[Fact]
	public async Task GetByArchivedAsync_ArchivedIsTrue_NoExceptionThrown()
	{
		await _service.GetByArchivedAsync();
		_dataMock.Verify(x => x.GetByArchivedAsync(true), Times.Once);
	}

	[Fact]
	public async Task GetByArchivedAsync_ArchivedIsFalse_NoExceptionThrown()
	{
		await _service.GetByArchivedAsync(false);
		_dataMock.Verify(x => x.GetByArchivedAsync(false), Times.Once);
	}

	[Fact]
	public async Task GetByTitleAsync_TitleIsNotNullOrEmpty_NoExceptionThrown()
	{
		var title = "testTitle";
		await _service.GetByTitleAsync(title);
		_dataMock.Verify(x => x.GetByTitleAsync(title), Times.Once);
	}

	[Fact]
	public async Task GetAllAsync_Should_Return_EmptyList_TestAsync()
	{
		_dataMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<BlogPost>());
		var result = await _service.GetAllAsync();
		result.Should().BeEmpty();
	}

	[Fact]
	public async Task GetByAuthorIdAsync_AuthorIdIsNull_ThrowsArgumentException()
	{
		Func<Task> act = async () => await _service.GetByAuthorIdAsync(null);
		await act.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task GetByAuthorIdAsync_AuthorIdIsEmpty_ThrowsArgumentException()
	{
		Func<Task> act = async () => await _service.GetByAuthorIdAsync("");
		await act.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task GetByArchivedAsync_Should_Return_Results_TestAsync()
	{
		await _service.GetByArchivedAsync();
		_dataMock.Verify(x => x.GetByArchivedAsync(true), Times.Once);
	}

	[Fact]
	public async Task GetByPublishedAsync_Should_Return_Results_TestAsync()
	{
		await _service.GetByPublishedAsync();
		_dataMock.Verify(x => x.GetByPublishedAsync(true), Times.Once);
	}

	[Fact]
	public async Task GetByTitleAsync_TitleIsNull_ThrowsArgumentException()
	{
		Func<Task> act = async () => await _service.GetByTitleAsync(null);
		await act.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task GetByTitleAsync_TitleIsEmpty_ThrowsArgumentException()
	{
		Func<Task> act = async () => await _service.GetByTitleAsync("");
		await act.Should().ThrowAsync<ArgumentNullException>();
	}

	[Fact]
	public async Task UpdateAsync_PostIsNotNull_NoExceptionThrown()
	{
		var blogPost = new BlogPost();
		await _service.UpdateAsync(blogPost);
		_dataMock.Verify(x => x.UpdateAsync(blogPost.Id, blogPost), Times.Once);
	}

	[Fact]
	public async Task UpdateAsync_PostIdIsNotNull_NoExceptionThrown()
	{
		var blogPost = FakeBlogPost.GetNewBlogPost(true);
		await _service.UpdateAsync(blogPost);
		_dataMock.Verify(x => x.UpdateAsync(blogPost!.Id, blogPost), Times.Once);
	}

	[Fact]
	public async Task GetAllAsync_Should_Return_Null_TestAsync()
	{
		_dataMock.Setup(x => x.GetAllAsync()).ReturnsAsync((List<BlogPost>)null);
		var result = await _service.GetAllAsync();
		Assert.Null(result);
	}

	[Fact]
	public async Task UpdateAsync_PostIsNull_ThrowsArgumentNullException()
	{
		await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdateAsync(null));
	}
}