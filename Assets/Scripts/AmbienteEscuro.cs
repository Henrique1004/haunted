using UnityEngine;

public class AmbienteUltraEscuro : MonoBehaviour
{
    [Header("Configurações Ultra Escuras")]
    public Color corFundo = Color.black;
    public float intensidadeLuzAmbiente = 0.01f; // Quase zero!
    
    void Start()
    {
        ConfigurarEscuridaoTotal();
    }
    
    void ConfigurarEscuridaoTotal()
    {
        // Fundo completamente preto
        Camera.main.backgroundColor = Color.black;
        
        // Luz ambiente quase inexistente
        RenderSettings.ambientLight = Color.black;
        RenderSettings.ambientIntensity = intensidadeLuzAmbiente;
        RenderSettings.reflectionIntensity = 0f;
        
        // Remove completamente o skybox
        RenderSettings.skybox = null;
        // Desliga ou reduz drasticamente TODAS as luzes da cena
        Light[] todasAsLuzes = FindObjectsOfType<Light>();

        foreach (Light luz in todasAsLuzes)
        {
            if (luz.type != LightType.Spot) // Preserva apenas spots (lanterna)
            {
                luz.intensity = 0.02f; // Quase apagadas
                luz.enabled = false; // Ou desliga completamente
            }
        }
        
        // Configuração extra para escuridão profunda
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
    }
    
    // Método para escurecer ainda mais durante o jogo
    public void EscurecerTotalmente()
    {
        Camera.main.backgroundColor = new Color(0.01f, 0.01f, 0.01f); // Quase preto
        RenderSettings.ambientIntensity = 0.005f; // Quase zero
    }
}