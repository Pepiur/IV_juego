using UnityEngine;
using UnityEngine.UI;

public class SistemaVidaUI : MonoBehaviour
{
    public static SistemaVidaUI Instancia { get; private set; }

    [Header("Configuración Visual")]
    public Image[] iconosVida;
    public Sprite spriteVidaLlena;
    public Sprite spriteVidaVacia;

    private void Awake()
    {
        if (Instancia != null && Instancia != this) Destroy(gameObject);
        else Instancia = this;
    }

    public void ActualizarVidas(int vidaActual, int vidaMaxima)
    {
        for (int i = 0; i < iconosVida.Length; i++)
        {
            if (i < vidaMaxima)
            {
                iconosVida[i].enabled = true; 

               
                iconosVida[i].sprite = (i < vidaActual) ? spriteVidaLlena : spriteVidaVacia;
            }
            else
            {
                iconosVida[i].enabled = false; 
            }
        }
    }
}