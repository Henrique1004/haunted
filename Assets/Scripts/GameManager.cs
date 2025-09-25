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
        AtualizarUI();
        if (textoMissao != null)
            textoMissao.text = "Colete todos os itens";
    }
    
    public void ColetarItem()
    {
        itensColetados++;
        AtualizarUI();
        
        if (itensColetados >= totalItens && !todosItensColetados)
        {
            TodosItensColetados();
        }
    }
    
    void AtualizarUI()
    {
        if (textoContador != null)
        {
            textoContador.text = itensColetados + "/" + totalItens;
        }
    }
    
    void TodosItensColetados()
    {
        todosItensColetados = true;
        if (textoMissao != null)
        {
            textoMissao.text = "Volte a cama para passar a noite";
            textoMissao.color = Color.green;
        }
        Debug.Log("Todos os itens coletados! Volte para a cama.");
    }
    
    public void VoltarParaCama()
    {
        SceneManager.LoadScene("Start");
    }
    
    public bool PodeVoltarParaCama()
    {
        return todosItensColetados;
    }
}