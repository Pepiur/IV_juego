using UnityEngine;
using Patrones.State.Interfaces;

public class Caminar : APlayerState
{
    public Caminar(IPlayer player) : base(player) { }

    public override void FixedUpdate()
    {
        Rigidbody2D rb = player.GetRigidbody();
        Vector2 destino = player.GetPosicionObjetivo();
        float velocidad = player.GetVelocidad();

        Vector2 nuevaPosicion = Vector2.MoveTowards(rb.position, destino, velocidad * Time.fixedDeltaTime);
        rb.MovePosition(nuevaPosicion);

        // Girar el sprite
        Transform transform = rb.transform;
        if (destino.x > rb.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else if (destino.x < rb.position.x)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Vector2.Distance(rb.position, destino) < 0.15f)
        {
            player.CambiarEstado(player.GetStateAnterior());
        }
    }

    public override void Update()
    {
        //Nuevo Input
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.SetPosicionObjetivo(new Vector2(posicionRaton.x, posicionRaton.y));
            player.setStateAnterior(new Idle(player));
        }
    }
}