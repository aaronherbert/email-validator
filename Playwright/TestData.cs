using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

 
public static class TestData
{
    private static IEnumerable<TestCaseData> GoodEmails()
    {
        yield return new TestCaseData("test@hbf.com.au");
        yield return new TestCaseData("test@blah.museum");

        yield return new TestCaseData("js@proseware.com9"); // this seems important
        yield return new TestCaseData("j.s@server1.proseware.com");
        yield return new TestCaseData("js@contoso.中国");
        yield return new TestCaseData("j@proseware.com9");
        yield return new TestCaseData("js#internal@proseware.com");
        yield return new TestCaseData("j_9@[129.126.118.1;");
        yield return new TestCaseData("david.jones@proseware.com");
        yield return new TestCaseData("d.j@server1.proseware.com");
        yield return new TestCaseData("jones@ms1.proseware.com");
        yield return new TestCaseData("test@1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.com");
        //yield return new TestCaseData("test@aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.com");
        yield return new TestCaseData("\"joe*\"@apache.org");
        yield return new TestCaseData("szffakylcxnsqzhsesacplocmhnkslqvjwjpxqeohyxkvicqhgzpuisglcttwntq@hbf.com.au");
        yield return new TestCaseData("test@Bücher.ch");
        yield return new TestCaseData("emmanuel@hibernate.org");
        yield return new TestCaseData("emmanuel@hibernate");
        yield return new TestCaseData("emma-n_uel@hibernate");
        yield return new TestCaseData("emma+nuel@hibernate.org");
        yield return new TestCaseData("emma=nuel@hibernate.org");
        yield return new TestCaseData("emmanuel@[123.12.2.11;");
        yield return new TestCaseData("*@example.net");
        yield return new TestCaseData("fred&barny@example.com");
        yield return new TestCaseData("---@example.com");
        yield return new TestCaseData("foo-bar@example.net");
        yield return new TestCaseData("mailbox.sub1.sub2@this-domain");
        yield return new TestCaseData("prettyandsimple@example.com");
        yield return new TestCaseData("very.common@example.com");
        yield return new TestCaseData("disposable.style.email.with+symbol@example.com");
        yield return new TestCaseData("other.email-with-dash@example.com");
        yield return new TestCaseData("x@example.com");
        yield return new TestCaseData("\"much.more unusual\"@example.com");
        yield return new TestCaseData("\"very.unusual.@.unusual.com\"@example.com");
        yield return new TestCaseData("\"very.(),:;<>[;\\\".VERY.\\\"very@\\\\ \\\"very\\\".unusual\"@strange.example.com");
        yield return new TestCaseData("\"some \".\" strange \".\" part*:; \"@strange.example.com");
        yield return new TestCaseData("example-indeed@strange-example.com");
        yield return new TestCaseData("admin@mailserver1");
        yield return new TestCaseData("#!$%&'*+-/=?^_`{}|~@example.org");
        yield return new TestCaseData("\"()<>[;:,;@\\\"!#$%&'-/=?^_`{}| ~.a\"@example.org");
        yield return new TestCaseData("\" \"@example.org");
        yield return new TestCaseData("example@localhost");
        yield return new TestCaseData("example@s.solutions");
        yield return new TestCaseData("user@localserver");
        yield return new TestCaseData("user@tt");
        yield return new TestCaseData("user@[IPv6:2001:DB8::1;");
        yield return new TestCaseData("xn--80ahgue5b@xn--p-8sbkgc5ag7bhce.xn--ba-lmcq");
        yield return new TestCaseData("nothing@xn--fken-gra.no");

    }
    public static IEnumerable<TestCaseData> BadEmails()
    {
 
        yield return new TestCaseData("js@contoso.中国");
        yield return new TestCaseData("j@proseware.com9");
        yield return new TestCaseData("js#internal@proseware.com");
        yield return new TestCaseData("j_9@[129.126.118.1;");
        yield return new TestCaseData("david.jones@proseware.com");
        yield return new TestCaseData("d.j@server1.proseware.com");
        yield return new TestCaseData("jones@ms1.proseware.com");
        yield return new TestCaseData("test@1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.com");
        //yield return new TestCaseData("test@aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.com");
        yield return new TestCaseData("\"joe*\"@apache.org");
        yield return new TestCaseData("szffakylcxnsqzhsesacplocmhnkslqvjwjpxqeohyxkvicqhgzpuisglcttwntq@hbf.com.au");
        yield return new TestCaseData("test@Bücher.ch");
        yield return new TestCaseData("emmanuel@hibernate.org");
        yield return new TestCaseData("emmanuel@hibernate");
        yield return new TestCaseData("emma-n_uel@hibernate");
        yield return new TestCaseData("emma+nuel@hibernate.org");
        yield return new TestCaseData("emma=nuel@hibernate.org");
        yield return new TestCaseData("emmanuel@[123.12.2.11;");
        yield return new TestCaseData("*@example.net");
        yield return new TestCaseData("fred&barny@example.com");
        yield return new TestCaseData("---@example.com");
        yield return new TestCaseData("foo-bar@example.net");
        yield return new TestCaseData("mailbox.sub1.sub2@this-domain");
        yield return new TestCaseData("prettyandsimple@example.com");
        yield return new TestCaseData("very.common@example.com");
        yield return new TestCaseData("disposable.style.email.with+symbol@example.com");
        yield return new TestCaseData("other.email-with-dash@example.com");
        yield return new TestCaseData("x@example.com");
        yield return new TestCaseData("\"much.more unusual\"@example.com");
        yield return new TestCaseData("\"very.unusual.@.unusual.com\"@example.com");
        yield return new TestCaseData("\"very.(),:;<>[;\\\".VERY.\\\"very@\\\\ \\\"very\\\".unusual\"@strange.example.com");
        yield return new TestCaseData("\"some \".\" strange \".\" part*:; \"@strange.example.com");
        yield return new TestCaseData("example-indeed@strange-example.com");
        yield return new TestCaseData("admin@mailserver1");
        yield return new TestCaseData("#!$%&'*+-/=?^_`{}|~@example.org");
        yield return new TestCaseData("\"()<>[;:,;@\\\"!#$%&'-/=?^_`{}| ~.a\"@example.org");
        yield return new TestCaseData("\" \"@example.org");
        yield return new TestCaseData("example@localhost");
        yield return new TestCaseData("example@s.solutions");
        yield return new TestCaseData("user@localserver");
        yield return new TestCaseData("user@tt");
        yield return new TestCaseData("user@[IPv6:2001:DB8::1;");
        yield return new TestCaseData("xn--80ahgue5b@xn--p-8sbkgc5ag7bhce.xn--ba-lmcq");
        yield return new TestCaseData("nothing@xn--fken-gra.no");
    }
}