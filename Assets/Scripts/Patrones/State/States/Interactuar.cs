using Patrones.State.Interfaces;
using UnityEngine;

public class Interactuar : APlayerState
{
    public Interactuar(IPlayer player) : base(player) { }

    public override void Enter()
    {

        LayerMask capaPistas = player.GetCapaPistas();
        LayerMask capaNPCs = player.GetCapaNPCs();
        Rigidbody2D rb = player.GetRigidbody();

        RaycastHit2D hitPistas = Physics2D.Raycast(player.GetPosicionObjetivo(), Vector2.zero, 0f, capaPistas);
        RaycastHit2D hitNpc = Physics2D.Raycast(player.GetPosicionObjetivo(), Vector2.zero, 0f, capaNPCs);

        if (Vector2.Distance(rb.position, player.GetPosicionObjetivo()) > 0.15f && (hitPistas.collider != null || hitNpc.collider != null))
        {
            player.CambiarEstado(new Caminar(player));
        }
        else
        {
            if (hitPistas.collider != null)
            {
                Debug.Log("Interactuando con: " + hitPistas.collider.name);
                hitPistas.collider.gameObject.GetComponent<ObjetoPista>().SerExaminado();
                //hitPistas.collider.gameObject.GetComponent<DialogoCliente>().HablarConNPC();
                TerminarInteraccion();
            }
            else if (hitNpc.collider != null)
            {
                Debug.Log("Interactuando con: " + hitNpc.collider.name);
                hitNpc.collider.gameObject.GetComponent<DialogoCliente>().HablarConNPC();
                TerminarInteraccion();
            }
            else
            {
                player.CambiarEstado(new Idle(player));
            }
        }


    }

    public void TerminarInteraccion()
    {
        player.CambiarEstado(new Idle(player));
    }
}
