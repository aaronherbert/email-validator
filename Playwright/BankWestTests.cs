using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[Category("BankWest")]
public class BankWestTests : PageTest
{ 
    [Test, TestCaseSource(typeof(TestData), "InvalidEmails")]
    public async Task good(string email)
    {

        await Page.GotoAsync("https://www.bankwest.com.au/retail-forms/customer-care");
        await ValidateEmail(email, false);
  
    }


 
 
 

      [Test, TestCaseSource(typeof(TestData), "BadEmails")]
    public async Task bad(string email)
    {
        await Page.GotoAsync("https://www.bankwest.com.au/retail-forms/customer-care");
        await ValidateEmail(email, true);
    }

    private async Task ValidateEmail(string email, bool isValid)
    {
        await Page.GetByLabel("Email address", new() { Exact = true }).FillAsync(email);
        await Page.ScreenshotAsync(new PageScreenshotOptions() { Path = $"{email}.png" });
        await Page.GetByLabel("Submit").ClickAsync();

        if (isValid)
        {
            await Expect(Page.GetByText("Enter a valid email address", new() { Exact = false })).ToBeVisibleAsync(new   LocatorAssertionsToBeVisibleOptions{  Timeout= 3000 });
        }
        else
        {
            await Expect(Page.GetByText("Enter a valid email address", new() { Exact = false })).Not.ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions { Timeout = 3000 });
        }
    }  
}