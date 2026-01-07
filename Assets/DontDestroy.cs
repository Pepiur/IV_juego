using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] persistentGameObjects = new GameObject[3];
    public int idxObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (persistentGameObjects[idxObj] == null)
        {
            persistentGameObjects[idxObj] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (persistentGameObjects[idxObj] != gameObject)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame

}
