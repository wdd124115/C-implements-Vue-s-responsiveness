using System.Collections.Generic;

public class ObservableProperty<T>
{
    private T _value;
    private readonly Observable _observable;
    private readonly string _propertyName;

    public ObservableProperty(T initialValue, Observable observable, string propertyName)
    {
        _value = initialValue;
        _observable = observable;
        _propertyName = propertyName;
    }
    public string PropertyName => _propertyName;

    public T Value
    {
        get => _value;
        set
        {
            if (!EqualityComparer<T>.Default.Equals(_value, value))
            {
                T oldValue = _value;
                _value = value;
                _observable.NotifyPropertyChange(_propertyName, oldValue, value);
            }
        }
    }
}