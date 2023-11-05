using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckPass : MonoBehaviour
{
    public Object cave;
    public static bool caveOpen;
    
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            
            caveOpen = true;
            cave.GetComponent<TilemapRenderer>().enabled = false;

        }
        

    }
    
}
