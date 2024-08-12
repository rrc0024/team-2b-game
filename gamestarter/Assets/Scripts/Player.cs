using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    //private Animator anim;
    [SerializeField] private float speed;
    private bool grounded;
    private float horizontalInput;
    public float rampPower = 25f;
    private bool ramp;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        speed = 10;
        grounded = false;
        ramp=false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);
        if(!ramp){body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);}
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            body.velocity = new Vector2(body.velocity.x, 10);
            grounded = false;
        }
        if (speed > 24.8f){
            speed = 24.8f;
        }
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            speed += 0.2f;
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            speed += 0.2f;
        }
        else if (horizontalInput == 0){
            speed = 10;
        }

        //anim.SetBool("Walking", horizontalInput != 0);
        //anim.SetBool("Grounded", grounded);

        //if (transform.position.y < -10) {
            //Manager.instance.Restart();
        //}
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Flag") {
          //  Manager.instance.Win();
       // }
        if(collision.gameObject.tag == "Ramp"){
            //print("Ramp Touched");
            //body.velocity = new Vector2(25, 25);
            //body.AddForce(new Vector2(Mathf.Cos(collision.gameObject.transform.rotation.z) * rampPower, Mathf.Sin(collision.gameObject.transform.rotation.z) * rampPower), ForceMode2D.Impulse);
            ramp=true;
            body.AddForce(new Vector2(20,20), ForceMode2D.Impulse);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
         if(collision.gameObject.tag == "Ramp"){
            ramp=false;
            
        }
            

    }
}
