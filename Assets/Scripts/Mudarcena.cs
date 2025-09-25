using UnityEngine;
using UnityEngine.SceneManagement;

public class Mudarcena : MonoBehaviour
{
    public static Mudarcena Instance;

    [Header("Nomes das cenas")]
    public string Jogo;
    public string Creditos;
    public string Inicio;

    public void irParaJogo()
    {
        SceneManager.LoadScene(Jogo);
    }

    public void irParaCreditos()
    {
        SceneManager.LoadScene(Creditos);
    }

    public void voltarParaTelaInicial()
    {
        SceneManager.LoadScene(Inicio);
    }
}
