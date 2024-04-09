﻿using Playground;
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
    [InlineData("abigail@example.com")]
    [InlineData("abigail@example.com ")]
    [InlineData(" abigail@example.com")]
    [InlineData("abigail @example.com ")]
    [InlineData("*@example.net")]
    [InlineData("\"\\\"\"@foo.bar")]
    [InlineData("fred&barny@example.com")]
    [InlineData("---@example.com")]
    [InlineData("foo-bar@example.net")]
    [InlineData("\"127.0.0.1\"@[127.0.0.1]")]
    [InlineData("Abigail <abigail@example.com>")]
    [InlineData("Abigail<abigail@example.com>")]
    [InlineData("Abigail<@a,@b,@c:abigail@example.com>")]
    [InlineData("\"This is a phrase\"<abigail@example.com>")]
    [InlineData("\"Abigail \"<abigail@example.com>")]
    [InlineData("\"Joe & J. Harvey\" <example @Org>")]
    [InlineData("Abigail <abigail @ example.com>")]
    [InlineData("Abigail made this <  abigail   @   example  .    com    >")]
    [InlineData("Abigail(the bitch)@example.com")]
    [InlineData("Abigail <abigail @ example . (bar) com >")]
    [InlineData("Abigail < (one)  abigail (two) @(three)example . (bar) com (quz) >")]
    [InlineData("Abigail (foo) (((baz)(nested) (comment)) ! ) < (one)  abigail (two) @(three)example . (bar) com (quz) >")]
    [InlineData("Abigail <abigail(fo\\(o)@example.com>")]
    [InlineData("Abigail <abigail(fo\\)o)@example.com> ")]
    [InlineData("(foo) abigail@example.com")]
    [InlineData("abigail@example.com (foo)")]
    [InlineData("\"Abi\\\"gail\" <abigail@example.com>")]
    [InlineData("abigail@[example.com]")]
    [InlineData("abigail@[exa\\[ple.com]")]
    [InlineData("abigail@[exa\\]ple.com]")]
    [InlineData("\":sysmail\"@  Some-Group. Some-Org")]
    


    public void UpdateMemberEmailAddressCommand_Email_Valid(string email)
    {
        EmailValidator.Validate(email).ShouldBeTrue();





    }
}
}