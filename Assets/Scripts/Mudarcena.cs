using UnityEngine;
using UnityEngine.SceneManagement;

public class Mudarcena : MonoBehaviour
{
    public static Mudarcena Instance;

    [Header("Nomes das cenas")]
    public string Jogo;
    public string Creditos;
    public string Inicio;

    public void irParaJogo()// Vai para o jogo
    {
        GameManager.AtivarCursorJogo();
        SceneManager.LoadScene(Jogo);
    }

    public void irParaCreditos()// Vai para os creditos
    {
        SceneManager.LoadScene(Creditos);
    }

    public void voltarParaTelaInicial()// Vai para o inicio
    {
        GameManager.AtivarCursorMenu();
        SceneManager.LoadScene(Inicio);
    }
}
