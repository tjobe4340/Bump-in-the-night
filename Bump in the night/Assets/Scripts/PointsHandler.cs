using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{
    [SerializeField] float distanceTraveled = 0f;
    public static PointsHandler singleton;//only allows one of object

    void Awake(){
        if(singleton == null){
            singleton = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void AddDistance(float d){
        distanceTraveled += d;
    }
}
