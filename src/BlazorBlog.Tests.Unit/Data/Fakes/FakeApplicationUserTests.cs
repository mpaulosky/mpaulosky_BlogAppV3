// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeApplicationUserTests.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

namespace BlazorBlog.Tests.Unit.Data.Fakes;

[TestSubject(typeof(FakeApplicationUser))]
[ExcludeFromCodeCoverage]
public class FakeApplicationUserTests
{
	[Theory(DisplayName = "FakeApplicationUser GetNewUser Tests")]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewUser_With_Boolean_Should_Return_With_Or_Without_An_Id_Test(bool expected)
	{
		// Arrange
		ApplicationUser newUser = FakeApplicationUser.GetNewUser(expected);

		// Act
		

		// Assert
		if (!expected)
		{
			newUser.Id.Should().BeNullOrWhiteSpace();
			newUser.UserName.Should().BeEquivalentTo(newUser.UserName);
		}
		else
		{
			newUser.Id.Should().NotBeNullOrWhiteSpace();
			newUser.Email.Should().BeEquivalentTo(newUser.Email);
			newUser.UserName.Should().BeEquivalentTo(newUser.UserName);
		}
	}

	[Theory(DisplayName = "FakeApplicationUser GetUsers Test")]
	[InlineData(1)]
	[InlineData(5)]
	public void GetUsers_With_Count_Should_Return_Requested_Number_Of_Users_Test(int expectedCount)
	{
		// Arrange
		var expected = FakeApplicationUser.GetUsers(expectedCount);
		
		// Act
		List<ApplicationUser> users = expected;
		
		// Assert
		expected.Count.Should().Be(expectedCount);
		expected.Should().BeEquivalentTo(users);
		}
}