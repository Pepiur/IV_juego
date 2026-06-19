using UnityEngine;
using Patrones.State.Interfaces;

public class Idle : APlayerState
{
    public Idle(IPlayer player) : base(player) { }

    public override void Update()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.SetPosicionObjetivo(new Vector2(posicionRaton.x, posicionRaton.y));

            player.CambiarEstado(new Caminar(player));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.SetPosicionObjetivo(new Vector2(posicionRaton.x, posicionRaton.y));
            player.CambiarEstado(new Interactuar(player));
        }
    }
}