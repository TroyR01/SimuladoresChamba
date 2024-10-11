using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public float transitionTime = 0;
    public string transitionScene;
    public bool timeChange = false;
    void Update()
    {
        if(timeChange)
        {
            StartCoroutine(TransitionToScene(transitionScene));
        }
    }
    public void Transition(string sceneName)
    {
        StartCoroutine(TransitionToScene(sceneName));
    }
    // Corutina para manejar la transición de escena
    IEnumerator TransitionToScene(string newScene)
    {

        // Esperar el tiempo de duración de la animación de transición
        yield return new WaitForSeconds(transitionTime);

        // Cargar la nueva escena
        SceneManager.LoadScene(newScene);

    }
}
