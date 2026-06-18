using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogoUI : MonoBehaviour
{
    public static DialogoUI Instance { get; private set; }

    [Header("Referencias de UI")]
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TextMeshProUGUI textoNombre;
    [SerializeField] private TextMeshProUGUI textoDialogo;
    public float closeDialogo = 4.0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        panelDialogo.SetActive(false);
    }

    // SistemaDialogos.Instance.IniciarDialogo("Edgeworth", "Hmm... Esto es contradictorio.");
    public void IniciarDialogo(string nombreHablando, string contenido)
    {
        panelDialogo.SetActive(true);
        textoNombre.text = nombreHablando;
        textoDialogo.text = contenido;
        StartCoroutine(WaitAndClose());
    }

    IEnumerator WaitAndClose()
    {
        yield return new WaitForSeconds(this.closeDialogo);
        textoNombre.text = "";
        textoDialogo.text = "";
        CerrarDialogo();
    }

    public void CerrarDialogo()
    {
        panelDialogo.SetActive(false);
    }
}