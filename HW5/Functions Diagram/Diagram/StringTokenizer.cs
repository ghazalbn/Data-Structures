using System.Text.RegularExpressions;

class StringTokenizer
{
    public string Infix;
    public string Postfix;

    public StringTokenizer(string s)
    => fix(s);
    public void fix(string st)
    {
        st = st.ToLower().Replace(" ", "");
        var reg = new Regex(@"[0-9x)][x]");
        MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceS);
        Infix = reg.Replace(st, myEvaluator);
    }
    private string ReplaceS(Match match)
    {
        var groups = match.Groups[0];
        var v = groups.Value;
        return $"{v[0]}*{v[1]}";
    }
}