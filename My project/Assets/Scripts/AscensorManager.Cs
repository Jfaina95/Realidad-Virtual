using UnityEngine;
using UnityEngine.SceneManagement;

public class AscensorManager : MonoBehaviour
{
    public AscensorButton[] botonesAscensor; // Array de botones de ascensor
    public GameObject puertas; // Referencia a las puertas del ascensor
    public float tiempoDeEspera = 2f; // Tiempo que las puertas estarán cerradas antes de cambiar de escena
    private bool enUso = false;

    void Start()
    {
        // Asegúrate de que los botones estén configurados
        foreach (var boton in botonesAscensor)
        {
            boton.manager = this; // Asignar el manager a cada botón
        }
    }

    public void CerrarPuertas(string escenaDestino)
    {
        if (enUso) return;

        enUso = true;

        // Aquí podrías agregar la lógica para cerrar las puertas
        if (puertas != null)
        {
            puertas.SetActive(false); // Cierra las puertas
        }

        Invoke("CargarEscena", tiempoDeEspera); // Espera y luego carga la escena
    }

    private void CargarEscena(string escenaDestino)
    {
        // Cargar la escena especificada
        SceneManager.LoadScene(escenaDestino);
    }

    public void AbrirPuertas()
    {
        // Lógica para abrir las puertas (puedes activar el objeto de las puertas aquí)
        if (puertas != null)
        {
            puertas.SetActive(true); // Abre las puertas
        }

        enUso = false; // Permitir que se use el ascensor de nuevo
    }
}