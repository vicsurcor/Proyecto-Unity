using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    
    public static bool isGrounded;

    //Reconoce que el jugador esta en el suelo
    private void OnTriggerEnter2D(){

        isGrounded = true;

    }
    //Reconoce que el jugador no esta en el suelo
    private void OnTriggerExit2D(){

        isGrounded = false;

    }

}
