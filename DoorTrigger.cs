using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject Door;
     private void OnTriggerEnter(Collider other) {         
         if (other.gameObject.layer == 6) {
             Door.GetComponent<Animation>().Play("Door_Open");             
         }         
     }

     private void OnTriggerExit(Collider other) {
         if (other.gameObject.layer == 6) {
             Door.GetComponent<Animation>().Play("Door_Close");             
         }
     }
}
