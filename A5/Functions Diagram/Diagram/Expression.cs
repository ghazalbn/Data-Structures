using System;
using MathNet.Numerics;
using System.Linq;
class Expression
{

    public int mode;
    public MyStack stack;
    public StringTokenizer st;
    public Expression(string s, int m)
    {
        stack = new MyStack(mode = m);
        this.st = new StringTokenizer(s);
        st.Postfix = Postfix();
    }
    public static bool IsVarOrNum(char c)
    => char.IsNumber(c) || c == 'x' || c == '.';
    public static int Priority(char c)
    {
        switch(c)
        {
            case '^' : return 4;
            case '!' : return 3;
            case '/' : return 2;
            case '*': return 2;                                           
            case '+'  : return 1;
            case '-' : return 1;
            default  : return 0;
        }
    }
    public static float Operate(char o, string d1, string d2)
    {
        (float b, float a) = (float.Parse(d1), float.Parse(d2));
        switch(o)
        {
            case '^' : return (float)Math.Pow(a, b);
            case '!' : return (float)SpecialFunctions.Factorial((int)b);
            case '/' : return a/b;
            case '*': return a*b;                                           
            case '+'  : return a+b;
            case '-' : return a-b;
            default  : return 0;
        }
    }
    public string Postfix()
    {
        if(mode == 1)
            Console.Write("The process of changing the stack in converting infix to postfix:\nstack contains: ");
        string p;
        string infix = st.Infix;
        string postfix = "";
        for(int i=0 ; i < infix.Length; i++)
        {
            if(IsVarOrNum(infix[i]) || (i != 0 && (infix.Substring(i-1, 2) == "^-" || infix.Substring(i-1, 2) == "(-" || infix.Substring(i-1, 2) == "*-" || infix.Substring(i-1, 2) == "/-")))   
            {
                string ss = $"({infix[i]}";
                while (++i != infix.Length && IsDigit(infix[i]))
                    ss += infix[i];
                postfix += ss+')';
                i--; 
            }
            else if(infix[i]=='(')
            {
                postfix += infix[i];
                stack.push(infix[i].ToString());
            }
            else if(infix[i]==')')
            {
                postfix += infix[i];
                while((p = stack.pop()) != "(")
                    postfix += p;
            }
            else if (Priority(infix[i]) != 0)
            {
            while(Priority(infix[i]) <= Priority(char.Parse(p = stack.top())) && stack.top() != "#")
                postfix += stack.pop();
            stack.push(infix[i].ToString());    
            }
        }
            
        while((p = stack.pop()) != "#")
            postfix += p;
        Console.WriteLine("\n******************************************************************");
        return postfix;
    }
    public float ComputeFunc(float x)
    {
        if(mode == 1)
            Console.Write($"The process of changing the stack in computing f({x}):\nstack contains: ");
        string s = st.Postfix.Replace("x", $"{x}");
        for (int j = 0; j < s.Length; j++) 
        { 
            if(char.IsNumber(s[j]) || (j != 0 && s.Substring(j-1, 2) == "(-"))
            {
                string ss = s[j].ToString();
                while (IsDigit(s[++j]))
                    ss += s[j];
                stack.push(ss);
                j--;
            }
            else if (Priority(s[j]) != 0)
                stack.push(Operate(s[j], stack.pop(), new string[3]{"#","^","!"}.Contains(stack.top())?"0":stack.pop()).ToString());
                
        } 
        var f = float.Parse(stack.pop());
        Console.WriteLine("\n**************************************************************");
        Console.WriteLine($"f({x}) = {f}\n");
        return f;
    }

    private bool IsDigit(char v)
    => char.IsNumber(v) || v == '.';
}