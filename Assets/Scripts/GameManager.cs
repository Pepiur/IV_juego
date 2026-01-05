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
    public IEnumerator MoveToPoint(Transform myObject,Vector2 point)
    {
        Vector2 positionDifference = point - (Vector2)myObject.position;
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
        yield return null;
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
        { hintBox.localPosition = new Vector2(0, 4f); }
        else { hintBox.localPosition = new Vector2(0, 4f); }
    }

}
