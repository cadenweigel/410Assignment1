using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour{

    /*
    Sources:
    https://u3ds.blogspot.com/2021/10/double-jump-rigidbody-unity-game-engine.html 
    https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
    https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html
    decided to put jump in a separate file
    since I was having trouble figuring out how to combine horizontal movement with jumping
    */

    public float force = 3;
    public float ground = 0.5f;
    private Rigidbody rb;
    bool canDoubleJump;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent <Rigidbody>();
    }

    bool onGround(){
        //if the velocity of the player gameobject is 0, it isn't travelling upwards
        //which means it's on the ground
        return GetComponent<Rigidbody>().velocity.y == 0;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown("space")){
            if(onGround()){
                rb.velocity = Vector3.up * force;
                canDoubleJump = true;
            }
            else if(canDoubleJump){
                rb.velocity = Vector3.up * force;
                canDoubleJump = false;
            }
        }
    }
}
