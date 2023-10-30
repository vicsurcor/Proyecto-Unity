using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collider){

        isGrounded = true;

    }

    private void OnTriggerExit2D(Collider2D collider){

        isGrounded = false;

    }

}
