namespace SolutionLib._389
{
    public class Solution
    {
        public char FindTheDifference(string s, string t)
        {
            foreach (var ch in  t)
            {
                if (!s.Contains(ch.ToString()))
                    return ch;
                int index = s.IndexOf(ch);
                s = s.Remove(index, 1);
            }

            return '\0';
        }
    }
}