using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TextEffect : MonoBehaviour
{
    public TransitionManager transitionManager;
    string frase = "Presiona ESPACIO para continuar...";
    string[] dialogos = {
            "HOLA SOY AUTONOBOT",
            "FUI CREADO POR UASLP",
            "CONSTRUIDO POR LA FACULTAD DE INGENIERÍA",
            "Y PROGRAMADO POR LOS ALUMNOS DE INGENIERÍA EN SISTEMAS COMPUTACIONALES",
            "SI ESTAS IMPRESIONADO POR ESTAR FRENTE A UN ROBOT DE ALTA TECNOLOGÍA",
            "TE IMPRESIONARÁ MÁS LO QUE TENGO POR MOSTRARTE.",
            "¿ME ACOMPAÑAS EN LA AVENTURA POR LA GRAN CARRARA DE SISTEMAS COMPUTACIONEALES?"
            
        };
    public TMP_Text texto;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Reloj()
    {
        yield return new WaitForSeconds(1); // Tiempo antes de comenzar los diálogos

        foreach (string dialogo in dialogos) // Recorremos cada diálogo en el array
        {
            texto.text = ""; // Limpiamos el texto antes de mostrar el siguiente diálogo

            foreach (char caracter in dialogo) // Reproducimos cada diálogo letra por letra
            {
                texto.text += caracter;
                yield return new WaitForSeconds(0.05f); // Controla la velocidad de aparición de cada letra
            }

            // Esperamos que el jugador presione ESPACIO para continuar con el siguiente diálogo
            texto.text += "\n\n" + frase;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        transitionManager.Transition("LevelIntroduction" );
    }
}
