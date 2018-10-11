using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class TestClass
{
    /// <summary>
    /// Print the binary representation of all numbers from 1 up to n.
    /// This is accomplished by using a FIFO queue to perform a level
    /// order(i.e.BFS) traversal of a virtual binary tree that
    /// looks like this:
    ///                 1
    ///             /       \
    ///            10       11
    ///           /  \     /  \
    ///         100  101  110  111  etc.
    ///and then storing each "value" in a list as it is "visited".
    /// </summary>
    /// <param name="n">int</param>
    /// <returns>output</returns>
static LinkedList<string>  GenerateBinaryRepresentationList(int n)
    {
       LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

        LinkedList<string> output = new LinkedList<string>();


        if(n < 1)
        {
            return output;
        }

        q.Push(new StringBuilder("1"));

        while(n-- > 0)
        {
            StringBuilder sb = q.Pop();
            output.AddLast(sb.ToString());

            StringBuilder sbc = new StringBuilder(sb.ToString());


            sb.Append('0');
            q.Push(sb);

            sbc.Append('1');
            q.Push(sbc);

        }
        return output;

    }
    /// <summary>
    /// Main Method
    /// </summary>
    /// <param name="args"></param>
    static void Main(String[] args)
    {
        int n = 10;
        if(args.Length < 1)
        {
            Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
            Console.WriteLine("\t./ BitTranslate.exe 12");
            return;
        }
        try
        {
            n = int.Parse(args[0]);
        }
        catch (FormatException)
        {
            Console.WriteLine("I'm sorry, I can't understand the number: " + args[0]);
            return;


        }
        LinkedList<string> output = GenerateBinaryRepresentationList(n);

        int maxLength = output.Count();

        foreach(string s in output)
        {
            for(int i = 0; i < maxLength - s.Length; ++i)
            {
                Console.Write(" ");
            }
            Console.WriteLine(s);
        }

    }

}
