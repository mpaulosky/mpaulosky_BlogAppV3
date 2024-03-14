// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     UserModelTests.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

namespace BlazorBlog.Tests.Unit.Data.Models;

[TestSubject(typeof(UserModel))]
[ExcludeFromCodeCoverage]
public class UserModelTests
{
	[Fact()]
	public void UserModel_Test()
	{
		// Arrange
		var user = new UserModel()
		{
			Id = "test",
			FirstName = "First",
			LastName = "Last",
			DisplayName = "First.Last",
			EmailAddress = "First.Last@test.com"
		};

		// Act

		// Assert
	}

	// Add more tests for other properties and methods in UserModel
}