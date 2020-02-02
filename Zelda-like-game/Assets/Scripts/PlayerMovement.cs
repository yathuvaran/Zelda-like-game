using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;

    // Start is called before the first frame update
    void Start(){
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    // To move character from other places (on screen buttons)
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            // Get player position and add change (1) multiply it by speed (4)
            // and multiply by how much time has past since previous frame (small amount)
            // Therefore, we move a small amount each frame
           transform.position + change * speed * Time.deltaTime
            );
    }
}
