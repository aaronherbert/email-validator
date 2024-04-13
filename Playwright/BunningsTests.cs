using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class BunningsTests : PageTest
{

    [SetUp]
    public async Task Setup()
    {


        //await Context.Tracing.StartAsync(new()
        //{
        //    Title = TestContext.CurrentContext.Test.ClassName + "." + TestContext.CurrentContext.Test.Name,
        //    Screenshots = true,
        //    Snapshots = true,
        //    Sources = true
        //});
    }

    [TearDown]
    public async Task TearDown()
    {
        //var fileName = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip";
        //foreach (var c in Path.GetInvalidFileNameChars())
        //{
        //    fileName = fileName.Replace(c, '-');
        //}

        //// This will produce e.g.:
        //// bin/Debug/net8.0/playwright-traces/PlaywrightTests.Tests.Test1.zip
        //await Context.Tracing.StopAsync(new()
        //{
        //    Path = Path.Combine(
        //        TestContext.CurrentContext.WorkDirectory,
        //        "playwright-traces",
        //        fileName
        //    )
        //});
    }

    //[Theory]

    //[TestCase("test@hbf.com.au")]
    //[TestCase("test@blah.museum")]

    //[TestCase("js@proseware.com9")] // this seems important
    //[TestCase("j.s@server1.proseware.com")]
    //[TestCase("js@contoso.中国")]
    //[TestCase("j@proseware.com9")]
    //[TestCase("js#internal@proseware.com")]
    //[TestCase("j_9@[129.126.118.1]")]
    //[TestCase("david.jones@proseware.com")]
    //[TestCase("d.j@server1.proseware.com")]
    //[TestCase("jones@ms1.proseware.com")]
    //[TestCase("test@1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.com")]
    ////[TestCase("test@aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.com")]
    //[TestCase("\"joe*\"@apache.org")]
    //[TestCase("szffakylcxnsqzhsesacplocmhnkslqvjwjpxqeohyxkvicqhgzpuisglcttwntq@hbf.com.au")]
    //[TestCase("test@Bücher.ch")]
    //[TestCase("emmanuel@hibernate.org")]
    //[TestCase("emmanuel@hibernate")]
    //[TestCase("emma-n_uel@hibernate")]
    //[TestCase("emma+nuel@hibernate.org")]
    //[TestCase("emma=nuel@hibernate.org")]
    //[TestCase("emmanuel@[123.12.2.11]")]
    //[TestCase("*@example.net")]
    //[TestCase("fred&barny@example.com")]
    //[TestCase("---@example.com")]
    //[TestCase("foo-bar@example.net")]
    //[TestCase("mailbox.sub1.sub2@this-domain")]
    //[TestCase("prettyandsimple@example.com")]
    //[TestCase("very.common@example.com")]
    //[TestCase("disposable.style.email.with+symbol@example.com")]
    //[TestCase("other.email-with-dash@example.com")]
    //[TestCase("x@example.com")]
    //[TestCase("\"much.more unusual\"@example.com")]
    //[TestCase("\"very.unusual.@.unusual.com\"@example.com")]
    //[TestCase("\"very.(),:;<>[]\\\".VERY.\\\"very@\\\\ \\\"very\\\".unusual\"@strange.example.com")]
    //[TestCase("\"some \".\" strange \".\" part*:; \"@strange.example.com")]
    //[TestCase("example-indeed@strange-example.com")]
    //[TestCase("admin@mailserver1")]
    //[TestCase("#!$%&'*+-/=?^_`{}|~@example.org")]
    //[TestCase("\"()<>[]:,;@\\\"!#$%&'-/=?^_`{}| ~.a\"@example.org")]
    //[TestCase("\" \"@example.org")]
    //[TestCase("example@localhost")]
    //[TestCase("example@s.solutions")]
    //[TestCase("user@localserver")]
    //[TestCase("user@tt")]
    //[TestCase("user@[IPv6:2001:DB8::1]")]
    //[TestCase("xn--80ahgue5b@xn--p-8sbkgc5ag7bhce.xn--ba-lmcq")]
    //[TestCase("nothing@xn--fken-gra.no")]

    [Test, TestCaseSource(typeof(TestData), "GoodEmails")]
    public async Task good(string email)
    {

        await Page.GotoAsync("https://signup.live.com/signup");
        await ValidateEmail(email, false);


        //await Page.GetByLabel("Email address", new() { Exact = true }).FillAsync(email);

        //await Page.GetByLabel("Continue").ClickAsync();

        //await Expect(Page.GetByText("Enter a valid email address" , new() { Exact=false  })).Not.ToBeVisibleAsync();

        // await Page.ScreenshotAsync(new PageScreenshotOptions() { Path= "screenshot.png" });
    }



    //[TestCase("test@hbf.com.au")]
    //[TestCase("test@blah.museum")]

    //[TestCase("js@proseware.com9")] // this seems important
    //[TestCase("j.s@server1.proseware.com")]
    //[TestCase("js@contoso.中国")]
    //[TestCase("j@proseware.com9")]
    //[TestCase("js#internal@proseware.com")]
    //[TestCase("j_9@[129.126.118.1]")]
    //[TestCase("david.jones@proseware.com")]
    //[TestCase("d.j@server1.proseware.com")]
    //[TestCase("jones@ms1.proseware.com")]
    //[TestCase("test@1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.com")]
    ////[TestCase("test@aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.com")]
    //[TestCase("\"joe*\"@apache.org")]
    //[TestCase("szffakylcxnsqzhsesacplocmhnkslqvjwjpxqeohyxkvicqhgzpuisglcttwntq@hbf.com.au")]
    //[TestCase("test@Bücher.ch")]
    //[TestCase("emmanuel@hibernate.org")]
    //[TestCase("emmanuel@hibernate")]
    //[TestCase("emma-n_uel@hibernate")]
    //[TestCase("emma+nuel@hibernate.org")]
    //[TestCase("emma=nuel@hibernate.org")]
    //[TestCase("emmanuel@[123.12.2.11]")]
    //[TestCase("*@example.net")]
    //[TestCase("fred&barny@example.com")]
    //[TestCase("---@example.com")]
    //[TestCase("foo-bar@example.net")]
    //[TestCase("mailbox.sub1.sub2@this-domain")]
    //[TestCase("prettyandsimple@example.com")]
    //[TestCase("very.common@example.com")]
    //[TestCase("disposable.style.email.with+symbol@example.com")]
    //[TestCase("other.email-with-dash@example.com")]
    //[TestCase("x@example.com")]
    //[TestCase("\"much.more unusual\"@example.com")]
    //[TestCase("\"very.unusual.@.unusual.com\"@example.com")]
    //[TestCase("\"very.(),:;<>[]\\\".VERY.\\\"very@\\\\ \\\"very\\\".unusual\"@strange.example.com")]
    //[TestCase("\"some \".\" strange \".\" part*:; \"@strange.example.com")]
    //[TestCase("example-indeed@strange-example.com")]
    //[TestCase("admin@mailserver1")]
    //[TestCase("#!$%&'*+-/=?^_`{}|~@example.org")]
    //[TestCase("\"()<>[]:,;@\\\"!#$%&'-/=?^_`{}| ~.a\"@example.org")]
    //[TestCase("\" \"@example.org")]
    //[TestCase("example@localhost")]
    //[TestCase("example@s.solutions")]
    //[TestCase("user@localserver")]
    //[TestCase("user@tt")]
    //[TestCase("user@[IPv6:2001:DB8::1]")]
    //[TestCase("xn--80ahgue5b@xn--p-8sbkgc5ag7bhce.xn--ba-lmcq")]
    //[TestCase("nothing@xn--fken-gra.no")]

    [Test, TestCaseSource(typeof(TestData), "GoodEmails")]
    public async Task bad(string email)
    {
        await Page.GotoAsync("https://www.bunnings.com.au/email-sign-up");
        await ValidateEmail(email, true);
    }

    private async Task ValidateEmail(string email, bool isValid)
    {
        await Page.GetByLabel("Email address", new() { Exact = true }).FillAsync(email);
        //await Page.ScreenshotAsync(new PageScreenshotOptions() { Path = $"{email}.png" });
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