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
    
    void OnTriggerEnter(Collider other)// Player entra no Trigger
    {
        if (other.CompareTag("Player"))
        {
            jogador = other.gameObject;
            jogadorPerto = true;
        }
    }
    
    void InteragirComCama()
    {
        // Usa o Singleton do GameManager
        if (GameManager.instance != null)
        {
            if (GameManager.instance.PodeVoltarParaCama())
            {
                GameManager.instance.VoltarParaCama();
            }
        }
    }
    void OnTriggerExit(Collider other)// Player sai do Trigger
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            jogador = null;
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, raioInteracao);
    }
}