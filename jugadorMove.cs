using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugadorMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float forceJump = 5.0f;

    private Rigidbody rig;
    private bool isGrounded;
    private bool isAtLimit;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (isGrounded && !isAtLimit)
        {
            float movHorizontal = Input.GetAxis("Horizontal");
            float movVertical = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(movHorizontal, 0.0f, movVertical) * moveSpeed * Time.deltaTime;
            Vector3 newPos = rig.position + rig.transform.TransformDirection(movimiento);

            rig.MovePosition(newPos);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rig.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Limite"))
        {
            isAtLimit = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("Limite"))
        {
            isAtLimit = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión con: " + collision.gameObject.name);
    }
}
