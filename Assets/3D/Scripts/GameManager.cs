using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuración")]
    public int cerebrosNecesarios = 5;

    [Header("Referencias")]
    public Text textoCerebros;
    public Puerta puerta;

    int cerebros = 0;

    void Awake()
    {
        Instance = this;
        ActualizarUI();
    }

    void Start()
    {
        // La puerta aparece al recoger todos los cerebros
        if (puerta != null)
            puerta.gameObject.SetActive(false);

        int enEscena = FindObjectsByType<Cerebro>(FindObjectsSortMode.None).Length;
        Debug.Log("Cerebros en la escena: " + enEscena);
        if (enEscena < cerebrosNecesarios)
            Debug.LogWarning("Hay menos cerebros que los necesarios, la puerta nunca aparecerá.");
    }

    public void SumarCerebro()
    {
        cerebros++;
        ActualizarUI();
        Debug.Log("Cerebros: " + cerebros);

        if (cerebros >= cerebrosNecesarios && puerta != null)
            puerta.gameObject.SetActive(true);
    }

    void ActualizarUI()
    {
        if (textoCerebros != null)
            textoCerebros.text = "Cerebros: " + cerebros + "/" + cerebrosNecesarios;
    }

    // Se llama cuando el zombie cruza la puerta
    public void CruzarPuerta()
    {
        Debug.Log("¡Cruzaste la puerta!");
        // Aquí irá lo que pase después (victoria, siguiente fase, etc.)
    }

    // Se llama cuando el oso alcanza al zombie
    public void PerderJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}