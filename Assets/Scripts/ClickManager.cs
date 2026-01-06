using System.Collections;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Transform player;
    GameManager gameManager;
    public bool playerWalking;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    public void MovePlayerToPista(PistaData pista)
    {
        //Update hint box
        gameManager.UpdateHintTag(null, false);
        //ANIMATION HERE
        playerWalking = true;
        //MovePlayer
        StartCoroutine(gameManager.MoveToPoint(player, pista.goToPoint.position));
        TryGetPista(pista);
        
    }

    public void MovePlayerToEndScene(PasarEscenaData escena)
    {
        playerWalking = true;
        StartCoroutine(gameManager.MoveToPoint(player, escena.goToPoint.position));
        StartCoroutine(HacerTiempo(escena));
        
    }

    private IEnumerator HacerTiempo(PasarEscenaData escena)
    {
        while (playerWalking)
        {
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(gameManager.TransicionEscena(escena));
    }

    private void TryGetPista(PistaData pista)
    {
        bool canget = pista.requiredPistaID == -1 || GameManager.collectItems.Contains(pista.pistaID);
        if (canget)
        {
            GameManager.collectItems.Add(pista.pistaID);

        }
        StartCoroutine(UpdateSceneAfterAction(pista, canget));
    }

    private IEnumerator UpdateSceneAfterAction(PistaData pista, bool canGetItem)
    {
        while (playerWalking)
        {
            yield return new WaitForSeconds(0.05f);
        }
        if(canGetItem)
        {
            foreach (GameObject g in pista.pistasToRemove)
            {
                Destroy(g);
            }
            Debug.Log("Item Collect");
        }
        else
        {
            gameManager.UpdateHintTag(pista, player.GetComponentInChildren<SpriteRenderer>().flipX);
        }
            yield return null;
    }
}
