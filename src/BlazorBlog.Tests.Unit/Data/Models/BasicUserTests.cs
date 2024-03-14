// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     BasicUserTests.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

namespace BlazorBlog.Tests.Unit.Data.Models;

[TestSubject(typeof(BasicUser))]
[ExcludeFromCodeCoverage]
public class BasicUserTests
{
	[Fact(DisplayName = "Models BasicUser Using FakeUser of type ApplicationUser Test")]
	public void BasicUser_With_FakeUser_ofType_ApplicationUser_Test()
	{
		//Arrange
		var expected = FakeApplicationUser.GetNewUser();

		//Act
		BasicUser user = new(expected);

		//Assert
		user.Should().BeOfType<BasicUser>();
		user.Id.Should().Be(expected.Id);
		user.UserName.Should().Be(expected.UserName);
		user.EmailAddress.Should().Be(expected.Email);
	}

	[Fact(DisplayName = "Models BasicUser Using FakeUser of type User Test")]
	public void BasicUser_With_FakeUser_ofType_User_Test()
	{
		//Arrange
		var expected = new UserModel()
		{
			Id = "test",
			FirstName = "",
			LastName = "",
			DisplayName = "Test",
			EmailAddress = "test@test.com"
		};

		//Act
		BasicUser user = new(expected);

		//Assert
		user.Should().BeOfType<BasicUser>();
		user.Id.Should().Be(expected.Id);
		user.UserName.Should().Be(expected.DisplayName);
		user.EmailAddress.Should().Be(expected.EmailAddress);
	}

	[Fact(DisplayName = "Models BasicUser Using FakeUser of type BasicUser Test")]
	public void BasicUser_With_New_BasicUser_Test()
	{
		//Arrange
		var expectedUser = new BasicUser() { Id = "test", UserName = "Test", EmailAddress = "Test@Test.com" };

		//Act
		var user = new BasicUser(expectedUser.Id, expectedUser.ObjectIdentifier, expectedUser.UserName, expectedUser.EmailAddress);

		//Assert
		user.Should().BeEquivalentTo(expectedUser);
	}
}