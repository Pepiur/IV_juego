using System.Collections.Generic;
using UnityEngine;

public class DialogoCliente : MonoBehaviour
{
    [Header("Configuración de Diálogos")]
    public List<DialogoDataSO> dialogosPosiblesNPC;
    public void HablarConNPC()
    {
        List<Pista> pistasActuales = OrganizadorPistas.Instance.GetPistas();
        int progresoActual = 1; //MODIFICAR THIS

        ContextoJugador contextoActual = new ContextoJugador(pistasActuales, progresoActual);

        // 2. Buscamos qué diálogo mostrar (ejemplo simple: el último de la lista que cumpla condiciones)
        // Pedimos el Flyweight a la fábrica para ahorrar memoria
        foreach (DialogoDataSO dialogo in dialogosPosiblesNPC)
        {
            IDialogoFlyweight dialogoFlyweight = FabricaDialogos.Instancia.ObtenerDialogo(dialogo);
            dialogoFlyweight.EjecutarDialogo(contextoActual);
            break;
        }
    }
}