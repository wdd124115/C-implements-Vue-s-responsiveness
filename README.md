-中文-
第一：在你需要用到的地方通过new方法来实例化一个观察者类
      public Observable _observable = new Observable();
第二：把要观察的对象注册为被观察对象
      public ObservableProperty<string> Time { get; set; }
第三：通过构建函数的方式来初始化观察者并添加到观察队列中
      public PlayerCompany()
      {
         Time = _observable.Ref("Initial Time", nameof(Time));
      }
完成上面三步之后就能使用watch来实时监听了。下面就是实现如何实时观察被观察者的属性变化的方式。
      PlayerCompany.Instance._observable.Watch(nameof(PlayerCompany.Time), _timeChangeCallback = (oldValue, newValue) =>{});
这样就能实现观察被观察者的新的属性值和旧的属性值的变化了
当然如果你通过某一个条件使得整个被观察者不再被观察也是可以的啦。下面就是一个例子。
      if (changesInTimer.IsDeadline(newValue.ToString(), changesInTimer.ComputeDeadline(startTime)))
      {
          PlayerCompany.Instance._observable.Unwatch(nameof(PlayerCompany.Time), _timeChangeCallback);
          isCreateEmplyer = false;
          ExecuteOnMainThread(() => AddEmployee());

      }
这样子就能让被观察不再被整个观察了。当然，如果你还想要在观察这个被观察者的话至需要重新运行一下 
PlayerCompany.Instance._observable.Watch(nameof(PlayerCompany.Time), _timeChangeCallback = (oldValue, newValue) =>{});
这段代码就能继续愉快的观察了。
-English-
Here is the translation of the provided Chinese text into English:

First: Instantiate an observer class where needed using the `new` keyword.
public Observable _observable = new Observable();

Second: Register the object to be observed as the observed object.
public ObservableProperty<string> Time { get; set; }

Third: Initialize the observer through the constructor and add it to the observation queue.

public PlayerCompany()
{
    Time = _observable.Ref("Initial Time", nameof(Time));
}

After completing the above three steps, you can use `watch` to monitor in real time. The following is an implementation of how to observe changes in the observed object's property in real time.

PlayerCompany.Instance._observable.Watch(nameof(PlayerCompany.Time), _timeChangeCallback = (oldValue, newValue) => {
    // Your callback code here
});

This allows you to observe the new and old values of the observed object's property changes.

Of course, if you want to stop observing the observed object based on a certain condition, you can do so. Here is an example.

if (changesInTimer.IsDeadline(newValue.ToString(), changesInTimer.ComputeDeadline(startTime))) {
    PlayerCompany.Instance._observable.Unwatch(nameof(PlayerCompany.Time), _timeChangeCallback);
    isCreateEmplyer = false;
    ExecuteOnMainThread(() => AddEmployee());
}

This stops the observed object from being observed any further. If you want to start observing the observed object again, simply run the following code snippet again.

PlayerCompany.Instance._observable.Watch(nameof(PlayerCompany.Time), _timeChangeCallback = (oldValue, newValue) => {
    // Your callback code here
});

This allows you to continue observing happily.

Please note that `ExecuteOnMainThread`, `AddEmployee`, and `changesInTimer` are placeholders for your actual implementation details, and you should replace them with the actual method calls and logic in your code.
