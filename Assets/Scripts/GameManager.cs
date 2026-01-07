using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static List<int> collectItems = new List<int>();
    static float moveSpeed = 3.5f, moveAccuracy = 0.15f;
    public RectTransform nameTag, hintBox;
    GestorEscenas gestorEscenas;
    public Image blockImage;
    public GameObject pistas;

    private void Start()
    {
        gestorEscenas = GetComponent<GestorEscenas>();
    }

    public IEnumerator MoveToPoint(Transform myObject,Vector2 point)
    {
        hintBox.gameObject.SetActive(false);
        Vector2 positionDifference = point - (Vector2)myObject.position;

        if(myObject.GetComponent<SpriteRenderer>() && positionDifference.x != 0)
        {
            myObject.GetComponent<SpriteRenderer>().flipX = positionDifference.x > 0;
        }
        while (positionDifference.magnitude > moveAccuracy)
        {
            myObject.Translate(moveSpeed * positionDifference.normalized * Time.deltaTime);
            positionDifference = point - (Vector2)myObject.position;
            yield return null;
        }
        if(myObject == FindFirstObjectByType<ClickManager>().player)
        {
            FindFirstObjectByType<ClickManager>().playerWalking = false;
        }
        myObject.position = point;
        FindFirstObjectByType<LoadPosition>().estado.posPlayer = point;
        yield return null;
    }

    public void TransicionEscena(PasarEscenaData escena)
    {
        blockImage.gameObject.SetActive(true);
        Color c = blockImage.color;
        c.a = 0.7f;
        while (blockImage.color.a < 1)
        {
            c.a += Time.deltaTime;
            blockImage.color = c;
        }
        gestorEscenas.CambiarEscena(escena);
    }

    public void UpdateNameTag(PistaData pista)
    {
        nameTag.GetComponentInChildren<TextMeshProUGUI>().text = pista.pistaName;

        nameTag.sizeDelta = pista.pistaNameTagSize;

        nameTag.localPosition = new Vector2(-pista.pistaNameTagSize.x/2,0.5f);
    }

    public void UpdateHintTag(PistaData pista, bool playerFlipped)
    {

        if(pista == null)
        {
            hintBox.gameObject.SetActive(false);
            return;
        }
        hintBox.gameObject.SetActive(true);
        hintBox.GetComponentInChildren<TextMeshProUGUI>().text = pista.objetoMensaje;

        hintBox.sizeDelta = pista.textoNameTagSize;

        if(playerFlipped)
        { hintBox.localPosition = new Vector2(0, 2f); }
        else { hintBox.localPosition = new Vector2(0, 2f); }
        bool delay = true;
        StartCoroutine(turnOffHint(delay));
        
    }

    private IEnumerator turnOffHint(bool delay)
    {
        if (delay) { delay = false;  yield return new WaitForSeconds(7.0f); }
        hintBox.gameObject.SetActive(false);
    }

}
