using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    //variables for player game object
    private Rigidbody rb;
    //horizontal movement
    private float movementX;
    private float movementY;
    public float speed = 0;

    //variables for scoring
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent <Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void FixedUpdate(){
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnMove (InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if (count >= 12){
            winTextObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

} 
