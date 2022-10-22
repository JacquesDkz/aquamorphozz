using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform transformG;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transformG.position.x + posOffset.x, transform.position.y, transformG.position.z + posOffset.z), ref velocity, timeOffset);
    }
}
