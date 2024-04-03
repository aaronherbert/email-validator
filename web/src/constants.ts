export const invalidEmail : string[] =[ 
"   ",
"hello@@example.com",
"@example",
"hello_example.com",
"1234567890123456789012345678901234567890123456789012345678901234+x@example.com",
"test@aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.com.au",

"1j.@server1.proseware.com",
"1j..s@proseware.com",
"1js*@proseware.com",
"1js@proseware..com",

"jsmith @apache.",
"jsmith@apache.c",
//"someone@yahoo.mu-seum", //TODO: this test currently fails
//email with dash
"andy -noble @data-workshop.-com",
"andy -noble @data-workshop.c-om",
"andy -noble @data-workshop.co-m",
//email with dot end
"andy.noble @data-workshop.com.",
//email with bogus chars
"andy.noble@\u008fdata-workshop.com",
"andy@o'reilly.data-workshop.com",
"foo +bar @example+3.com",
"test@%*.com",
"test@^&#.com",
//email with commas
"joeblow @apa, che.org",
"joeblow@apache.o, rg",
"joeblow@apache, org",
//email with spaces
"joeblow@ apache.org",
"joe blow @apache.org",
" joeblow@apa che.org",
//email with slashes
"joe@ap/ache.org",
"joe@apac!he.org",
//unquoted special chars
"joe.@apache.org",
".joe @apache.org",
".@apache.org",
"joe..ok @apache.org..@apache.org",
"joe(@apache.org",
"joe) @apache.org",
"joe, @apache.org",
"joe; @apache.org",
// tld test
"test@.com",
//length test
"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@domain.com",
"user@bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb.com",
//misc
"me@at&t.net",
"someone@-test.com",
//"someone@test-.com",
"someone@www.\uFFFD.ch",
"john56789.john56789.john56789.john56789.john56789.john56789.john5@example.com",
"Abc@def @example.com",
"abc @abc_def.com"]

export const validEmails : string[] = [
"test@hbf.com.au",
"test@blah.museum",
"js@proseware.com9",
"j.s@server1.proseware.com",
"js@contoso.中国",
"j@proseware.com9",
"js#internal@proseware.com",
"j_9@[129.126.118.1]",
"david.jones@proseware.com",
"d.j@server1.proseware.com",
"jones@ms1.proseware.com",
"test@1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.1234567890.com",
//"test@aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa@ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.ggggggggggggggggggggggggggggggggggggggggggggggggggggggggg.com",
"\"joe*\"@apache.org",
"szffakylcxnsqzhsesacplocmhnkslqvjwjpxqeohyxkvicqhgzpuisglcttwntq@hbf.com.au"]