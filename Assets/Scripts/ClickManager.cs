using System.Collections;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Transform player;
    GameManager gameManager;
    bool playerWalking;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    public void MovePlayerToPista(PistaData pista)
    {
        StartCoroutine(gameManager.MoveToPoint(player, pista.goToPoint.position));
        playerWalking = true;
        TryGetPista(pista);
        UpdateSceneAfterAction(pista);
    }

    

    private void TryGetPista(PistaData pista)
    {
        if(pista.requiredPistaID == -1 || GameManager.collectItems.Contains(pista.pistaID))
        {
            GameManager.collectItems.Add(pista.pistaID);

        }
    }

    private IEnumerator UpdateSceneAfterAction(PistaData pista)
    {
        if (playerWalking)
        {
            yield return new WaitForSeconds(0.05f);
        }
        foreach (GameObject g in pista.pistasToRemove)
        {
            Destroy(g);
        }
        Debug.Log("Item Collect");
    }
}
