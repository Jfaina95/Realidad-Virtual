using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenarioManager : MonoBehaviour
{
    // Nombre de las escenas
    public string escena1 = "Escena1";
    public string escena2 = "Escena2";

    void Update()
    {
        // Cambiar a Escena2 al presionar la tecla "1"
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CargarEscena(escena1);
        }

        // Cambiar a Escena1 al presionar la tecla "2"
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CargarEscena(escena2);
        }
    }

    void CargarEscena(string nombreEscena)
    {
        // Cargar la escena especificada
        SceneManager.LoadScene(nombreEscena);
    }
}