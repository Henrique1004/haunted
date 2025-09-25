using UnityEngine;

public class Cama : MonoBehaviour
{
    [Header("Configurações")]
    public KeyCode teclaInteracao = KeyCode.E;
    public float raioInteracao = 10f;
    
    private bool jogadorPerto = false;
    private GameObject jogador;
    
    void Update()
    {
        // Verifica se o jogador está perto
        if (jogador != null)
        {
            float distancia = Vector3.Distance(transform.position, jogador.transform.position);
            jogadorPerto = distancia <= raioInteracao;
        }
        
        // Interage com a cama se estiver perto e pressionar E
        if (jogadorPerto && Input.GetKeyDown(teclaInteracao))
        {
            InteragirComCama();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogador = other.gameObject;
            jogadorPerto = true;
            
            // Mostra mensagem apropriada
            if (GameManager.instance != null && GameManager.instance.PodeVoltarParaCama())
            {
                Debug.Log("Pressione E para voltar para a tela inicial");
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            jogador = null;
        }
    }
    
    void InteragirComCama()
    {
        // Usa o Singleton do GameManager
        if (GameManager.instance != null)
        {
            if (GameManager.instance.PodeVoltarParaCama())
            {
                Debug.Log("Voltando para a tela inicial...");
                GameManager.instance.VoltarParaCama();
            }
            else
            {
                Debug.Log("Você precisa coletar todos os itens primeiro!");
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, raioInteracao);
    }
}