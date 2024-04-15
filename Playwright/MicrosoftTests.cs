using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[Category("Microsoft")]
public class MicrosoftTests : PageTest
{ 
    [Test, TestCaseSource(typeof(TestData), "InvalidEmails")]
    public async Task Invalid(string email)
    {
        await Page.GotoAsync("https://signup.live.com/signup");
        await ValidateEmail(email, false);
}

    [Test, TestCaseSource(typeof(TestData), "ValidEmails")]
    public async Task Valid(string email)
    {
        await Page.GotoAsync("https://signup.live.com/signup");
        await ValidateEmail(email, true);
    }

    private async Task ValidateEmail(string email, bool isValid)
    {
        await Page.GetByPlaceholder("someone@example.com", new() { Exact = true }).FillAsync(email);
        await Page.GetByText("Next").ClickAsync();

        if (isValid)
        {
            await Expect(Page.GetByText("Enter the email address in the format someone@example.com.", new() { Exact = false })).Not.ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 3000 });
        }
        else
        {
            await Expect(Page.GetByText("Enter the email address in the format someone@example.com.", new() { Exact = false })).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 3000 });
        }
    }
}