using UnityEngine;

namespace Patrones.ObjectPool.Interfaces
{
    public interface IPoolableObject
    {
        void SetActive(bool activo);
        bool IsActive();
        void Reset();
    }
}