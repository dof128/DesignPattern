using System;
using System.Collections.Generic;

using WFang.DesignPattern.Observer;

namespace Sample
{
    public class Subject : ISubject
    {
        public string msg { get; set; } = string.Empty;

        private List<IObserver> observers { get; set; } = new List<IObserver>();

        public void Register(IObserver observer)
        {
            if(observer == null)
                return;

            observers.Add(observer);
        }
        public void UnRegister(IObserver observer)
        {
            if(observer == null)
                return;

            if(observers.Contains(observer))
                observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var observer in observers)
                observer?.Update(this);
        }
    }

    public class FirstObserver : IObserver
    {
        public void Update<T>(T subject) where T : ISubject
        {
            Subject s = subject as Subject;
            if(s == null)
                return;
            
            Console.WriteLine($"FirstObserver.Update({s.msg})");
        }
    }

    public class SecondObserver : IObserver
    {
        public void Update<T>(T subject) where T : ISubject
        {
            Subject s = subject as Subject;
            if(s == null)
                return;

            Console.WriteLine($"SecondObserver.Update({s.msg})");
        }
    }

    class SampleProgram
    {
        // static void Main(string[] args)
        // {
        //     Subject subject = new Subject();
        //     FirstObserver first = new FirstObserver();
        //     SecondObserver second = new SecondObserver();
        //     subject.Register(first);
        //     subject.Register(second);

        //     subject.msg = "first message";
        //     subject.Notify();

        //     subject.msg = "second message";
        //     subject.UnRegister(first);
        //     subject.Notify();
        // }
    }
}