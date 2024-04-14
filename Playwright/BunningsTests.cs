using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[Category("Bunnings")]
public class BunningsTests : PageTest
{
    [Test, TestCaseSource(typeof(TestData), "GoodEmails")]
    public async Task good(string email)
    {
        await Page.GotoAsync("https://signup.live.com/signup");
        await ValidateEmail(email, false);
}

    [Test, TestCaseSource(typeof(TestData), "GoodEmails")]
    public async Task bad(string email)
    {
        await Page.GotoAsync("https://www.bunnings.com.au/email-sign-up");
        await ValidateEmail(email, true);
    }

    private async Task ValidateEmail(string email, bool isValid)
    {
        await Page.GetByLabel("Email address", new() { Exact = true }).FillAsync(email);
await Page.GetByLabel("Subscribe").ClickAsync();

        if (isValid)
        {
            await Expect(Page.GetByText("Email address format is invalid.", new() { Exact = false })).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 3000 });
        }
        else
        {
            await Expect(Page.GetByText("Email address format is invalid.", new() { Exact = false })).Not.ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 3000 });
        }
    }
}