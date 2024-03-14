// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeApplicationUser.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

namespace BlazorBlogs.Data.Fakes;

public class FakeApplicationUser
{
	/// <summary>
	///   Gets a new ApplicationUser.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <returns>ApplicationUser</returns>
	public static ApplicationUser GetNewUser(bool keepId = false)
	{
		UserModel? user = GenerateFakeUserModel.GenerateFake().Generate();

		var appUser = new ApplicationUser { Id = user.Id, UserName = user.DisplayName, Email = user.EmailAddress };

		if (!keepId)
		{
			appUser.Id = string.Empty;
		}

		return appUser;
	}

	/// <summary>
	///   Gets a list of ApplicationUsers.
	/// </summary>
	/// <param name="numberOfUsers">The number of users.</param>
	/// <returns>A List of ApplicationUsers</returns>
	public static List<ApplicationUser> GetUsers(int numberOfUsers)
	{
		List<UserModel>? users = GenerateFakeUserModel.GenerateFake().Generate(numberOfUsers);
		List<ApplicationUser> appUsers = [];
		appUsers.AddRange(users.Select(user =>
			new ApplicationUser { Id = user.Id, UserName = user.DisplayName, Email = user.EmailAddress }));

		return appUsers;
	}
}