using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlagCajas : MonoBehaviour
{
   public SceneController sceneControllerScript;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject[] _Agarrables = GameObject.FindGameObjectsWithTag("Ordenado");
        if (_Agarrables.Count()>=3)
        {
            sceneControllerScript.NextLevel("Level3");  
            
            
        }
    }
}
