using UnityEngine;

public class NaveController : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 20f;
    public float limiteX = 80f;

    [Header("Disparo Automático")]
    public GameObject prefabBala;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos = 0.3f;
    private float temporizador;

    [Header("Daño Visual")]
    public Sprite spriteNaveDanada; // Arrastra tu nuevo dibujo dañado aquí en el Inspector
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Obtenemos el componente que dibuja la nave en pantalla
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // MOVIMIENTO
        float movimientoX = Input.GetAxisRaw("Horizontal");
        Vector3 nuevaPosicion = transform.position + new Vector3(movimientoX * velocidad * Time.deltaTime, 0, 0);
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, -limiteX, limiteX);
        transform.position = nuevaPosicion;

        // DISPARO
        temporizador -= Time.deltaTime;
        if (temporizador <= 0f)
        {
            Instantiate(prefabBala, puntoDisparo.position, Quaternion.identity);
            temporizador = tiempoEntreDisparos;
        }
    }

    // Detectar si un meteorito nos golpea
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Meteorito"))
        {
            // Cambiamos el dibujo de la nave al instante
            if (spriteRenderer != null && spriteNaveDanada != null)
            {
                spriteRenderer.sprite = spriteNaveDanada;
            }
        }
    }
}