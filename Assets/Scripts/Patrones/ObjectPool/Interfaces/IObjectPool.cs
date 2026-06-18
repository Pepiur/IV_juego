using UnityEngine;

namespace Patrones.ObjectPool.Interfaces
{
    public interface IObjectPool
    {
        IPoolableObject Get();
        void Release(IPoolableObject @object);
    }
}
