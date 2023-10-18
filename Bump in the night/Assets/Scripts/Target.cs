using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        Destroy(this.gameObject);
        //GetComponent<SpriteRenderer>().color =Color.red;
        //other.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity * -1;
    }

    void OnTriggerExit2D(Collider2D other){

    }

    void OnTriggerStay2D(Collider2D other){
        
    }
}
