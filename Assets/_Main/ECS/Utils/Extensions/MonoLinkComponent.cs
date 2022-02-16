using ECS.Views;

namespace ECS.Utils.Extensions
{
    public struct MonoLinkComponent<T> where T : ILinkable
    {
        public T View;
    }
}