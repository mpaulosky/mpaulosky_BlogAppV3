// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     MongoDbContextTests.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : IssueTracker
// Project Name :  IssueTracker.PlugIns.Tests.Unit
// =============================================

using BlazorBlogs.Data;

using static BlazorBlogs.Data.Helpers.CollectionNames;

using NSubstitute;

namespace BlazorBlog.Tests.Unit.Data;

[ExcludeFromCodeCoverage]
public class MongoDbContextFactoryTests
{
	private const string ConnectionString = "mongodb://test123";
	private const string DatabaseName = "TestDb";

	private static MongoDbContextFactory UnitUnderTest()
	{
		DatabaseSettings settings = new(ConnectionString, DatabaseName)
		{
			ConnectionStrings = ConnectionString, DatabaseName = DatabaseName
		};

		return Substitute.For<MongoDbContextFactory>(settings);
	}

	[Fact]
	public void MongoDbContext_With_Valid_Data_Should_Return_A_Context_Test()
	{
		// Arrange
		MongoDbContextFactory sut = UnitUnderTest();

		// Act

		// Assert
		sut.Should().NotBeNull();
		sut.Client.Should().NotBeNull();
		sut.ConnectionString.Should().Be(ConnectionString);
		sut.DbName.Should().Be(DatabaseName);
	}

	[Theory]
	[InlineData(null, "Value cannot be null. (Parameter 'name')")]
	[InlineData("", "The value cannot be an empty string. (Parameter 'name')")]
	public void GetCollection_With_Invalid_Name_Should_Fail_Test(string? value, string expectedMessage)
	{
		// Arrange
		MongoDbContextFactory sut = UnitUnderTest();

		// Act
		Action act = () => sut.GetCollection<BlogPost>(value);

		// Assert
		act.Should()
			.Throw<ArgumentException>()
			.WithParameterName("name")
			.WithMessage(expectedMessage);
	}

	[Fact]
	public void GetCollection_With_ValidName_Should_ReturnACollection_Test()
	{
		// Arrange
		MongoDbContextFactory sut = UnitUnderTest();

		// Act
		IMongoCollection<BlogPost> myCollection =
			sut.GetCollection<BlogPost>(GetCollectionName(nameof(BlogPost)));

		// Assert
		myCollection.Should().NotBeNull();
		myCollection.CollectionNamespace.CollectionName.Should().BeSameAs("posts");
	}
}