using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Nomes das cenas")]
    public string Haunted;
    public string Creditos;
    public string Start;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void irParaJogo()
    {
        SceneManager.LoadScene(Haunted);
    }

    public void irParaCreditos()
    {
        SceneManager.LoadScene(Creditos);
    }

    public void voltarParaTelaInicial()
    {
        SceneManager.LoadScene(Start);
    }
}
