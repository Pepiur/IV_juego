using System.Collections.Generic;
using UnityEngine;

public class FabricaDialogos : MonoBehaviour
{
    public static FabricaDialogos Instancia { get; private set; }

    private Dictionary<string, IDialogoFlyweight> cacheDialogos = new Dictionary<string, IDialogoFlyweight>();

    private void Awake()
    {
        if (Instancia != null && Instancia != this) Destroy(gameObject);
        else Instancia = this;
    }

    public IDialogoFlyweight ObtenerDialogo(DialogoDataSO dialogoBase)
    {
        string clave = dialogoBase.idDialogo;
        if (cacheDialogos.ContainsKey(clave))
        {
            return cacheDialogos[clave];
        }

        // Si no está, lo registramos en el caché (en Unity el SO ya es la instancia)
        cacheDialogos.Add(clave, dialogoBase);
        return dialogoBase;
    }
}