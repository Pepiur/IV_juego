using UnityEngine;
using Patrones.ObjectPool.Interfaces;

public class Lluvia : MonoBehaviour
{
    [Header("Configuración del Pool")]
    public GotaAgua prefabGota; 
    public int cantidadInicialGotas = 100;

    [Header("Configuración de Lluvia")]
    public float anchoDeTormenta = 10f; 
    public float gotasPorSegundo = 20f;

    private float tiempoEntreGotas;
    private float temporizador;

    private IObjectPool poolDeGotas;

    void Start()
    {
        poolDeGotas = new ObjectPool(prefabGota, cantidadInicialGotas);
        tiempoEntreGotas = 1f / gotasPorSegundo;
    }

    void Update()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= tiempoEntreGotas)
        {
            GenerarGota();
            temporizador = 0f;
        }
    }

    private void GenerarGota()
    {
        IPoolableObject obj = poolDeGotas.Get();
        if (obj is MonoBehaviour gotaMono)
        {
            float xAleatorio = Random.Range(-anchoDeTormenta, anchoDeTormenta);
            Vector3 posicionAparicion = transform.position + new Vector3(xAleatorio, 0, 0);

            gotaMono.transform.position = posicionAparicion;
        }
    }
}