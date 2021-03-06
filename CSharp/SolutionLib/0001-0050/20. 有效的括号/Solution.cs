namespace SolutionLib._20._有效的括号
{
    public class Solution
    {
        public bool IsValid(string s)
        {
            int slen = s.Length;
            if (slen == 0) return true;
            var stack = new int[slen];
            var top = -1;
            for (int i = 0; i < slen; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                    stack[++top] = i;
                else
                {
                    if (top == -1 || !Match(s[stack[top]], s[i])) return false;
                    top--;
                }
            }
            return top == -1;
        }

        private bool Match(char a, char b)
        {
            return a == '(' && b == ')' ||
                   a == '{' && b == '}' ||
                   a == '[' && b == ']';
        }
    }
}