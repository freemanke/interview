using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Interview
{
   public class Atoi
    {
        /// <summary>
        ///  -2147483648～2147483647 
        /// </summary>
        public int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Trim().Length == 0) return 0;
            str = str.Trim();
            char first = str[0];
            int sign = 1, start = 0, len = str.Length;
            long sum = 0;
            if (first == '+') { start++; }
            else if (first == '-')
            {
                start++;
                sign = -1;
            }

            for (var i = start; i < len; i++)
            {
                if (!Char.IsDigit(str[i])) return sign * (int)sum;
                sum = sum * 10 + (str[i] - '0');
                if (sign == 1 && sum >= int.MaxValue) return int.MaxValue;
                if (sign == -1 && sum * -1 <= int.MinValue) return int.MinValue;
            }

            return sign * (int)sum;
        }

        [Fact]
        public void Test()
        {
            Assert.Equal(10, MyAtoi("  010"));

            Assert.Equal(0, MyAtoi(null));
            Assert.Equal(0, MyAtoi(""));
            Assert.Equal(0, MyAtoi(" "));
            Assert.Equal(0, MyAtoi("a"));
            Assert.Equal(0, MyAtoi("i"));
            Assert.Equal(0, MyAtoi("@"));
            Assert.Equal(0, MyAtoi("-"));
            Assert.Equal(1, MyAtoi("1!1"));
            Assert.Equal(1, MyAtoi("1*"));
            Assert.Equal(0, MyAtoi("+"));
            Assert.Equal(0, MyAtoi("-"));
           
            Assert.Equal(1, MyAtoi("1"));
            Assert.Equal(10, MyAtoi("10"));
            Assert.Equal(123, MyAtoi("123"));
            Assert.Equal(123, MyAtoi("+123"));
            Assert.Equal(-123, MyAtoi("-123")); 
            Assert.Equal(int.MaxValue, MyAtoi("2147483647"));
            Assert.Equal(int.MaxValue, MyAtoi("3147483647"));
            Assert.Equal(int.MinValue, MyAtoi("-3147483647"));
        }
    }
}
