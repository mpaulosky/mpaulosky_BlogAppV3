// ============================================
// Copyright (c) 2024. All rights reserved.
// File Name :     CounterCSharpTests.cs
// Company :       mpaulosky
// Author :        teqsl
// Solution Name : mpaulosky_BlogAppV3
// Project Name :  BlazorBlogs.Tests.BUnit
// =============================================

using System.Diagnostics.CodeAnalysis;

using BlazorBlogs.Client.Pages;

namespace BlazorBlogs.Tests.BUnit;

/// <summary>
///   These tests are written entirely in C#.
///   Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
/// </summary>
[ExcludeFromCodeCoverage]
public class CounterCSharpTests : TestContext
{
	[Fact]
	public void CounterStartsAtZero()
	{
		// Arrange
		var cut = RenderComponent<Counter>();

		// Assert that content of the paragraph shows counter at zero
		cut.Find("p").MarkupMatches("<p>Current count: 0</p>");
	}

	[Fact]
	public void ClickingButtonIncrementsCounter()
	{
		// Arrange
		var cut = RenderComponent<Counter>();

		// Act - click button to increment counter
		cut.Find("button").Click();

		// Assert that the counter was incremented
		cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
	}
}