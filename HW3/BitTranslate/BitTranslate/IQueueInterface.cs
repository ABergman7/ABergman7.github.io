﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/// <summary>
/// A FIFO queue interface. This ADT is suitable for a singly
/// linked queue.
/// </summary>
/// <typeparam name="T">Generic</typeparam>
public interface IQueueInterface<T>
{
    /// <summary>
    /// Add an element to the rear of the queue.
    /// </summary>
    /// <param name="element">Generic Element</param>
    /// <returns>The element that was enqueued</returns>
    T Push(T element);


    /// <summary>
    /// Remove and return the front element.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="QueueUnderflowException">T.length == null</exception>
    T Pop();

    Boolean IsEmpty();

}
