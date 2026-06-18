using System.Collections.Generic;
using Patrones.ObjectPool.Interfaces;

public class ObjectPool : IObjectPool
{
    private Queue<IPoolableObject> gotas = new Queue<IPoolableObject>();
    private IPrototype prototipoBase;

    public ObjectPool(IPrototype prototipo, int cantidadInicial)
    {
        this.prototipoBase = prototipo;

        for (int i = 0; i < cantidadInicial; i++)
        {
            CrearGota();
        }
    }

    private IPoolableObject CrearGota()
    {
        IPrototype nuevoClon = prototipoBase.Clone();
        IPoolableObject poolableObj = nuevoClon as IPoolableObject;

        poolableObj.SetActive(false);
        gotas.Enqueue(poolableObj);

        if (nuevoClon is GotaAgua gota)
        {
            gota.ConfigurarPool(this);
        }

        return poolableObj;
    }

    public IPoolableObject Get()
    {
        IPoolableObject obj;
        if (gotas.Count > 0)
        {
            obj = gotas.Dequeue();
        }
        else
        {
            obj = CrearGota();
            obj = gotas.Dequeue();
        }

        obj.Reset();
        obj.SetActive(true);
        return obj;
    }

    public void Release(IPoolableObject obj)
    {
        obj.SetActive(false);
        gotas.Enqueue(obj);
    }
}