using System;
using System.Collections.Generic;
using System.Threading;

class MyStack
{
    int mode;
    Stack<string> stack = new Stack<string>();
    public MyStack(int m) => mode = m;
    public int count()
    => stack.Count;
    public string pop()                  
    {
        if (stack.Count != 0)
        {
            string p = stack.Pop();
            if(mode == 1)
            {
                for (int i = 0; i <p.Length; i++)
                    Console.Write("\b \b");
                Thread.Sleep(1500);
            }
            return p;
        }
        else
        return "#";
    }
                        
    public string top()         
    {    
        if (stack.Count != 0)
            return stack.Peek();
        else
        return "#";
    }

    public void push(string s)   
    {
        if(mode == 1)
        {
            Console.Write(s);
            Thread.Sleep(2000);
        }
        stack.Push(s);
    }

}