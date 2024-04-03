using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Playwright;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{  

    [SetUp]
    public async Task Init()
    { 
        await  Page.GotoAsync("https://apply-now.bankwest.com.au/easytran/contact-details"); 
    }

    [TestCase("test@test.com")]
    public async Task good()
    {

        foreach (var email in EmailTests.Vaid)
        {
            await ValidateEmail(email, false);
        }

        //await Page.GetByLabel("Email address", new() { Exact = true }).FillAsync(email);

        //await Page.GetByLabel("Continue").ClickAsync();

        //await Expect(Page.GetByText("Enter a valid email address" , new() { Exact=false  })).Not.ToBeVisibleAsync();

       // await Page.ScreenshotAsync(new PageScreenshotOptions() { Path= "screenshot.png" });
    }


    [TestCase("asd")]
    [TestCase("123")]
    public async Task bad()
    {
        foreach (var email in EmailTests.Invalid)
        {
            await ValidateEmail(email,true);
        }       
    }

    private async Task ValidateEmail(string email, bool isValid)
    {
        await Page.GetByLabel("Email address", new() { Exact = true }).FillAsync(email);

        await Page.GetByLabel("Continue").ClickAsync();

        if (isValid)
        {
            await Expect(Page.GetByText("Enter a valid email address", new() { Exact = false })).ToBeVisibleAsync();
        } else
        {
            await Expect(Page.GetByText("Enter a valid email address", new() { Exact = false })).Not.ToBeVisibleAsync();
        }
    }
}