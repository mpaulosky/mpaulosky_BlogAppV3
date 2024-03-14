namespace BlazorBlog.Components.Account;

internal sealed class IdentityUserAccessor(
	UserManager<ApplicationUser> userManager,
	IdentityRedirectManager redirectManager)
{
	public async Task<ApplicationUser?> GetRequiredUserAsync(HttpContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException(nameof(context));
		}

		var user = await userManager.GetUserAsync(context.User);

		if (user is null)
		{
			redirectManager.RedirectToWithStatus("Account/InvalidUser",
				$"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
		}

		return user;
	}
}