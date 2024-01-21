using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Data.Models;

/// <summary>
///   BasicUser class
/// </summary>
[Serializable]
public class BasicUser
{
	/// <summary>
	///   Initializes a new instance of the <see cref="BasicUser" /> class.
	/// </summary>
	public BasicUser()
	{
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="BasicUser" /> class.
	/// </summary>
	/// <param name="user">The user.</param>
	public BasicUser(ApplicationUser user)
	{
		Id = user.Id;
		EmailAddress = user.Email;
		UserName = user.UserName;
	}

	/// <summary>
	///   Gets the identifier.
	/// </summary>
	/// <value>
	///   The identifier.
	/// </value>
	[MaxLength (450)]
	public string Id { get; private set; } = string.Empty;

	/// <summary>
	///   Gets or sets the display name.
	/// </summary>
	/// <value>
	///   The display name.
	/// </value>
	[MaxLength (256)]
	public string? UserName { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the email address.
	/// </summary>
	/// <value>
	///   The email address.
	/// </value>
	[MaxLength (256)]
	public string? EmailAddress { get; set; } = string.Empty;
}