using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    public Transform orientation;

    float hInput;
    float vInput;

    Vector3 moveDir;

    Rigidbody rb;

    public Animator anim;

    public bool isDodging = false;
    public bool canFire = true;

    private float cooldown;

    [SerializeField] private GameObject bullet;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isDodging)
        {
            MyInput();
            SpeedControl();

            rb.drag = groundDrag;

            anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
            anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        }
        

    }

    private void FixedUpdate()
    {
        MovePlayer();

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            canFire = true;
        }
    }

    // Records movement and attack input from player
    private void MyInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        
        
         // Pressed right mouse button -> sword attack
         // TODO: Make an isAttacking bool to prevent attack spam clicking
         if (Input.GetMouseButtonDown(1))
         {
            anim.SetTrigger("SwordAttack");
         }
          
         if (Input.GetKeyDown(KeyCode.Space))
         {
            anim.SetTrigger("DodgeRoll");
         }

         if (Input.GetMouseButtonDown(0))
        {
            fireBullet();
        }

    }

    private void MovePlayer()
    {
        // Here we calculate the movement direction for the player
        moveDir = orientation.forward * vInput + orientation.right * hInput;

        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Limit to velocity
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void startDodge()
    {
        isDodging = true;
    }
    public void endDodge()
    {
        this.transform.rotation *= anim.deltaRotation;
        this.transform.position += anim.deltaPosition;
        isDodging = false;
    }

    private void fireBullet()
    {
        if (!isDodging && canFire)
        {
            canFire = false;

            cooldown = 1.0f;

            GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
            newBullet.GetComponent<Bullet>().setValues(this.gameObject.GetComponent<AttributeManager>().attack);
        }
    }

}
