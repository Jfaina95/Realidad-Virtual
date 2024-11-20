using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorInteraction : MonoBehaviour
{
    public Animator myAnim;


   private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entre en colision con" + other.gameObject.name);
            //Abrir puerta
            myAnim.Play("OpenTheDoor");
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Me mantengo en colision" + other.gameObject.name);
        }
        
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Sali de colision" + other.gameObject.name);
            //Cerrar puerta
            myAnim.Play("CloseTheDoor");
            
        }
       
    }



}
