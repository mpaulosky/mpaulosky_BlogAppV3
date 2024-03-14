// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeUserModelTests.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

namespace BlazorBlog.Tests.Unit.Data.Fakes;

[TestSubject(typeof(FakeUserModel))]
[ExcludeFromCodeCoverage]
public class FakeUserModelTests
{
	[Theory(DisplayName = "FakeUserModel GetNewUser Test")]
	[InlineData(true)]
	[InlineData(false)]
	public void GetNewUser_With_NewSeed_Should_Return_UserModel_Test(bool expected)
	{
		// Arrange
		var basicUser = FakeUserModel.GetNewUser(expected);

		// Act
		var result = basicUser;

		// Assert
		if (!expected)
		{
			result.Id.Should().BeNullOrWhiteSpace();
			result.Should().BeEquivalentTo(basicUser);
		}
		else
		{
			result.Id.Should().NotBeNullOrWhiteSpace();
			result.Should().BeEquivalentTo(basicUser);
		}
	}

	[Theory(DisplayName = "FakeUserModel GetNewUser With New Seed Test")]
	[InlineData(true)]
	[InlineData(false)]
	public void GetBasicUser_With_NewSeed_Returns_FakeUserModel_Test(bool expected)
	{
		// Arrange

		// Act
		var result = FakeUserModel.GetNewUser(true, expected);

		// Assert
		result.Should().NotBeEquivalentTo(FakeUserModel.GetNewUser(true, expected));
	}

	[Theory(DisplayName = "FakeUserModel GetUsers Test")]
	[InlineData(1)]
	[InlineData(5)]
	public void GetBasicUsers_With_Count_Should_Return_Requested_Number_Of_BasicUsers_Test(int expectedCount)
	{
		// Arrange
		var expected = FakeUserModel.GetUsers(expectedCount);
		// Act
		var result = expected;

		// Assert
		result.Count.Should().Be(expectedCount);
		result.Should().BeEquivalentTo(expected);
	}
}