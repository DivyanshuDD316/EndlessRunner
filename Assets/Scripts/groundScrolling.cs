using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundScrolling : MonoBehaviour
{
    [SerializeField] private float groundLength=10f;
    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos.position.z>groundLength+transform.position.z)
        {
            transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z+groundLength*2);
        }
    }
}
