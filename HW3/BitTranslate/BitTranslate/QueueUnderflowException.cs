using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// The class that handles underflow for the queue
/// </summary>
public class QueueUnderflowException : Exception
{
    public  QueueUnderflowException(string message) : base(message) { }

}
