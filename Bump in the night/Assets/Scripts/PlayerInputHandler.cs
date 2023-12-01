using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Movement movement;
    PointsHandler pointsHandler;
    //ProjectileThrower projectileThrower;

    void Awake(){
        //movement = GetComponent<Movement>();
        //pointsHandler = GameObject.Find("PointsHandler").GetComponent<PointsHandler>();// slow
        //pointsHandler = GameObject.FindGameObjectWithTag("PointsHandler").GetComponent<PointsHandler>();// good
        //projectileThrower = GetComponent<ProjectileThrower>();
    }

    void Start(){
        pointsHandler = PointsHandler.singleton;//second fastest
    }

    void FixedUpdate(){
        Vector3 vel = Vector3.zero;
        if(Input.GetKey(KeyCode.D)){
            vel.x = 1;
        }
        if(Input.GetKey(KeyCode.A)){
            vel.x = -1;
        }
        if(Input.GetKey(KeyCode.W)){
            vel.y = 1;
        }
        if(Input.GetKey(KeyCode.S)){
            vel.y = -1;
        }
        movement.MoveRB(vel);
        //pointsHandler.AddDistance(vel.magnitude * Time.deltaTime);
        }

    // Update is called once per frame
    void Update()
    {
        // Vector3 vel = Vector3.zero;
        // if(Input.GetKeyDown(KeyCode.D)){
        //     vel.x = 1;
        // }
        // if(Input.GetKeyDown(KeyCode.A)){
        //     vel.x = -1;
        // }if(Input.GetKeyDown(KeyCode.W)){
        //     vel.y = 1;
        // }
        // if(Input.GetKeyDown(KeyCode.S)){
        //     vel.y = -1;
        // }
        // movement.MoveTransform(vel);
        // //movement.MoveRB(vel);
        // pointsHandler.AddDistance(vel.magnitude * Time.deltaTime);

        //projectiles
        // if(Input.GetKeyDown(KeyCode.E)){
        //     projectileThrower.Throw(Camera.main.ScreenToWorldPoint(Input.mousePosition));//shoot towards mouse pointer
        // }
    }
}
