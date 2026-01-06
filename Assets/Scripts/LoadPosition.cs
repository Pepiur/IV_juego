using UnityEngine;

public class LoadPosition : MonoBehaviour
{
    public EstadoEscenas estado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.transform.position = estado.posPlayer;
    }


    
}
