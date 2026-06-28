using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaTooltip : MonoBehaviour
{
    public static SistemaTooltip Instancia { get; private set; }

    [Header("Referencias de UI")]
    public GameObject panelTooltip;
    public TextMeshProUGUI textoTooltip;

    private RectTransform rectTransformTooltip;

    [Header("Configuración")]
    public Vector3 offsetCursor = new Vector3(20f, -20f, 0f);

    public event Action<bool> OnResaltarObjetos;

    private void Awake()
    {
        if (Instancia != null && Instancia != this) Destroy(gameObject);
        else Instancia = this;

        if (panelTooltip != null)
        {
            rectTransformTooltip = panelTooltip.GetComponent<RectTransform>();
        }
    }

    private void Start()
    {
        OcultarTooltip();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += AlCargarEscena;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AlCargarEscena;
    }

    private void AlCargarEscena(Scene escena, LoadSceneMode modo)
    {
        OcultarTooltip();
    }
    private void Update()
    {
        if (panelTooltip.activeSelf)
        {
            Vector2 posicionRaton = Input.mousePosition;
            rectTransformTooltip.position = new Vector3(posicionRaton.x + offsetCursor.x, posicionRaton.y + offsetCursor.y, 0f);
        }


        if (Input.GetMouseButtonDown(2))
        {

            OnResaltarObjetos?.Invoke(true);
        }

        else if (Input.GetMouseButtonUp(2))
        {

            OnResaltarObjetos?.Invoke(false);
        }

    }

    public void MostrarTooltip(string mensaje)
    {
        textoTooltip.text = mensaje;
        panelTooltip.SetActive(true);
    }

    public void OcultarTooltip()
    {
        panelTooltip.SetActive(false);
        textoTooltip.text = "";
    }
}