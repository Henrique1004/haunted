using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    [Header("Configurações")]
    public KeyCode teclaColeta = KeyCode.E;
    public float raioInteracao = 3f;
    
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
        
        // Coleta o item se estiver perto e pressionar E
        if (jogadorPerto && Input.GetKeyDown(teclaColeta))
        {
            ColetarItem();
        }
    }
    
    void OnTriggerEnter(Collider other)// Chega perto do item para coletar
    {
        if (other.CompareTag("Player"))
        {
            jogador = other.gameObject;
            jogadorPerto = true;
        }
    }
    
    void OnTriggerExit(Collider other)// Sai de perto do item para coletar
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            jogador = null;
        }
    }
    
    void ColetarItem()// Para coletar os itens
    {
        // Usa o Singleton do GameManager
        if (GameManager.instance != null)
        {
            GameManager.instance.ColetarItem();
            Destroy(gameObject);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, raioInteracao);
    }
}