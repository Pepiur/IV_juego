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

        blockImage.gameObject.SetActive(false);
    }

    public void CargarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void SalirApp()
    {
        Application.Quit();
    }

    public void Verga(PasarEscenaData escena, GameObject[] escenas)
    {
        if(escena.derecha)
        {
            escenas[escena.idx].SetActive(false);
            escenas[escena.idx + 1].SetActive(true);
        }
        else
        {
            escenas[escena.idx].SetActive(false);
            escenas[escena.idx - 1].SetActive(true);
        }
    }

    //HOLAAAAAAAAAAAAAAAA
}
