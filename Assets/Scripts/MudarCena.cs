using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    // Nome da cena que você quer carregar
    public string Haunted;

    // Método público que pode ser chamado por botão ou outro script
    public void MudarCena()
    {
        SceneManager.LoadScene(Haunted);
    }
}
