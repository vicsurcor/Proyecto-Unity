using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
  
  //Recarga la escena para el respawn
   public void Respawn(string sceneName)
   {

     SceneManager.LoadScene(sceneName);

   }
}
