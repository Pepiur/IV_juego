using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{
    [Header("Configuración de Destino")]
    public string nombreEscenaDestino;
    public string idPuntoAparicionDestino;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"Viajando a {nombreEscenaDestino}, punto: {idPuntoAparicionDestino}");
            GameManager.Instancia.idProximoSpawn = idPuntoAparicionDestino;
            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }
}