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
    public async Task Setup()
    {


        await Context.Tracing.StartAsync(new()
        {
            Title = TestContext.CurrentContext.Test.ClassName + "." + TestContext.CurrentContext.Test.Name,
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        var fileName = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip";
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(c, '-');
        }

        // This will produce e.g.:
        // bin/Debug/net8.0/playwright-traces/PlaywrightTests.Tests.Test1.zip
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                fileName
            )
        });
    }

    [TestCase("test@test.com")]
    public async Task good(string email)
    {

        await Page.GotoAsync("https://www.bankwest.com.au/retail-forms/customer-care");
        await ValidateEmail(email, false);
        

        //await Page.GetByLabel("Email address", new() { Exact = true }).FillAsync(email);

        //await Page.GetByLabel("Continue").ClickAsync();

        //await Expect(Page.GetByText("Enter a valid email address" , new() { Exact=false  })).Not.ToBeVisibleAsync();

       // await Page.ScreenshotAsync(new PageScreenshotOptions() { Path= "screenshot.png" });
    }


    [TestCase("asd")]
    [TestCase("123")]
    [TestCase("test@test.com")]
    public async Task bad(string email)
    {
        await Page.GotoAsync("https://www.bankwest.com.au/retail-forms/customer-care");
        await ValidateEmail(email,true);
    }

    private async Task ValidateEmail(string email, bool isValid)
    {
        await Page.GetByLabel("Email address", new() { Exact = true }).FillAsync(email);
        await Page.ScreenshotAsync(new PageScreenshotOptions() { Path= $"{email}.png" });
        await Page.GetByLabel("Submit").ClickAsync();

        if (isValid)
        {
            await Expect(Page.GetByText("Enter a valid email address", new() { Exact = false })).ToBeVisibleAsync();
        } else
        {
            await Expect(Page.GetByText("Enter a valid email address", new() { Exact = false })).Not.ToBeVisibleAsync();
        }
    }
}