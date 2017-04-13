![Logo](Art/Logo150x150.png "Logo")

# Genesis.GenericSerialDisposable

[![Build status](https://ci.appveyor.com/api/projects/status/pmqnw8fv9a1ddtc2?svg=true)](https://ci.appveyor.com/project/kentcb/genesis-genericserialdisposable)

## What?

> All Genesis.* projects are formalizations of small pieces of functionality I find myself copying from project to project. Some are small to the point of triviality, but are time-savers nonetheless. They have a particular focus on performance with respect to mobile development, but are certainly applicable outside this domain.
 
**Genesis.GenericSerialDisposable** adds a generic version of Reactive Extensions' `SerialDisposable` class. It is delivered as a netstandard 1.0 binary.

## Why?

Reactive Extensions provides a super useful `SerialDisposable` class. It allows you to store a reference to a disposable, which automatically disposes any previously assigned reference.

However, it assumes that you don't care about the type of the assigned reference, other than the fact that it must implement `IDisposable`. Sometimes we want to do something specific with the resource, so we need to cast it from `IDisposable` to the actual resource type. The `SerialDisposable<T>` class provided by **Genesis.GenericSerialDisposable** eliminates the need for such casts. 

## Where?

The easiest way to get **Genesis.GenericSerialDisposable** is via [NuGet](http://www.nuget.org/packages/Genesis.GenericSerialDisposable/):

```PowerShell
Install-Package Genesis.GenericSerialDisposable
```

## How?

**Genesis.GenericSerialDisposable** provides the `SerialDisposable<T>` class in the `System.Reactive.Disposables` namespace, so it's right alongside the non-generic `SerialDisposable` class.

Here is an example of its use:

```C#
public class SomeClass
{
    private readonly SerialDisposable<Timer> timer;

    public SomeClass()
    {
        this.timer = new SerialDisposable<Timer>();
    }
    
    public void StartTiming()
    {
        // this will dispose of any previously assigned Timer instance
        this.timer.Disposable = new Timer();

        // notice we can access Timer-specific members via the Disposable property
        this.timer.Disposable.Interval = TimeSpan.FromSeconds(3);
    }
}
``` 

## Who?

**Genesis.GenericSerialDisposable** is created and maintained by [Kent Boogaart](http://kent-boogaart.com). Issues and pull requests are welcome.