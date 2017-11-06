using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Interview
{
   public class Algrithm
    {
        public static string ReverseWordsInAString(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            s = s.Trim();
            if (s.Length <=1) return s;

            var sb = new StringBuilder();
            var word = string.Empty;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    word += s[i];
                    continue;
                }

                if (s[i] == ' ' && word != string.Empty)
                {
                    sb.Insert(0, word + (sb.Length == 0 ? "" : " ")) ;
                    word = string.Empty;
                }
            }

            if (word != string.Empty) { sb.Insert(0, word + (sb.Length == 0 ? "" : " ")); }
            return sb.ToString();
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {

            return head;
        }

        [Fact]
        public void TestDeleteDuplicates()
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(3);

            var result = DeleteDuplicates(head);
            Assert.Equal(1, result.val);
            Assert.Equal(3, result.next.val);
        }

        [Fact]
        public void TestReverseWordsInAString()
        {
            Assert.Equal("hi!", Algrithm.ReverseWordsInAString("hi!"));
            Assert.Equal("blue is sky the", Algrithm.ReverseWordsInAString("the sky is blue"));
            Assert.Equal("blue is sky the", Algrithm.ReverseWordsInAString(" the sky is blue"));
            Assert.Equal("blue is sky the", Algrithm.ReverseWordsInAString("the sky is blue  "));
            Assert.Equal("blue is sky the", Algrithm.ReverseWordsInAString("the   sky   is blue"));
        }
    }

    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
}
