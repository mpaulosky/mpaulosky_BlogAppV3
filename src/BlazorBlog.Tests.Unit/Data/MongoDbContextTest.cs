// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     MongoDbContextTest.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

using BlazorBlogs.Data;

using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Tests.Unit.Data;

[TestSubject(typeof(MongoDbContext))]
[ExcludeFromCodeCoverage]
public class MongoDbContextTest
{
	[Fact]
	public void TestDefaultConstructor()
	{
		var context = new MongoDbContext();
		Assert.NotNull(context);
	}
}