using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagGoal : MonoBehaviour
{
   public SceneController sceneControllerScript;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sceneControllerScript.NextLevel("Level3");  
            
            
        }
    }
}
