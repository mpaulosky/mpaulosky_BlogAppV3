// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeBasicUserTests.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

using Microsoft.AspNetCore.Http.Metadata;

namespace BlazorBlog.Tests.Unit.Data.Fakes;

[TestSubject(typeof(FakeBasicUser))]
[ExcludeFromCodeCoverage]
public class FakeBasicUserTests
{
	[Theory(DisplayName = "FakeBasicUser GetBasicUsers Test")]
	[InlineData(1)]
	[InlineData(5)]
	public void GetBasicUsers_With_Count_Should_Return_Requested_Number_Of_BasicUsers_Test(int expectedCount)
	{
		// Arrange
		var expected = FakeBasicUser.GetBasicUsers(expectedCount);
		// Act
		List<BasicUser> result = new();
		foreach (var item in expected)
		{
			result.Add(item);
		}
		// Assert
		expected.Count.Should().Be(expectedCount);
		result.Count.Should().Be(expectedCount);
		result.Should().BeEquivalentTo(expected);
		/*result[0].UserName.Should().BeEquivalentTo(expected[0].UserName);
		result[0].EmailAddress.Should().BeEquivalentTo(expected[0].EmailAddress)*/;
	}
}