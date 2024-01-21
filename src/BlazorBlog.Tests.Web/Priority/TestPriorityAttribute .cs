﻿// ============================================
// Copyright (c) 2023. All rights reserved.
// File Name :     TestPriorityAttribute .cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : BlogServiceApp
// Project Name :  BlogService.UI.Tests.Playwright
// =============================================

namespace BlazorBlogs.Priority;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class TestPriorityAttribute : Attribute
{
	public int Priority { get; private set; }

	public TestPriorityAttribute(int priority) => Priority = priority;
}
