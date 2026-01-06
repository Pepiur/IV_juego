using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestorEscenas : MonoBehaviour
{
    public Image blockImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        Color c = blockImage.color;
        while (blockImage.color.a > 0)
        {
            c.a -= Time.deltaTime;
            blockImage.color = c;
        }
        blockImage.gameObject.SetActive(false);
    }

    public void CargarJuego()
    {

    }

    public void SalirApp()
    {
        Application.Quit();
    }

    public void CambiarEscena(PasarEscenaData escena)
    {
        if(escena.derecha)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
