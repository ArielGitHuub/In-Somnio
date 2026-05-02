using UnityEngine;

public class Meteorito : MonoBehaviour
{
    public float velocidadCaida = 2f; // Velocidad suave en unidades de Unity
    private float velocidadLateral;

    void Start()
    {
        // Un ligero desvío hacia los lados (muy sutil)
        velocidadLateral = Random.Range(-0.5f, 0.5f);
    }

    void Update()
    {
        // Movimiento de caída
        transform.Translate(new Vector3(velocidadLateral, -velocidadCaida, 0) * Time.deltaTime);

        // Si sale por debajo de la pantalla (aprox a los -3.5 metros), se destruye
        if (transform.position.y < -3.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Bala"))
        {
            Destroy(otro.gameObject);
            Destroy(gameObject);
        }
    }
}