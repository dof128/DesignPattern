namespace WFang.DesignPattern.Observer
{
    public interface ISubject
    {
        void Register(IObserver observer);
        void UnRegister(IObserver observer);
        void Notify();
    }
    
    public interface IObserver 
    {
        void Update<T>(T subject) where T : ISubject;
    }
}