using System;
using System.Collections.Generic;

public class Observable
{
    private readonly Dictionary<string, List<Action<object, object>>> _propertyObservers = new();

    public ObservableProperty<T> Ref<T>(T initialValue, string propertyName)
    {
        return new ObservableProperty<T>(initialValue, this, propertyName);
    }

    public void Watch(string propertyName, Action<object, object> callback)
    {
        if (!_propertyObservers.ContainsKey(propertyName))
        {
            _propertyObservers[propertyName] = new List<Action<object, object>>();
        }

        _propertyObservers[propertyName].Add(callback);
    }

    public void Unwatch(string propertyName, Action<object, object> callback)
    {
        if (_propertyObservers.ContainsKey(propertyName))
        {
            _propertyObservers[propertyName].Remove(callback);
        }
    }

    public void NotifyPropertyChange(string propertyName, object oldValue, object newValue)
    {
        if (_propertyObservers.TryGetValue(propertyName, out var callbacks))
        {
            foreach (var callback in callbacks)
            {
                callback?.Invoke(oldValue, newValue);
            }
        }
    }
}