using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Interview
{
    public class Palindrome
    {
        /// <summary>
        /// 严格区分大小写，从两头开始向中间靠拢
        /// </summary>
        public bool IsPalindrome1(string str)
        {
            if (str == null) return false;
            var result = IsPalindromeRecursive(str, str.Length);
            return result;
        }

        private bool IsPalindromeRecursive(string str, int n)
        {
            if (n == 0 || n == 1) return true;
            if (str[0] == str[n - 1])
            {
                return IsPalindromeRecursive(str.Substring(1, n - 2), n - 2);
            }

            return false;
        }

        /// <summary>
        /// 严格区分大消息，从中间开始往两边比较
        /// </summary>
        public bool IsPalindrome2(string str)
        {
            if (str == null) return false;
            if (str.Length == 1) return true;

            if (str.Length % 2 == 0)
            {
                var i = str.Length / 2 - 1;
                var j = str.Length / 2;
                while (i > 0)
                    if (str[i--] != str[j++])
                        return false;
            }
            else
            {
                var i = str.Length / 2;
                var j = i;
                while (i > 0)
                    if (str[--i] != str[++j])
                        return false;
            }

            return true;
        }

        /// <summary>
        /// 判读数字
        /// </summary>
        public bool IsPalindrome3(int x)
        {
            if (x == 0) return true;
            if (x < 0 || x % 10 == 0) return false;

            var revert = 0;
            while (x > revert)
            {
                revert = revert * 10 + x % 10;
                x /= 10;
            }

            return x == revert || x == revert / 10;
        }

        /// <summary>
        /// 忽略大小写，放弃非数字和和字母的字符。
        /// "A man, a plan, a canal: Panama" is a palindrome.
        /// "race a car" is not a palindrome.
        /// Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        /// https://leetcode.com/problems/valid-palindrome/description/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome4(string s)
        {
            if (s == null) return false;
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')
                    || (c >= '0' && c <= '9'))
                    sb.Append(c);
            }

            return IsPalindrome2(sb.ToString().ToLower());
        }

        public string LongestPalindromeSubstring(string s)
        {
            if (s == null) return null;
            if (s.Length == 0 || s.Length == 1) return s;
            if (s.Length == 2) return s[0] == s[1] ? s : s.Substring(0, 1);

            var max = s.Substring(0, 1);
            for (var i = 1; i < s.Length; i++)
            {
                var left = i - 1;
                var right = i + 1;

                while (left >= 0 && s[left] == s[i]) { left--; }
                while (right < s.Length && s[right] == s[i]) { right++; }
                while (left >= 0 && right < s.Length && s[left] == s[right]) { left--; right++; }

                var find = s.Substring(left + 1, right - (left + 1));
                if (find.Length > max.Length)
                {
                    max = find;
                }
            }

            return max;
        }

        [Fact]
        public void Test1()
        {
            Assert.False(new Palindrome().IsPalindrome1(null));
            Assert.True(new Palindrome().IsPalindrome1(""));
            Assert.True(new Palindrome().IsPalindrome1("a"));
            Assert.True(new Palindrome().IsPalindrome1("aba"));
            Assert.True(new Palindrome().IsPalindrome1("abba"));
        }

        [Fact]
        public void Test2()
        {
            Assert.False(new Palindrome().IsPalindrome2(null));
            Assert.True(new Palindrome().IsPalindrome2(""));
            Assert.True(new Palindrome().IsPalindrome2("a"));
            Assert.True(new Palindrome().IsPalindrome2("aba"));
            Assert.True(new Palindrome().IsPalindrome2("abba"));
        }

        [Fact]
        public void Test3()
        {
            Assert.True(new Palindrome().IsPalindrome3(0));
            Assert.False(new Palindrome().IsPalindrome3(-1));
            Assert.False(new Palindrome().IsPalindrome3(10));
            Assert.True(new Palindrome().IsPalindrome3(121));
            Assert.True(new Palindrome().IsPalindrome3(1221));
        }

        [Fact]
        public void Test4()
        {
            Assert.True(new Palindrome().IsPalindrome4("A man, a plan, a canal: Panama"));
        }

        [Fact]
        public void TestLongestPalindromeSubstring()
        {
            Assert.Equal("", new Palindrome().LongestPalindromeSubstring(""));
            Assert.Equal("a", new Palindrome().LongestPalindromeSubstring("a"));
            Assert.Equal("aa", new Palindrome().LongestPalindromeSubstring("aa"));
            Assert.Equal("aba", new Palindrome().LongestPalindromeSubstring("aba"));
            Assert.Equal("abba", new Palindrome().LongestPalindromeSubstring("abba"));
            Assert.Equal("abba", new Palindrome().LongestPalindromeSubstring("abcdabba"));
        }
    }
}
