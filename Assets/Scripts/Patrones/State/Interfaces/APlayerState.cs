using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
namespace Patrones.State.Interfaces
{
    public abstract class APlayerState : IState
    {
        protected IPlayer player;

        public APlayerState(IPlayer player)
        {
            this.player = player;
        }

        public abstract void Caminar();
        public abstract void InteractuarPista();
        public abstract void InteractuarPersonaje();
        public abstract void Logica();
        public abstract void Update();
        public abstract void FixedUpdate();
    }
}
