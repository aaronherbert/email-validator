using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright
{
    internal static class EmailTests
    {
        public static string[] Invalid => new[] { "asd", "123" };
        public static string[] Vaid => new[] { "test@test.com" };
    }
}
