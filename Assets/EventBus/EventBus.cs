using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<Type, List<Delegate>> subscribers = new();

    public static void Subscribe<T>(Action<T> listener)
    {
        var type = typeof(T);

        if (!subscribers.ContainsKey(type))
        {
            subscribers[type] = new List<Delegate>();
        }

        subscribers[type].Add(listener);
    }

    public static void Unsubscribe<T>(Action<T> listener)
    {
        var type = typeof(T);

        if (subscribers.TryGetValue(type, out var listeners))
        {
            listeners.Remove(listener);
        }
    }

    public static void Publish<T>(T eventData)
    {
        var type = typeof(T);

        if (!subscribers.TryGetValue(type, out var listeners))
            return;

        for (int i = 0; i < listeners.Count; i++)
        {
            ((Action<T>)listeners[i]).Invoke(eventData);
        }
    }
}