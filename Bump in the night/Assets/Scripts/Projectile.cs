using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = new Vector3(0,5,0);
    }

    public void Launch(Vector3 targetPosition){
        rb.velocity = targetPosition - transform.position;
    }
}
