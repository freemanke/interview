using System;
using System.Collections.Generic;

namespace Main
{
    public class Caculator
    {
        const string numbs = "0123456789";
        const string operators = "+-*/";
        readonly Dictionary<char, int> priors = new Dictionary<char, int> { { '+', 0 }, { '-', 0 }, { '*', 1 }, { '/', 1 } };

        public int Caculate(string infix)
        {
            var caculateStack = new Stack<string>();
            foreach (var v in GetPostfix(infix))
            {
                if (int.TryParse(v, out int value))
                {
                    caculateStack.Push(v);
                    continue;
                }

                if (operators.Contains(v))
                {
                    var n1 = caculateStack.Pop();
                    var n2 = caculateStack.Pop();
                    switch (v)
                    {
                        case "+":
                            caculateStack.Push((int.Parse(n1) + int.Parse(n2)).ToString());
                            break;
                        case "-":
                            caculateStack.Push((int.Parse(n1) - int.Parse(n2)).ToString());
                            break;
                        case "*":
                            caculateStack.Push((int.Parse(n1) * int.Parse(n2)).ToString());
                            break;
                        case "/":
                            caculateStack.Push((int.Parse(n1) / int.Parse(n2)).ToString());
                            break;
                    }
                }
            }

            return int.Parse(caculateStack.Pop());
        }

        private bool IsNumber(char c)
        {
            return numbs.IndexOf(c) != -1;
        }

        bool IsOperator(char c)
        {
            return operators.IndexOf(c) != -1;
        }

        public List<string> GetPostfix(string infix = "100*20+30+2*10")
        {
            var stack = new Stack<char>();
            var postfixt = new List<string>();

            var operand = "";
            foreach (var c in infix)
            {
                if (IsNumber(c))
                {
                    operand += c;
                    continue;
                }

                if (IsOperator(c))
                {
                    if (operand != "")
                    {
                        postfixt.Add(operand);
                        operand = "";
                    }

                    if (stack.Count == 0 || priors[c] > priors[stack.Peek()])
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        while (stack.Count != 0 && priors[c] <= priors[stack.Peek()])
                        {
                            postfixt.Add(stack.Pop().ToString());
                        }

                        stack.Push(c);
                    }
                    continue;
                }
            }

            if (operand != "") postfixt.Add(operand);

            while (stack.Count != 0)
            {
                postfixt.Add(stack.Pop().ToString());
            }

            return postfixt;
        }
    }
}
