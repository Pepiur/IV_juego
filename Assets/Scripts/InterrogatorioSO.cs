using UnityEngine;

[CreateAssetMenu(fileName = "Interrogatorio", menuName = "Juego/Interrogatorio")]
public class InterrogatorioSO : ScriptableObject
{
    public string personaje;

    [Header("Las Declaraciones (Testimonio)")]
    [TextArea(2, 4)]
    public string[] frases; 

    [Header("La Solución")]
    public int indiceFraseDebil; // ¿En qué frase está la mentira? (0, 1, 2...)
    public Pista pistaRequerida; // ¿Qué pista desmonta la mentira?

    [Header("Consecuencias del Éxito")]
    public DialogoDataSO dialogoExito; // El diálogo que se reproduce al atraparlo
    public int progresoOtorgado = 1;   // Cuánto avanza la historia al ganar
}