using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[Category("Rac")]
public class RacTests : PageTest
{
    [Test, TestCaseSource(typeof(TestData), "InvalidEmails")]
    public async Task Invalid(string email)
    {
        await Page.GotoAsync("https://rac.com.au/about-rac/contact-us/enquiry");
        await ValidateEmail(email, false);
    }

    [Test, TestCaseSource(typeof(TestData), "ValidEmails")]
    public async Task Valid(string email)
    {
        await Page.GotoAsync("https://rac.com.au/about-rac/contact-us/enquiry");
        await ValidateEmail(email, true);
    }

    private async Task ValidateEmail(string email, bool isValid)
    {
        await Page.GetByLabel("Email", new() { Exact = true }).FillAsync(email);
        await Page.GetByText("Submit").ClickAsync();

        if (isValid)
        {
            await Expect(Page.GetByText("Please enter a valid email address.", new() { Exact = false })).Not.ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 3000 });
        }
        else
        {
            await Expect(Page.GetByText("Please enter a valid email address.", new() { Exact = false })).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 3000 });
        }
    }
}