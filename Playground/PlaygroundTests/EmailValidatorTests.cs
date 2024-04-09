using Playground;
using Xunit;
using Shouldly;

namespace PlaygroundTests
{
    public class EmailValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("hello@@example.com")]
        [InlineData("@example")]
        [InlineData("hello_example.com")]
        [InlineData("1234567890123456789012345678901234567890123456789012345678901234+x@example.com")]
        [InlineData("test@aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.com.au")]

        [InlineData("1j.@server1.proseware.com")]
        [InlineData("1j..s@proseware.com")]
        [InlineData("1js*@proseware.com")]
        [InlineData("1js@proseware..com")]

        [InlineData("jsmith @apache.")]
        [InlineData("jsmith@apache.c")]
        //[InlineData("someone@yahoo.mu-seum")] //TODO: this test currently fails
        //email with dash
        [InlineData("andy -noble @data-workshop.-com")]
        [InlineData("andy -noble @data-workshop.c-om")]
        [InlineData("andy -noble @data-workshop.co-m")]
        //email with dot end
        [InlineData("andy.noble @data-workshop.com.")]
        //email with bogus chars
        [InlineData("andy.noble@\u008fdata-workshop.com")]
        [InlineData("andy@o'reilly.data-workshop.com")]
        [InlineData("foo +bar @example+3.com")]
        [InlineData("test@%*.com")]
        [InlineData("test@^&#.com")]
        //email with commas
        [InlineData("joeblow @apa, che.org")]
        [InlineData("joeblow@apache.o, rg")]
        [InlineData("joeblow@apache, org")]
        //email with spaces
        [InlineData("joeblow@ apache.org")]
        [InlineData("joe blow @apache.org")]
        [InlineData(" joeblow@apa che.org")]
        //email with slashes
        [InlineData("joe@ap/ache.org")]
        [InlineData("joe@apac!he.org")]
        //unquoted special chars
        [InlineData("joe.@apache.org")]
        [InlineData(".joe @apache.org")]
        [InlineData(".@apache.org")]
        [InlineData("joe..ok @apache.org..@apache.org")]
        [InlineData("joe(@apache.org")]
        [InlineData("joe) @apache.org")]
        [InlineData("joe, @apache.org")]
        [InlineData("joe; @apache.org")]
        // tld test
        [InlineData("test@.com")]
        //length test
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@domain.com")]
        [InlineData("user@bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb.com")]
        //misc
        [InlineData("me@at&t.net")]
        [InlineData("someone@-test.com")]
        //[InlineData("someone@test-.com")]
        [InlineData("someone@www.\uFFFD.ch")]
        [InlineData("john56789.john56789.john56789.john56789.john56789.john56789.john5@example.com")]
        [InlineData("Abc@def @example.com")]
        [InlineData("abc @abc_def.com")]
        [InlineData("   Just a string")]
        [InlineData("string")]
        [InlineData("(comment)")]
        [InlineData("()@example.com")]
        [InlineData("fred(&)barny@example.com")]
        [InlineData("fred\\ barny@example.com")]
        [InlineData("Abigail <abi gail @ example.com>")]
        [InlineData("Abigail <abigail(fo(o)@example.com>")]
        [InlineData("Abigail <abigail(fo)o)@example.com>")]
        [InlineData("\"Abi\"gail\" <abigail@example.com>")]
        [InlineData("abigail@[exa]ple.com]")]
        [InlineData("abigail@[exa[ple.com]")]
        [InlineData("abigail@[exaple].com]")]
        [InlineData("abigail@")]
        [InlineData("@example.com")]
        [InlineData("phrase: abigail@example.com abigail@example.com ;")]
        [InlineData("invalid�char@example.com")]


        [InlineData("emmanuel.hibernate.org")]
        [InlineData("emma nuel@hibernate.org")]
        [InlineData("emma(nuel@hibernate.org")]
        [InlineData("emmanuel@")]
        [InlineData("emma\nnuel@hibernate.org")]
        [InlineData("emma@nuel@hibernate.org")]
        [InlineData("emma@nuel@.hibernate.org")]
        [InlineData("Just a string")]
 
        [InlineData("me@")]
 
        [InlineData("me.@example.com")]
        [InlineData(".me@example.com")]
        [InlineData("me@example..com")]
        [InlineData("me\\@example.com")]
        [InlineData("Abc.example.com")] // (no @ character)
        [InlineData("A@b@c@example.com")] // (only one @ is allowed outside quotation marks)
        [InlineData("a\"b(c)d,e:f;g<h>i[j\\k]l@example.com")] // (none of the special characters in this local-part are allowed outside quotation marks)
        [InlineData("just\"not\"right@example.com")] // (quoted strings must be dot separated or the only element making up the local-part)
        [InlineData("this is\"not\\allowed@example.com")] // (spaces, quotes, and backslashes may only exist when within quoted strings and preceded by a backslash)
        [InlineData("this\\ still\\\"not\\\\allowed@example.com")] // (even if escaped (preceded by a backslash), spaces, quotes, and backslashes must still be contained by quotes)
        [InlineData("john..doe@example.com")] // (double dot before @) with caveat: Gmail lets this through, Email address#Local-part the dots altogether
        [InlineData("john.doe@example..com")]
        public void IsPrime_InputIs1_ReturnFalse(string email)
    {
        EmailValidator.Validate(email).ShouldBeFalse();
    }

    [Theory]
    [InlineData("test@hbf.com.au")]
    [InlineData("test@blah.museum")]

    [InlineData("js@proseware.com9")] // this seems important
    [InlineData("j.s@server1.proseware.com")]
    [InlineData("js@contoso.中国")]
    [InlineData("j@proseware.com9")]
    [InlineData("js#internal@proseware.com")]
    [InlineData("j_9@[129.126.118.1]")]
    [InlineData("david.jones@proseware.com")]
    [InlineData("d.j@server1.proseware.com")]
    [InlineData("jones@ms1.proseware.com")]
    [InlineData("test@1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.com")]
    //[InlineData("test@aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.com")]
    [InlineData("\"joe*\"@apache.org")]
    [InlineData("szffakylcxnsqzhsesacplocmhnkslqvjwjpxqeohyxkvicqhgzpuisglcttwntq@hbf.com.au")]
    [InlineData("test@Bücher.ch")]
        [InlineData( "emmanuel@hibernate.org")]
        [InlineData( "emmanuel@hibernate")]
        [InlineData( "emma-n_uel@hibernate")]
        [InlineData( "emma+nuel@hibernate.org")]
        [InlineData( "emma=nuel@hibernate.org")]
        [InlineData( "emmanuel@[123.12.2.11]")]
        [InlineData( "*@example.net")]
        [InlineData( "fred&barny@example.com")]
        [InlineData( "---@example.com")]
        [InlineData( "foo-bar@example.net")]
        [InlineData( "mailbox.sub1.sub2@this-domain")]
        [InlineData( "prettyandsimple@example.com")]
        [InlineData( "very.common@example.com")]
        [InlineData( "disposable.style.email.with+symbol@example.com")]
        [InlineData( "other.email-with-dash@example.com")]
        [InlineData( "x@example.com")]
        [InlineData( "\"much.more unusual\"@example.com")]
        [InlineData( "\"very.unusual.@.unusual.com\"@example.com")]
        [InlineData( "\"very.(),:;<>[]\\\".VERY.\\\"very@\\\\ \\\"very\\\".unusual\"@strange.example.com")]
        [InlineData( "\"some \".\" strange \".\" part*:; \"@strange.example.com")]
        [InlineData( "example-indeed@strange-example.com")]
        [InlineData( "admin@mailserver1")]
        [InlineData( "#!$%&'*+-/=?^_`{}|~@example.org")]
        [InlineData( "\"()<>[]:,;@\\\"!#$%&'-/=?^_`{}| ~.a\"@example.org")]
        [InlineData( "\" \"@example.org")]
        [InlineData( "example@localhost")]
        [InlineData( "example@s.solutions")]
        [InlineData( "user@localserver")]
        [InlineData( "user@tt")]
        [InlineData( "user@[IPv6:2001:DB8::1]")]
        [InlineData( "xn--80ahgue5b@xn--p-8sbkgc5ag7bhce.xn--ba-lmcq")]
        [InlineData( "nothing@xn--fken-gra.no")]

        public void UpdateMemberEmailAddressCommand_Email_Valid(string email)
    {
        EmailValidator.Validate(email).ShouldBeTrue();
    }
}
}
