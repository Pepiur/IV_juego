using UnityEngine;

namespace Patrones.ObjectPool.Interfaces
{
    public interface IPrototype
    {
        public IPrototype Clone();
    }
}