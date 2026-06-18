using System.Collections.Generic;

//CLIENTE FLYWEIGHT
public class ContextoJugador
{
    public List<Pista> pistasEnInventario;
    public int progresoHistoria;

    public ContextoJugador(List<Pista> pistas, int progreso)
    {
        this.pistasEnInventario = pistas;
        this.progresoHistoria = progreso;
    }
}
