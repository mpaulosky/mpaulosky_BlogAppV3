// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     IDateTimeWrapper.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.Unit
// =============================================

namespace BlazorBlogs.Data.Interfaces;

public interface IDateTimeWrapper
{
	public DateTime Now { get { return DateTime.Now; } }
}