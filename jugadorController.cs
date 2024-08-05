using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugadorController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=5.0f;

    // Update is called once per frame
    void Update()
    {
        float movHorizontal= Input.GetAxis("Horizontal");
        float movVertical=Input.GetAxis("Vertical");

        Vector3 movimiento=new Vector3(movHorizontal,0.0f,movVertical);
        transform.Translate(movimiento*speed*Time.deltaTime);
    }
}
