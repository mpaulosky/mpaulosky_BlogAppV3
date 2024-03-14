// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeBasicUser.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

namespace BlazorBlogs.Data.Fakes;

/// <summary>
///   FakeBasicUser class
/// </summary>
public static class FakeBasicUser
{
	/// <summary>
	///   Gets a BasicUser.
	/// </summary>
	/// <returns>A BasicUser</returns>
	public static BasicUser GetBasicUser()
	{
		UserModel? user = GenerateFakeUserModel.GenerateFake().Generate();

		var basicUser = new BasicUser(user);

		return basicUser;
	}

	/// <summary>
	///   Gets a list of BasicUsers.
	/// </summary>
	/// <param name="numberOfUsers">The number of users.</param>
	/// <returns>A List of BasicUsers</returns>
	public static List<BasicUser> GetBasicUsers(int numberOfUsers)
	{
		List<UserModel>? users = GenerateFakeUserModel.GenerateFake().Generate(numberOfUsers);
		List<BasicUser> appUsers = [];
		appUsers.AddRange(users.Select(user => new BasicUser(user)));
		return appUsers;
	}
}