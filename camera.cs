using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;

    public Vector3 offset=new Vector3(0,2,-10);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=player.position+offset;

        
    }
}
