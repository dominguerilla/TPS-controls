using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPlatformerCamera : MonoBehaviour
{
    public Transform target;
    
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if(offset == Vector3.zero) {
            offset = target.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target) {
            transform.position = target.position - offset;
            transform.LookAt(target);
        }
    }
}
