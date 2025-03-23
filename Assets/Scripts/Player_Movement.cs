using System.Collections;
using System.Collections.Generic;
using KevinIglesias;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed=10f;
    [SerializeField] private float jumpForce=7f;
    public Transform cam;
    private Rigidbody rb;
    private bool jump=true;
    private Animator anim;
    private Player_Movement playerScript;
    public spawnObstacle gameController;
    public scoreScript score;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        anim=GetComponentInChildren<Animator>();
        playerScript=GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos=cam.transform.position;
        camPos.z=transform.position.z-6;
        cam.transform.position=camPos;

        Vector3 playerPos=transform.position;
        playerPos.x=Mathf.Clamp(playerPos.x,-4.5f,4.5f);
        transform.position=playerPos;
        float input_H=Input.GetAxis("Horizontal");
        transform.position+=new Vector3(input_H*10f*Time.deltaTime,0,0);
        Jump();
        anim.SetBool("jump",!jump);
        
    }
    void FixedUpdate()
    {
        rb.AddForce(0,0,speed*Time.deltaTime);
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&jump)
        {
            rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            jump=false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            jump=true;
        }
        if(other.gameObject.CompareTag("obstacle"))
        {
            playerScript.enabled=false;
            gameController.gameOver.SetActive(true);
            gameController.scoreText.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("collectables"))
        {
            Destroy(other.gameObject);
            score.AddScore(1);
        }
    }
}
