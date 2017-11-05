using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Interview
{
    public class ZigzagConversion
    {
        public string Convert(string s, int numRows)
        {
            if (s == null) return null;
            if (s.Length <= 2) return s;
            if (numRows <= 1) return s;

            var interval = numRows + (numRows - 2);
            var result = "";
            for (var i = 0; i < numRows; i++)
            {
                if (i == 0 || i == numRows - 1)
                {
                    var index = i;
                    while (index < s.Length)
                    {
                        result += s[index];
                        index += interval;
                    }
                }
                else
                {
                    var index = i;
                    var index2 = interval - i;
                    while (true)
                    {
                        if (index != i)
                        {
                            if(index2<s.Length) result += s[index2];
                            index2 += interval;
                        }

                        if(index<s.Length) result += s[index];
                        index += interval;

                        if (index >= s.Length && index2 >= s.Length) break;
                    }
                }
            }

            return result;
        }

        [Fact]
        public void Test()
        {
            Assert.Equal(null, new ZigzagConversion().Convert(null, 1));
            Assert.Equal("", new ZigzagConversion().Convert("", 1));
            Assert.Equal("a", new ZigzagConversion().Convert("a", 1));
            Assert.Equal("ab", new ZigzagConversion().Convert("ab", 1));
            Assert.Equal("ab", new ZigzagConversion().Convert("ab", 1));
            Assert.Equal("ab", new ZigzagConversion().Convert("ab",2));
            Assert.Equal("ab", new ZigzagConversion().Convert("ab", 3));
            Assert.Equal("abc", new ZigzagConversion().Convert("abc", 1));
            Assert.Equal("acb", new ZigzagConversion().Convert("abc", 2));
            Assert.Equal("abc", new ZigzagConversion().Convert("abc", 3));
            Assert.Equal("aebdfcg", new ZigzagConversion().Convert("abcdefg", 3));
            Assert.Equal("08g179f26ae35bd4c", new ZigzagConversion().Convert("0123456789abcdefg", 5));
        }
    }
}
