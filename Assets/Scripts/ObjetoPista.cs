using UnityEngine;

public class ObjetoPista : MonoBehaviour
{
    public Pista datosDeLaPista;
    public bool recogida = false;
    public void SerExaminado()
    {
        if (!recogida)
        {
            OrganizadorPistas.Instance.CollectPista(datosDeLaPista);
            Debug.Log(datosDeLaPista.descripcion);
            DialogoUI.Instance.IniciarDialogo("Detective", datosDeLaPista.descripcion);
            recogida = true;
        }


    }
}