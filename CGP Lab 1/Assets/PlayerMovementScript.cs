using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // Controller vars
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public CharacterController controller;
    Vector3 velocity;
    float running;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public GameObject spawner;

    int state;

    public void resetPlayerPos()
    {
        controller.enabled = false;
        transform.position = spawner.transform.position;
        transform.rotation = spawner.transform.rotation;
        controller.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //spawner = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        running = 1;

        if (isGrounded && velocity.y < 0) {
            velocity.y = -10f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButton("Run")) {
            running = 2;
        }
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime * running);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit c)
    {
        if (c.gameObject.tag == "Obstacle"){
            if (state == 3)
            {
                c.gameObject.GetComponent<PushBarBackNForth>().playerHit();
            }
            if (state == 5)
            {
                c.gameObject.GetComponent<Floor5Lift>().playerHit();
            }
            if (state == 6)
            {
                c.gameObject.GetComponent<Floor6Lift>().playerHit();
            }
        }
    }
    public void updateState(int i)
    {
        state = i;
    }
}
