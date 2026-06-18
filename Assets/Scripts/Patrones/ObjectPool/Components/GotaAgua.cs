using UnityEngine;
using Patrones.ObjectPool.Interfaces;

public class GotaAgua : MonoBehaviour, IPoolableObject, IPrototype
{
    public float velocidadCaida = 8f;
    public float tiempoDeVida = 2f;

    private float tiempoActual = 0f;
    private IObjectPool pool; 

    public void ConfigurarPool(IObjectPool pool)
    {
        this.pool = pool;
    }

    void Update()
    {
        if (!IsActive()) return;

        transform.Translate(Vector3.down * velocidadCaida * Time.deltaTime);

        tiempoActual += Time.deltaTime;
        if (tiempoActual >= tiempoDeVida)
        {
            pool?.Release(this);
        }
    }


    public IPrototype Clone()
    {
        GameObject clon = Instantiate(this.gameObject);
        return clon.GetComponent<GotaAgua>();
    }

    public void SetActive(bool activo)
    {
        gameObject.SetActive(activo);
    }

    public bool IsActive()
    {
        return gameObject.activeInHierarchy;
    }

    public void Reset()
    {
        tiempoActual = 0f;
    }
}