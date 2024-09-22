using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject Menu;  // Referencia al menú de pausa en la UI
    private bool isPaused = false;  // Indica si el juego está en pausa

    void Update()
    {
        // Detectar si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();  // Si el juego ya está pausado, reanudar
            }
            else
            {
                PauseGame();   // Si el juego no está pausado, pausar
            }
        }
    }

    // Método para pausar el juego
    public void PauseGame()
    {
        Menu.SetActive(true);  // Mostrar el menú de pausa
        Time.timeScale = 0f;          // Detener el tiempo en el juego
        isPaused = true;              // Marcar el estado como pausado
    }

    // Método para reanudar el juego
    public void ResumeGame()
    {
        Menu.SetActive(false);  // Ocultar el menú de pausa
        Time.timeScale = 1f;           // Reanudar el tiempo en el juego
        isPaused = false;              // Marcar el estado como no pausado
    }

    // Método que se llama desde el botón para pausar/reanudar
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();  // Si está pausado, reanudar
        }
        else
        {
            PauseGame();   // Si no está pausado, pausar
        }
    }
}

