using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : class
{
    Func<T> func;
    Queue<T> queue = new Queue<T>();
    int count;

    public ObjectPool(int generateCount, Func<T> generateFunc)
    {
        count = generateCount;
        func = generateFunc;
        
        Allocate();
    }

    void Allocate()
    {
        for (int i = 0; i < count; i++)
        {
            queue.Enqueue(func());
        }
    }

    public T Get()
    {
        if (queue.Count < 1)
        {
            return func();
        }

        return queue.Dequeue();
    }

    public void Set(T obj)
    {
        queue.Enqueue(obj);
    }
}
