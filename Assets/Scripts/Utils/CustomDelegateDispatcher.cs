using System;
using System.Collections.Generic;

public class CustomDelegateDispatcher
{
    private Dictionary<string, List<Delegate>> eventDictionary;
    private Dictionary<string, HashSet<object>> eventSubscribers;

    private static CustomDelegateDispatcher customDelegateDispatcher;

    public static CustomDelegateDispatcher Instance
    {
        get
        {
            if (customDelegateDispatcher == null)
            {
                customDelegateDispatcher = new CustomDelegateDispatcher();
                customDelegateDispatcher.Initialize();
            }

            return customDelegateDispatcher;
        }
    }

    void Initialize()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, List<Delegate>>();
        }
        if (eventSubscribers == null)
        {
            eventSubscribers = new Dictionary<string, HashSet<object>>();
        }
    }
    public void StartListening<T>(string eventName, Action<T> listener)
    {
        if (listener.Target == null) return;

        if (eventSubscribers.TryGetValue(eventName, out var subscribers))
        {
            if (!subscribers.Contains(listener.Target))
            {
                subscribers.Add(listener.Target);
                if (eventDictionary.TryGetValue(eventName, out var thisEventList))
                {
                    thisEventList.Add(listener);
                }
                else
                {
                    thisEventList = new List<Delegate> { listener };
                    eventDictionary[eventName] = thisEventList;
                }
            }
        }
        else
        {
            subscribers = new HashSet<object> { listener.Target };
            eventSubscribers[eventName] = subscribers;

            var thisEventList = new List<Delegate> { listener };
            eventDictionary[eventName] = thisEventList;
        }
    }

    public void StopListening<T>(string eventName, Action<T> listener)
    {
        if (customDelegateDispatcher == null) return;

        if (eventSubscribers.TryGetValue(eventName, out var subscribers))
        {
            if (subscribers.Contains(listener.Target))
            {
                if (eventDictionary.TryGetValue(eventName, out var thisEventList))
                {
                    thisEventList.Remove(listener);
                    if (thisEventList.Count == 0)
                    {
                        eventDictionary.Remove(eventName);
                    }
                }
                subscribers.Remove(listener.Target);
                if (subscribers.Count == 0)
                {
                    eventSubscribers.Remove(eventName);
                }
            }
        }
    }

    public void TriggerEvent<T>(string eventName, T eventArg)
    {
        if (eventDictionary.TryGetValue(eventName, out var thisEventList))
        {
            foreach (var thisEvent in thisEventList)
            {
                if (thisEvent is Action<T> action)
                {
                    action.Invoke(eventArg);
                }
            }
        }
    }
}
#region 使用案例

//public class ListenerExample : MonoBehaviour
//{
//    private void OnEnable()
//    {
//        CustomDelegateDispatcher.Instance.StartListening<string>("TestEvent", OnStringEventReceived);
//        CustomDelegateDispatcher.Instance.StartListening<int>("TestEvent", OnIntEventReceived);

//        // 尝试重复注册同一个事件
//        CustomDelegateDispatcher.Instance.StartListening<string>("TestEvent", OnStringEventReceived);
//    }

//    private void OnDisable()
//    {
//        CustomDelegateDispatcher.Instance.StopListening<string>("TestEvent", OnStringEventReceived);
//        CustomDelegateDispatcher.Instance.StopListening<int>("TestEvent", OnIntEventReceived);
//    }

//    void OnStringEventReceived(string message)
//    {
//        Debug.Log("Received string event: " + message);
//    }

//    void OnIntEventReceived(int number)
//    {
//        Debug.Log("Received int event: " + number);
//    }

//    public void SendStringEvent()
//    {
//        CustomDelegateDispatcher.Instance.TriggerEvent("TestEvent", "Hello World!");
//    }

//    public void SendIntEvent()
//    {
//        CustomDelegateDispatcher.Instance.TriggerEvent("TestEvent", 42);
//    }
//}
#endregion