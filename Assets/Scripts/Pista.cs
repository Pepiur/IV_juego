using UnityEngine;

[CreateAssetMenu(fileName = "Pista", menuName = "Juego/Pista")]
public class Pista : ScriptableObject
{
    public string idPista;
    public string nombre;
    [TextArea] public string descripcion;
    public Sprite icono;
}