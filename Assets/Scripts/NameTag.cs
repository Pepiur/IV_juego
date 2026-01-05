using UnityEngine;

public class NameTag : MonoBehaviour
{

    Vector2 resolution, resolutionInWolrdUnits = new Vector2(17.8f, 10);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resolution = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        transform.position = Input.mousePosition/resolution * resolutionInWolrdUnits;
    }
}
