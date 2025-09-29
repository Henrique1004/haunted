using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
     [Header("Configurações UI - TextMeshPro")]
    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textoMissao;
    public int totalItens = 6;
    
    private int itensColetados = 0;
    private bool todosItensColetados = false;
     
     void Awake()
    {
        // Configura o singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        AtualizarUI();// Atualiza o TextMesh 
        if (textoMissao != null)
            textoMissao.text = "Colete todos os itens";
    }
    
    public void ColetarItem()// Contagem de itens coletados
    {
        itensColetados++;
        AtualizarUI();
        
        if (itensColetados >= totalItens && !todosItensColetados)
        {
            TodosItensColetados();
        }
    }
    
    void AtualizarUI()// Atualizador de contagem
    {
        if (textoContador != null)
        {
            textoContador.text = itensColetados + "/" + totalItens;
        }
    }
    
    void TodosItensColetados()// Aviso de todos os itens coletados
    {
        todosItensColetados = true;
        if (textoMissao != null)
        {
            textoMissao.text = "Volte a cama para passar a noite";
            textoMissao.color = Color.green;
        }
    }
    
    public void VoltarParaCama()// Voltar ao menu principal
    {
        AtivarCursorMenu();
        SceneManager.LoadScene("Start");
    }
    
    public bool PodeVoltarParaCama()// verificação se ja pode voltar para a cama
    {
        return todosItensColetados;
    }

    public static void AtivarCursorJogo()//Ativar o mouse
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void AtivarCursorMenu()// Desativar o mouse
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}