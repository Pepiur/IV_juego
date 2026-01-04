using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<int> collectItems = new List<int>();
    static float moveSpeed = 3.5f, moveAccuracy = 0.15f;
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

        myObject.position = point;
        yield return null;
    }

}
