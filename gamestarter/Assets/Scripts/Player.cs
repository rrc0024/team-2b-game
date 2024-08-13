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
    public ParticleSystem particles;
    public GameObject starterBox;
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
            transform.localScale = new Vector3(2, 2, 1);
            speed += 0.2f;
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
            speed += 0.2f;
        }
        else if (horizontalInput == 0){
            speed = 10;
        }

        //anim.SetBool("Walking", horizontalInput != 0);
        //anim.SetBool("Grounded", grounded);

        if (transform.position.y < -10) {
            Manager.instance.Restart();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
            ramp = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flag") {
            Manager.instance.Win();
        }
        if(collision.gameObject.tag == "Ramp"){
            ramp=true;
            Ramp rampObj = collision.gameObject.GetComponent<Ramp>();
            //body.AddForce(new Vector2(rampObj.rampPower * transform.localScale.x,rampObj.rampPower), ForceMode2D.Impulse);
            //print(Mathf.Sin((collision.gameObject.transform.rotation.z + 90f) * Mathf.PI / 180f) * rampObj.rampPower);
            //print((collision.gameObject.transform.eulerAngles.z) - 90f);
            body.AddForce(new Vector2(rampObj.rampPower * Mathf.Cos((collision.gameObject.transform.eulerAngles.z) - 90f), rampObj.rampPower * Mathf.Sin((collision.gameObject.transform.eulerAngles.z) - 90f)), ForceMode2D.Impulse);
            //body.AddForce(new Vector2(20,20), ForceMode2D.Impulse);
        }
        if(collision.gameObject.tag == "Passenger"){
            Destroy(collision.gameObject);
            Instantiate(particles, transform.position, particles.transform.rotation);
            starterBox.SetActive(false);
        }
    }
}
