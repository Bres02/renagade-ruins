using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour
{

    public PlayerScriptable playerScript;

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

    [SerializeField] private LayerMask groundMask;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerMovement
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = false;

        mainCamera = Camera.main;

    }
    // Update is called once per frame
    void Update()
    {
        if (!isDodging)
        {
            MyInput();
            SpeedControl();

            rb.drag = groundDrag;

            anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
            anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        }
        Aim();

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;

            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }
    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

    //disable the weapon Collider
    public void EnableWeaponCollider(int isEnabled)
    {
        if (playerScript.leftWeapon != null)
        {
            var col = playerScript.leftWeapon.GetComponent<Collider>();

            if (col != null)
            {
                if (isEnabled == 1)
                {
                    col.enabled = true;
                }
                else
                {
                    col.enabled = false;
                }
            }
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
        this.GetComponent<CapsuleCollider>().enabled = false;
    }
    public void endDodge()
    {
        this.GetComponent<CapsuleCollider>().enabled = enabled;
        this.transform.rotation *= anim.deltaRotation;
        this.transform.position += anim.deltaPosition;
        isDodging = false;
    }



}
