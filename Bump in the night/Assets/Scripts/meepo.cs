using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class meepo : MonoBehaviour
{

    [SerializeField] int hp=4; //SerializeField allows values to be edited by unity script
    //[SerializeField] float stamina=10.0f;
    //[SerializeField] string meepoName="Meepo";
    //[SerializeField] GameObject stick;
    //[SerializeField] SpriteRenderer stick;
    //[SerializeField] float speed =1;

    void Awake()//called first
    {
        hp=5;
        //Debug.Log("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        //can fill in a UI element based on hp value
        //Debug.Log("Hello! this is meepo!");
        //CopyStickColor();
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Transform>()
        //transform.position += new Vector3(speed*Time.deltaTime,0,0);

        // if(Input.GetKey(KeyCode.D)){
        //     transform.position += new Vector3(speed*Time.deltaTime,0,0);
        // }
        // if(Input.GetKey(KeyCode.A)){
        //     transform.position -= new Vector3(speed*Time.deltaTime,0,0);
        // }
        // if(Input.GetKey(KeyCode.W)){
        //     transform.position += new Vector3(0,speed*Time.deltaTime,0);
        // }
        // if(Input.GetKey(KeyCode.S)){
        //     transform.position -= new Vector3(0,speed*Time.deltaTime,0);
        // }
        //

        if(Input.GetKeyDown(KeyCode.Q)){//returns true on first frame key is pressed
            GetComponent<SpriteRenderer>().color=Color.black;
        }
        if(Input.GetKey(KeyCode.Q)){//returns true while key is pressed
            transform.localScale *= 1 + (.5f * Time.deltaTime);
        }
    }

    //set the stick color to match meepo
    //public void CopyStickColor(){
    //    stick.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
    //}

    public int GetHP(){
        return hp;
    }
}
