using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float speed = 2;
    public Vector3 lookPos;
    private Animator anim;

    Transform cam;
    Vector3 camForward;
    Vector3 move;
    Vector3 moveInput;

    float forwardAmount;
    float turnAmount;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        SetupAnimator();

        cam = Camera.main.transform;
    }

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);

        // limiting character movement to visible area
        if (transform.position.x <= 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 23)
        {
            transform.position = new Vector3(23, transform.position.y, transform.position.z);
        }

        if (transform.position.z <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        else if (transform.position.z >= 13)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 13);
        }

    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (cam != null)
        {
            camForward = Vector3.Scale(cam.up, new Vector3(1, 0, 1)).normalized;
            move = vertical * camForward + horizontal * cam.right;
        }
        else
        {
            move = vertical * Vector3.forward + horizontal * Vector3.right;
        }

        if (move.magnitude > 1)
        {
            move.Normalize();
        }

        Move(move);

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rigidBody.AddForce(movement * speed / Time.deltaTime);

    }

    void Move(Vector3 move)
    {
        if (move.magnitude > 1)
        {
            move.Normalize();
        }

        this.moveInput = move;

        ConvertMoveInput();
        UpdateAnimator();
    }

    void ConvertMoveInput()
    {
        Vector3 localMove = transform.InverseTransformDirection(moveInput);
        turnAmount = localMove.x;

        forwardAmount = localMove.z;
    }

    void UpdateAnimator()
    {
        anim.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        anim.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }

    void SetupAnimator()
    {
        anim = GetComponent<Animator>();

        foreach (var childAnimator in GetComponentsInChildren<Animator>())
        {
            if (childAnimator != anim)
            {
                anim.avatar = childAnimator.avatar;
                Destroy(childAnimator);
                break;
            }
        }
    }
}
