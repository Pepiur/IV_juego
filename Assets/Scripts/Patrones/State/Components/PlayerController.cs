using UnityEngine;
using Patrones.State.Interfaces;
using IState = Patrones.State.Interfaces.IState;
public class PlayerController : MonoBehaviour, IPlayer
{
    public Transform player;
    GameManager gameManager;
    public bool playerWalking;
    Camera camera;
    Coroutine goToClickCorrutine;

    private IState currentState;

    public Transform[] pistas;

    private Animator animator; //ESTO SE USARA PARA LAS ANIMACIONES

    private void Awake()
    {
        //animator = gameObject.GetComponent<Animator>(); PA ANIMACIONES
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    //GET SET STATE
    public IState GetState()
    {
        return currentState;
    }

    public void SetState(IState state)
    {
        // Exit old state
        if (currentState != null)
        {
            currentState.Exit();
        }

        // Set current state and enter
        currentState = state;
        currentState.Enter();
    }
    public void MoveTo(Transform target)
    {

    }
    public void GetPista()
    {

    }
}
