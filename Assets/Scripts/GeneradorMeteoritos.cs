using UnityEngine;

public class GeneradorMeteoritos : MonoBehaviour
{
    public GameObject prefabMeteorito;
    public float tiempoBaseAparicion = 0.8f;
    public float limitePantallaX = 70f; // Para que no aparezcan fuera de la TV
    public float alturaAparicionY = 100f; // Justo arriba, fuera de la vista

    private float temporizador;

    void Update()
    {
        temporizador -= Time.deltaTime;

        if (temporizador <= 0f)
        {
            GenerarRoca();
            // Hace que el tiempo entre meteoritos sea un poco aleatorio (impredecible)
            temporizador = Random.Range(tiempoBaseAparicion * 0.5f, tiempoBaseAparicion * 1.5f);
        }
    }

    void GenerarRoca()
    {
        // Elige un punto X al azar a lo ancho de la pantalla
        float posicionX = Random.Range(-limitePantallaX, limitePantallaX);
        Vector3 puntoDeAparicion = new Vector3(posicionX, alturaAparicionY, 0);

        // Crea el meteorito en ese punto
        Instantiate(prefabMeteorito, puntoDeAparicion, Quaternion.identity);
    }
}