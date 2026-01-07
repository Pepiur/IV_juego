using System.Collections;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Transform player;
    GameManager gameManager;
    public bool playerWalking;
    Camera camera;
    Coroutine goToClickCorrutine;
    float goToClickMaxY = 5.0f;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        camera = GetComponent<Camera>();
    }

    public void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            goToClickCorrutine = StartCoroutine(GoToClick(Input.mousePosition));
        }
    }

    public IEnumerator GoToClick(Vector2 mousePoistion)
    {
        yield return new WaitForSeconds(0.05f);

        Vector2 targetPos = camera.ScreenToWorldPoint(mousePoistion);

        if(targetPos.y > goToClickMaxY || playerWalking)
        {
            yield break;
        }

        gameManager.UpdateHintTag(null, false);

        playerWalking = true;
        StartCoroutine(gameManager.MoveToPoint(player, targetPos));

        StartCoroutine(CleanAfterClick());
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
            yield return null;
        }
        gameManager.TransicionEscena(escena);
        yield return null;
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
        yield return null;
        if (goToClickCorrutine != null)
        {
            StopCoroutine(goToClickCorrutine);
        }

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

    private IEnumerator CleanAfterClick()
    {
        while(playerWalking)
        {
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
    }

}
