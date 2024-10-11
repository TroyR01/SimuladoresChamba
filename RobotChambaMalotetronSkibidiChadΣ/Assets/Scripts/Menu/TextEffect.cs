using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextEffect : MonoBehaviour
{

    string frase = "Presiona ESPACIO para continuar...";
    public Text texto;
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
        yield return new WaitForSeconds(10); //Tiempo promedio de las cinem�ticas para mostrar el mensaje
        foreach (char caracter in frase)//Ciclo que permite hacer la animaci�n en el texto
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.2f);
        }
        
    }
}
