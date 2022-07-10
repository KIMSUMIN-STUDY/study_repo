using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody playerRigidbody;
    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.isGameOver == true)
            return;

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float fallSpeed = playerRigidbody.velocity.y;

        Vector3 velocity = new Vector3(inputX, 0, inputZ);

        velocity = velocity * speed;
        velocity.y = fallSpeed;

        playerRigidbody.velocity = velocity;
        //playerRigidbody.AddForce(inputX * speed, 0, inputZ * speed);
    }
}
