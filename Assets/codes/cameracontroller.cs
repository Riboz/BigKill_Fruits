using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
   
    private Vector3 offset=new Vector3(0,0,-10f);
    [SerializeField]private float smoothTime=0.25f;
    private Vector3 velocity=Vector3.zero;
    [SerializeField]private Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetposition=target.position+offset;
        transform.position=Vector3.SmoothDamp(transform.position,targetposition,ref velocity,smoothTime);
    }
}
