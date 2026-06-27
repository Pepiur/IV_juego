using UnityEngine;

public class PuntoAparicion : MonoBehaviour
{
    [Header("Identificador de esta Puerta")]
    public string idAparicion;
    void Start()
    {
        if (GameManager.Instancia != null && GameManager.Instancia.idProximoSpawn == idAparicion)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");

            if (jugador != null)
            {
                jugador.transform.position = this.transform.position;
                GameManager.Instancia.idProximoSpawn = "";
            }
        }
    }
}