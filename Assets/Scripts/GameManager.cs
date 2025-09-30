using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections; // necessário para IEnumerator

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Configurações UI - TextMeshPro")]
    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textoMissao;
    public GameObject textoDaTela;

    [Header("Timer")]
    public TextMeshProUGUI textoTimer;
    public float tempoRestante = 300f; // 5 minutos
    private bool timerAtivo = true;

    [Header("Missão")]
    public int totalItens = 6;
    private int itensColetados = 0;
    private bool todosItensColetados = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        AtualizarUI(); // Atualiza o contador de itens
        if (textoMissao != null)
            textoMissao.text = "Colete todos os itens antes dele chegar em você";

        if (textoDaTela != null)
            textoDaTela.SetActive(false); // Esconde o texto inicialmente
    }

    void Update()
    {
        AtualizarTimer();
    }

    // ========= COLETA DE ITENS =========

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
        timerAtivo = false; // Para o cronômetro

        if (textoMissao != null)
        {
            textoMissao.text = "Volte à cama para passar a noite";
            textoMissao.color = Color.green;
        }
    }

    // ========= TIMER =========

    void AtualizarTimer()
    {
        if (!timerAtivo) return;

        if (tempoRestante > 0)
        {
            tempoRestante -= Time.deltaTime;

            int minutos = Mathf.FloorToInt(tempoRestante / 60);
            int segundos = Mathf.FloorToInt(tempoRestante % 60);
            textoTimer.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
        else
        {
            tempoRestante = 0;
            timerAtivo = false;
            textoTimer.text = "00:00";

            TempoAcabou();
        }
    }

    void TempoAcabou()
    {
        if (!todosItensColetados)
        {
            if (textoMissao != null)
            {
                textoMissao.text = "Você não conseguiu coletar os itens a tempo!";
                textoMissao.color = Color.red;
            }

            if (textoDaTela != null)
            {
                textoDaTela.SetActive(true); // Mostra o aviso Game Over
            }

            StartCoroutine(PausarAntesDeVoltar());
        }
    }

    IEnumerator PausarAntesDeVoltar()
    {
        Time.timeScale = 0f; // Pausa o tempo do jogo

        float tempoReal = 0f;
        float duracaoPausa = 5f;

        while (tempoReal < duracaoPausa)
        {
            tempoReal += Time.unscaledDeltaTime; // Conta o tempo real, mesmo com o jogo pausado
            yield return null;
        }

        Time.timeScale = 1f; // Restaura o tempo normal
        VoltarParaCama();    // Troca de cena
    }

    // ========= GERENCIAMENTO DE CENA / CURSOR =========

    public void VoltarParaCama()
    {
        AtivarCursorMenu();
        SceneManager.LoadScene("Start"); // Nome da cena inicial
    }

    public bool PodeVoltarParaCama()
    {
        return todosItensColetados;
    }

    public static void AtivarCursorJogo()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void AtivarCursorMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
