namespace BlazorBlog.Tests.Unit.Data.Repositories;

[TestSubject(typeof(BlogRepository))]
[ExcludeFromCodeCoverage]
public class BlogRepositoryTests
{
	private readonly Mock<IAsyncCursor<BlogPost?>> _cursor;
	private readonly Mock<IMongoCollection<BlogPost?>> _mockCollection;
	private readonly Mock<IMongoDbContextFactory> _mockContext;
	private List<BlogPost> _list = [];

	public BlogRepositoryTests()
	{
		_cursor = TestFixtures.GetMockCursor(_list);

		_mockCollection = TestFixtures.GetMockCollection(_cursor);

		_mockContext = TestFixtures.GetMockContext();
	}

	private BlogRepository CreateRepository()
	{
		return new BlogRepository(_mockContext.Object);
	}

	[Fact(DisplayName = "Archive BlogPost Test")]
	public async Task ArchiveAsync_With_A_Valid_Id_And_BlogPost_Should_ArchiveBlogPost_TestAsync()
	{
		// Arrange
		BlogPost? expected = FakeBlogPost.GetNewBlogPost(true);

		await _mockCollection.Object.InsertOneAsync(expected);

		BlogPost? updatedIssue = expected;
		updatedIssue!.IsArchived = true;

		_list = [updatedIssue];

		_cursor.Setup(_ => _.Current).Returns(_list);

		_mockContext.Setup(c => c.GetCollection<BlogPost>(It.IsAny<string>())).Returns(_mockCollection.Object);

		BlogRepository sut = CreateRepository();

		// Act
		await sut.ArchiveAsync(updatedIssue);

		// Assert
		_mockCollection.Verify(
			c => c
				.ReplaceOneAsync(
					It.IsAny<FilterDefinition<BlogPost?>>(),
					updatedIssue,
					It.IsAny<ReplaceOptions>(),
					It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact(DisplayName = "Archive BlogPost With Invalid post Throws Exception")]
	public async Task ArchiveAsync_With_Invalid_BlogPost_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.ArchiveAsync(null);

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}

	[Fact(DisplayName = "CreateAsync BlogPost with valid BlogPost")]
	public async Task CreateAsync_With_Valid_BlogPost_Should_Insert_A_New_BlogPost_TestAsync()
	{
		// Arrange
		BlogPost? newBlogPost = FakeBlogPost.GetNewBlogPost(true);

		_mockContext.Setup(c => c
			.GetCollection<BlogPost>(It.IsAny<string>())).Returns(_mockCollection.Object);

		BlogRepository sut = CreateRepository();

		// Act
		await sut.CreateAsync(newBlogPost);

		// Assert
		//Verify if InsertOneAsync is called once 
		_mockCollection.Verify(c => c
			.InsertOneAsync(
				It.IsAny<BlogPost>(),
				null,
				default), Times.Once);
	}

	[Fact(DisplayName = "CreateAsync BlogPost With Invalid post Throws Exception")]
	public async Task CreateAsync_With_Invalid_BlogPost_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.CreateAsync(null);

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}

	[Fact(DisplayName = "GetByIdAsync With a Valid Id Test")]
	public async Task GetByIdAsync_With_Valid_Id_Should_Return_One_BlogPost_TestAsync()
	{
		// Arrange
		BlogPost? expected = FakeBlogPost.GetNewBlogPost(true);

		_list = [expected];

		_cursor.Setup(c => c.Current).Returns(_list);

		_mockContext.Setup(c => c.GetCollection<BlogPost>(It.IsAny<string>())).Returns(_mockCollection.Object);

		BlogRepository sut = CreateRepository();

		//Act
		BlogPost? result = await sut.GetByIdAsync(expected.Id);

		//Assert 
		result.Should().NotBeNull();
		result.Should().BeEquivalentTo(expected);
		result.Description.Length.Should().BeGreaterThan(1);

		//Verify if InsertOneAsync is called once
		_mockCollection.Verify(c => c
			.FindAsync(
				It.IsAny<FilterDefinition<BlogPost>>(),
				It.IsAny<FindOptions<BlogPost>>(),
				It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact(DisplayName = "GetByIdAsync With Null Id Throws Exception")]
	public async Task GetByIdAsync_With_Null_itemId_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.GetByIdAsync(null);

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}

	[Fact(DisplayName = "GetByIdAsync With Invalid Id Throws Exception")]
	public async Task GetByIdAsync_With_Invalid_Id_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.GetByIdAsync("");

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}

	[Fact(DisplayName = "GetByUrlAsync With a Valid Url Test")]
	public async Task GetByUrlAsync_With_Valid_Url_Should_Return_One_BlogPost_TestAsync()
	{
		// Arrange
		BlogPost? expected = FakeBlogPost.GetNewBlogPost(true);

		_list = [expected];

		_cursor.Setup(c => c.Current).Returns(_list);

		_mockContext.Setup(c => c.GetCollection<BlogPost>(It.IsAny<string>())).Returns(_mockCollection.Object);

		BlogRepository sut = CreateRepository();

		//Act
		BlogPost result = await sut.GetByUrlAsync(expected.Url) ?? throw new InvalidOperationException();

		//Assert 
		result.Should().NotBeNull();
		result.Should().BeEquivalentTo(expected);

		//Verify if InsertOneAsync is called once
		_mockCollection.Verify(c => c
			.FindAsync(
				It.IsAny<FilterDefinition<BlogPost>>(),
				It.IsAny<FindOptions<BlogPost>>(),
				It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact(DisplayName = "GetByUrlAsync With Invalid Url Throws Exception")]
	public async Task GetByUrlAsync_With_Invalid_Url_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.GetByUrlAsync("");

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}

	[Fact(DisplayName = "GetByUrlAsync With null Url Throws Exception")]
	public async Task GetByUrlAsync_With_Null_Url_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.GetByUrlAsync(null);

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}

	[Fact(DisplayName = "GetByTitleAsync With a Valid Title Test")]
	public async Task GetByTitleAsync_With_Valid_Title_Should_Return_One_BlogPost_TestAsync()
	{
		// Arrange
		BlogPost? expected = FakeBlogPost.GetNewBlogPost(true);

		_list = [expected];

		_cursor.Setup(c => c.Current).Returns(_list);

		_mockContext.Setup(c => c.GetCollection<BlogPost>(It.IsAny<string>())).Returns(_mockCollection.Object);

		BlogRepository sut = CreateRepository();

		//Act
		BlogPost result = await sut.GetByTitleAsync(expected.Title) ?? throw new InvalidOperationException();

		//Assert 
		result.Should().NotBeNull();
		result.Should().BeEquivalentTo(expected);

		//Verify if InsertOneAsync is called once
		_mockCollection.Verify(c => c
			.FindAsync(
				It.IsAny<FilterDefinition<BlogPost>>(),
				It.IsAny<FindOptions<BlogPost>>(),
				It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact(DisplayName = "GetByTitleAsync With Invalid Title Throws Exception")]
	public async Task GetByTitleAsync_With_Invalid_Title_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.GetByTitleAsync("");

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}

	[Fact(DisplayName = "GetByTitleAsync With null Titls Throws Exception")]
	public async Task GetByUrlAsync_With_Null_Title_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.GetByTitleAsync(null);

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}
	
	[Fact(DisplayName = "GetAllAsync BlogPosts Test")]
	public async Task GetAllAsync_With_Valid_Context_Should_Return_A_List_Of_BlogPosts_TestAsync()
	{
		// Arrange
		const int expectedCount = 6;
		_list = FakeBlogPost.GetNewBlogPosts(expectedCount);

		_cursor.Setup(c => c.Current).Returns(_list);

		_mockContext.Setup(c => c.GetCollection<BlogPost>(It.IsAny<string>())).Returns(_mockCollection.Object);

		BlogRepository sut = CreateRepository();

		// Act
		List<BlogPost?> results = (await sut.GetAllAsync() ?? throw new InvalidOperationException()).ToList();

		// Assert
		results.Should().NotBeNull();
		results.Should().HaveCount(expectedCount);

		_mockCollection.Verify(c => c
			.FindAsync(
				It.IsAny<FilterDefinition<BlogPost>>(),
				It.IsAny<FindOptions<BlogPost>>(),
				It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact(DisplayName = "GetByAuthorIdAsync BlogPosts Test")]
	public async Task GetByAuthorIdAsync_With_Valid_Id_Should_Return_A_List_Of_User_BlogPosts_TestAsync()
	{
		// Arrange
		const int expectedCount = 2;

		List<BlogPost> expected = FakeBlogPost.GetNewBlogPosts(expectedCount).ToList();

		BasicUser author = FakeBasicUser.GetBasicUser();

		foreach (BlogPost? item in expected)
		{
			item.Author = author;
		}

		_list = new List<BlogPost>(expected).Where(x => x.Author.Id == author.Id).ToList();

		_cursor.Setup(c => c.Current).Returns(_list);

		_mockContext.Setup(c => c.GetCollection<BlogPost>(It.IsAny<string>())).Returns(_mockCollection.Object);

		BlogRepository sut = CreateRepository();

		// Act
		IEnumerable<BlogPost?> results =
			(await sut.GetByAuthorIdAsync(author.Id!) ?? throw new InvalidOperationException()).ToList();

		// Assert
		results.Should().NotBeNull();
		results.Should().HaveCount(expectedCount);

		_mockCollection.Verify(c => c
			.FindAsync(
				It.IsAny<FilterDefinition<BlogPost>>(),
				It.IsAny<FindOptions<BlogPost>>(),
				It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact(DisplayName = "GetByAuthorIdAsync With Null Id Throws Exception")]
	public async Task GetByAuthorIdAsync_With_Null_itemId_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.GetByAuthorIdAsync(null);

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}

	[Fact(DisplayName = "GetByAuthorIdAsync With Id of string empty Throws Exception")]
	public async Task GetByAuthorIdAsync_With_itemId_of_string_empty_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.GetByAuthorIdAsync("");

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}

	[Theory(DisplayName = "Get BlogPost that are Archived Test")]
	[InlineData(true)]
	[InlineData(false)]
	public async Task GetByArchivedAsync_With_Boolean_Should_Return_Archived_BlogPosts_TestAsync(bool expected)
	{
		// Arrange
		const int expectedCount = 3;
		_list = FakeBlogPost.GetNewBlogPosts(expectedCount).ToList();

		foreach (BlogPost? item in _list)
		{
			item.IsArchived = expected;
		}

		_cursor.Setup(c => c.Current).Returns(_list);

		_mockContext.Setup(c => c.GetCollection<BlogPost>(It.IsAny<string>())).Returns(_mockCollection.Object);

		BlogRepository sut = CreateRepository();

		// Act
		List<BlogPost?> results =
			(await sut.GetByArchivedAsync(expected) ?? throw new InvalidOperationException()).ToList();

		// Assert
		results.Should().NotBeNull();
		results.Should().HaveCount(expectedCount);

		_mockCollection.Verify(c => c
			.FindAsync(
				It.IsAny<FilterDefinition<BlogPost>>(),
				It.IsAny<FindOptions<BlogPost>>(),
				It.IsAny<CancellationToken>()), Times.Once);
	}

	[Theory(DisplayName = "Get Published BlogPosts Test")]
	[InlineData(true)]
	[InlineData(false)]
	public async Task GetByPublishedAsync_With_ValidData_Should_ReturnAListOfBlogPosts_Test(bool expected)
	{
		// Arrange
		const int expectedCount = 2;
		_list = FakeBlogPost.GetNewBlogPosts(expectedCount).ToList();

		foreach (BlogPost? item in _list)
		{
			item.IsArchived = false;
			item.IsPublished = expected;
		}

		_cursor.Setup(c => c.Current).Returns(_list);

		_mockContext.Setup(c => c.GetCollection<BlogPost>(It.IsAny<string>())).Returns(_mockCollection.Object);

		BlogRepository sut = CreateRepository();

		// Act
		IEnumerable<BlogPost?> results =
			(await sut.GetByPublishedAsync(expected) ?? throw new InvalidOperationException()).ToList();

		// Assert
		results.Should().NotBeNull();
		results.Should().HaveCount(expectedCount);

		_mockCollection.Verify(c => c
			.FindAsync(
				It.IsAny<FilterDefinition<BlogPost>>(),
				It.IsAny<FindOptions<BlogPost>>(),
				It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact(DisplayName = "UpdateAsync BlogPost with valid BlogPost Test")]
	public async Task UpdateAsync_With_A_Valid_Id_And_BlogPost_Should_UpdateBlogPost_TesAsync()
	{
		// Arrange
		BlogPost? expected = FakeBlogPost.GetNewBlogPost(true);

		BlogPost? updatedBlogPost = new()
		{
			Id = expected.Id,
			Url = expected.Url,
			Title = "Test BlogPost 1 updated",
			Description = "A new test issue 1 updated",
			Author = expected.Author,
			Content = expected.Content,
			Image = expected.Image,
			Created = expected.Created,
			IsArchived = expected.IsArchived,
			ArchivedBy = expected.ArchivedBy,
			IsPublished = expected.IsPublished
		};

		_list = [expected];

		_cursor.Setup(c => c.Current).Returns(_list);

		_mockContext.Setup(c => c.GetCollection<BlogPost>(It.IsAny<string>())).Returns(_mockCollection.Object);

		BlogRepository sut = CreateRepository();

		// Act
		await sut.UpdateAsync(updatedBlogPost.Id, updatedBlogPost);

		// Assert
		_mockCollection.Verify(
			c => c
				.ReplaceOneAsync(
					It.IsAny<FilterDefinition<BlogPost>>(),
					updatedBlogPost,
					It.IsAny<ReplaceOptions>(),
					It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact(DisplayName = "UpdateAsync With Valid Id and Null Post Throws Exception")]
	public async Task UpdateAsync_With_Valid_PostId_And_Null_BlogPost_Should_Return_ArgumentNullException_TestAsync()
	{
		// Arrange
		BlogRepository sut = CreateRepository();

		// Act
		Func<Task> act = async () => await sut.UpdateAsync("2", null);

		// Assert
		await act.Should()
			.ThrowAsync<ArgumentNullException>();
	}

	[Fact(DisplayName = "UpdateAsync With Null Id and Valid Post Throws Exception")]
	public async Task UpdateAsync_With_Null_Id_and_Valid_Post_Should_Return_ArgumentNullException_TestAsync()
	{
		{
			// Arrange
			BlogRepository sut = CreateRepository();

			// Act
			Func<Task> act = async () => await sut.UpdateAsync(null, new BlogPost());

			// Assert
			await act.Should()
				.ThrowAsync<ArgumentNullException>();
		}
	}
}