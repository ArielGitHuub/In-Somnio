using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidadBala = 100f;
    public float tiempoDeVida = 2f; // Se destruye en 2 segundos si no choca con nada

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        // Mueve la bala hacia arriba constantemente
        transform.Translate(Vector3.up * velocidadBala * Time.deltaTime);
    }
}