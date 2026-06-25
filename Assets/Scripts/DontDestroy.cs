using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instancia;

    private void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(this.gameObject);
    }
}