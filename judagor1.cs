using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador1 : MonoBehaviour
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
            // Movimiento solo con las teclas de flechas ← ↑ ↓ →
            float movHorizontal = 0.0f;
            float movVertical = 0.0f;

            // Ajustar movimiento horizontal con las flechas ← y →
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movHorizontal = -1.0f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                movHorizontal = 1.0f;
            }

            // Ajustar movimiento vertical con las flechas ↑ y ↓
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movVertical = 1.0f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                movVertical = -1.0f;
            }

            Vector3 movimiento = new Vector3(movHorizontal, 0.0f, movVertical) * moveSpeed * Time.deltaTime;
            Vector3 newPos = rig.position + rig.transform.TransformDirection(movimiento);

            rig.MovePosition(newPos);
        }
    }

    void Jump()
    {
        // Salto con la tecla Espacio
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
