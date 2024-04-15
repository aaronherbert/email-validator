using NUnit.Framework;

namespace PlaywrightTests;


public static class TestData
{
    private static IEnumerable<TestCaseData> ValidEmails()
    {
        yield return new TestCaseData("test@Bücher.ch");
        yield return new TestCaseData("test@google.com.au");
        yield return new TestCaseData("test@blah.museum");
        yield return new TestCaseData("test@hbf.com.au");
        yield return new TestCaseData("js@proseware.com9");
        yield return new TestCaseData("j.s@server1.proseware.com");
        yield return new TestCaseData("js@contoso.中国");
        yield return new TestCaseData("j@proseware.com9");
        yield return new TestCaseData("js#internal@proseware.com");
        yield return new TestCaseData("j_9@[129.126.118.1]");
        yield return new TestCaseData("david.jones@proseware.com");
        yield return new TestCaseData("d.j@server1.proseware.com");
        yield return new TestCaseData("jones@ms1.proseware.com");
        yield return new TestCaseData("test@1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.com");
        yield return new TestCaseData("\"joe*\"@apache.org");
        yield return new TestCaseData("szffakylcxnsqzhsesacplocmhnkslqvjwjpxqeohyxkvicqhgzpuisglcttwntq@hbf.com.au");
    }
    public static IEnumerable<TestCaseData> InvalidEmails()
    {
        yield return new TestCaseData("hello@@example.com");
        yield return new TestCaseData("@example");
        yield return new TestCaseData("hello_example.com");
        yield return new TestCaseData("1234567890123456789012345678901234567890123456789012345678901234+x@example.com");
        yield return new TestCaseData("test@aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.com.au");

        yield return new TestCaseData("1j.@server1.proseware.com");
        yield return new TestCaseData("1j..s@proseware.com");
        yield return new TestCaseData("1js*@proseware.com");
        yield return new TestCaseData("1js@proseware..com");

        yield return new TestCaseData("jsmith @apache.");
        yield return new TestCaseData("jsmith@apache.c");
        //yield return new TestCaseData("someone@yahoo.mu-seum"); //TODO: this test currently fails
        //email with dash
        yield return new TestCaseData("andy -noble @data-workshop.-com");
        yield return new TestCaseData("andy -noble @data-workshop.c-om");
        yield return new TestCaseData("andy -noble @data-workshop.co-m");
        //email with dot end
        yield return new TestCaseData("andy.noble @data-workshop.com.");
        //email with bogus chars
        yield return new TestCaseData("andy.noble@\u008fdata-workshop.com");
        yield return new TestCaseData("andy@o'reilly.data-workshop.com");
        yield return new TestCaseData("foo +bar @example+3.com");
        yield return new TestCaseData("test@%*.com");
        yield return new TestCaseData("test@^&#.com");
        //email with commas
        yield return new TestCaseData("joeblow @apa, che.org");
        yield return new TestCaseData("joeblow@apache.o, rg");
        yield return new TestCaseData("joeblow@apache, org");
        //email with spaces
        yield return new TestCaseData("joeblow@ apache.org");
        yield return new TestCaseData("joe blow @apache.org");
        yield return new TestCaseData(" joeblow@apa che.org");
        //email with slashes
        yield return new TestCaseData("joe@ap/ache.org");
        yield return new TestCaseData("joe@apac!he.org");
        //unquoted special chars
        yield return new TestCaseData("joe.@apache.org");
        yield return new TestCaseData(".joe @apache.org");
        yield return new TestCaseData(".@apache.org");
        yield return new TestCaseData("joe..ok @apache.org..@apache.org");
        yield return new TestCaseData("joe(@apache.org");
        yield return new TestCaseData("joe) @apache.org");
        yield return new TestCaseData("joe, @apache.org");
        yield return new TestCaseData("joe; @apache.org");
        // tld test
        yield return new TestCaseData("test@.com");
        //length test
        yield return new TestCaseData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@domain.com");
        yield return new TestCaseData("user@bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb.com");
        //misc
        yield return new TestCaseData("me@at&t.net");
        yield return new TestCaseData("someone@-test.com");
        //yield return new TestCaseData("someone@test-.com");
        yield return new TestCaseData("someone@www.\uFFFD.ch");
        yield return new TestCaseData("john56789.john56789.john56789.john56789.john56789.john56789.john5@example.com");
        yield return new TestCaseData("Abc@def @example.com");
        yield return new TestCaseData("abc @abc_def.com");

    }
}