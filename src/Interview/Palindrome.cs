using System;
using Xunit;

namespace Interview
{
    public class Palindrome
    {
        public bool IsPalindrome(string str)
        {
            if (str == null) return false;
            var result = IsPalindrome(str, str.Length);
            return result;
        }

        private bool IsPalindrome(string str, int n)
        {
            if (n == 0 || n == 1) return true;
            if (str[0] == str[n - 1])
            {
                return IsPalindrome(str.Substring(1, n - 2), n - 2);
            }

            return false;
        }

        [Fact]
        public void Test()
        {
            Assert.False(new Palindrome().IsPalindrome(null));
            Assert.True(new Palindrome().IsPalindrome(""));
            Assert.True(new Palindrome().IsPalindrome("a"));
            Assert.True(new Palindrome().IsPalindrome("aba"));
        }
    }
}
