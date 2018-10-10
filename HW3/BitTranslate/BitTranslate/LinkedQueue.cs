using Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class for making the Queue
/// </summary>
/// <typeparam name="T">Generic</typeparam>
public class LinkedQueue<T> : IQueueInterface<T>
{
    private Node<T> front;
    private Node<T> rear;

    /// <summary>
    /// Set up the Queue
    /// </summary>
	public LinkedQueue()
	{
        front = null;
        rear = null;

	}

    /// <summary>
    /// Push an element onto the Queue
    /// </summary>
    /// <param name="element"></param>
    /// <returns>element</returns>
    public T Push(T element)
    {
        if (element == null)
        {
            throw new NullReferenceException();
        }
        if (IsEmpty())
        {
            Node<T> tmp = new Node<T>(element, null);
            rear = front = tmp;
        }
        else
        {
            Node<T> tmp = new Node<T>(element, null);
            rear.next = tmp;
            rear = tmp;
        }
        return element;
    }
    /// <summary>
    /// Pop an element from the Queue
    /// </summary>
    /// <returns>tmp</returns>
    public T Pop()
    {
        T tmp = default(T);
        if (IsEmpty())
        {
            throw new QueueUnderflowException("The queue was empty when pop was invoked.");
        }

        else if (front == rear)
        {
            tmp = front.data;
            front = null;
            rear = null;
        }
        else
        {
            //General case
            tmp = front.data;
            front = front.next;
        }
            return tmp;
    }
    /// <summary>
    /// Checks to see if the queue was empty
    /// </summary>
    /// <returns>boolean</returns>
        public bool IsEmpty()
        {
            if(front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
}
