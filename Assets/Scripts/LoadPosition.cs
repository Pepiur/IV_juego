using UnityEngine;

public class LoadPosition : MonoBehaviour
{
    public EstadoEscenas[] estados;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.transform.position = estados[0].posPlayer;
    }

    public void newPositionScene(int idx)
    {
        this.gameObject.transform.position = estados[idx].posPlayer;
    }

    
}
