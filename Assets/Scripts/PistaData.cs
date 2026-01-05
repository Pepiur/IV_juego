using UnityEngine;

public class PistaData : MonoBehaviour
{
    public int pistaID, requiredPistaID;
    public Transform goToPoint;
    public GameObject[] pistasToRemove;
    public string pistaName;
    public Vector2 pistaNameTagSize = new Vector2(2.4f, 0.67f);
    [TextArea(3,3)] public string objetoMensaje;
    public Vector2 textoNameTagSize = new Vector2(2.4f, 0.67f);
}
