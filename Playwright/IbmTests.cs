using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[Category("Ibm")]
public class IbmTests : PageTest
{
    [Test, TestCaseSource(typeof(TestData), "InvalidEmails")]
    public async Task Invalid(string email)
    {
        await Page.GotoAsync("https://www.ibm.com/account/reg/us-en/signup?formid=MAIL-watsonmedia", new PageGotoOptions() { });
        await ValidateEmail(email, false);
    }

    [Test, TestCaseSource(typeof(TestData), "ValidEmails")]
    public async Task Valid(string email)
    {
        await Page.GotoAsync("https://www.ibm.com/account/reg/us-en/signup?formid=MAIL-watsonmedia");
        await ValidateEmail(email, true);
    }

    private async Task ValidateEmail(string email, bool isValid)
    {
        await Page.Locator("#email").FillAsync(email);
        await Page.GetByText("Submit").ClickAsync();



        if (isValid)
        {
            await Expect(Page.GetByText("Suggested format (name@company.com)", new() { Exact = false })).Not.ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 3000 });
        }
        else
        {
            await Expect(Page.GetByText("Suggested format (name@company.com)", new() { Exact = false })).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 3000 });
        }
    }
}