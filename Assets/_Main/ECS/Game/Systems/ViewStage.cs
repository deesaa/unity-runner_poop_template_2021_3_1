public abstract class ViewStage<T, TV>
{
    protected T View;
    public abstract void Message(string message, TV data);
    public virtual void OnEnter() {}
    public virtual void OnExit() {}
}