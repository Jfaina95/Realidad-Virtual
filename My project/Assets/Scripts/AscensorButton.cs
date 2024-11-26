using UnityEngine;
using UnityEngine.SceneManagement;

public class AscensorButton : MonoBehaviour
{
    public string escenaDestino; // Nombre de la escena a cargar
    public GameObject puertas; // Referencia a las puertas del ascensor
    public float tiempoDeEspera = 2f; // Tiempo que las puertas estarán cerradas antes de cambiar de escena
    public float distanciaActivacion = 3f; // Distancia a la que el jugador puede activar el ascensor

    private bool enUso = false;
    private GameObject jugador; // Referencia al jugador

    private void Start()
    {
        // Busca el objeto del jugador en la escena (asegúrate de que tenga la etiqueta "Player")
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (jugador != null && !enUso)
        {
            // Verificar la distancia entre el jugador y el ascensor
            float distancia = Vector3.Distance(jugador.transform.position, transform.position);
            if (distancia < distanciaActivacion && Input.GetKeyDown(KeyCode.E))
            {
                enUso = true;
                CerrarPuertas();
            }
        }
    }

    private void CerrarPuertas()
    {
        // Aquí podrías agregar la lógica para cerrar las puertas
        if (puertas != null)
        {
            puertas.SetActive(false); // Cierra las puertas
        }

        Invoke("CargarEscena", tiempoDeEspera); // Espera y luego carga la escena
    }

    private void CargarEscena()
    {
        // Cargar la escena especificada
        SceneManager.LoadScene(escenaDestino);
    }
}