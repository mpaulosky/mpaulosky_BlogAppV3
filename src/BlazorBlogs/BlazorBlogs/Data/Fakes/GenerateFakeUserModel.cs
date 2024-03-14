// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     GenerateFakeUserModel.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs
// =============================================

using Bogus;

using MongoDB.Bson;

namespace BlazorBlogs.Data.Fakes;

public static class GenerateFakeUserModel
{
	/// <summary>
	///   Generates a fake user.
	/// </summary>
	/// <returns>A Faker UserModel</returns>
	public static Faker<UserModel> GenerateFake()
	{
		return new Faker<UserModel>()
			.RuleFor(x => x.Id, new BsonObjectId(ObjectId.GenerateNewId()).ToString())
			.RuleFor(x => x.ObjectIdentifier, new BsonObjectId(ObjectId.GenerateNewId()).ToString())			.RuleFor(x => x.FirstName, f => f.Name.FirstName())
			.RuleFor(x => x.LastName, f => f.Name.LastName())
			.RuleFor(x => x.DisplayName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
			.RuleFor(x => x.EmailAddress, (f, u) => f.Internet.Email(u.FirstName, u.LastName));
	}
}