// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     FakeUserModel.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

namespace BlazorBlogs.Data.Fakes;

/// <summary>
///   FakeUserModel
/// </summary>
public class FakeUserModel
{
	/// <summary>
	///   Gets a new UserModel.
	/// </summary>
	/// <param name="keepId">bool whether to keep the generated Id</param>
	/// <returns>ApplicationUser</returns>
	public static UserModel GetNewUser(bool keepId = false, bool useNewSeed = false)
	{
		UserModel? user = GenerateFakeUserModel.GenerateFake().Generate();

		if (!keepId)
		{
			user.Id = string.Empty;
		}

		return user;
	}

	/// <summary>
	///   Gets a list of ApplicationUsers.
	/// </summary>
	/// <param name="numberOfUsers">The number of users.</param>
/// <returns>A List of ApplicationUsers</returns>
	public static List<UserModel> GetUsers(int numberOfUsers, bool useNewSeed = false)
	{
		List<UserModel>? users = GenerateFakeUserModel.GenerateFake().Generate(numberOfUsers);

		return users;
	}
}