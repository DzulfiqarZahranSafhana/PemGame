using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float kecepatan =7f;
    public float x;
    public float z;

    [SerializeField] private float gravitasi = -9.81f;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float groundDistance = -0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float speed_jump = 3f;
    public bool isGrounded;
    Vector3 velocity;
    public float waktugerakHalus = 0.1f;
    public float kecgerakhalus;
    private CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        gravity();
        bergerak();
        lompat();
    }

    private void bergerak()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        Vector3 gerakan = new Vector3(x,0f,z).normalized;
        if (gerakan.magnitude >= 0.1f)
        {
            float arahtujuan = Mathf.Atan2(gerakan.x, gerakan.z)*Mathf.Rad2Deg;
            float arahhalus = Mathf.SmoothDampAngle(transform.eulerAngles.y, arahtujuan, ref kecgerakhalus, waktugerakHalus);
            transform.rotation = Quaternion.Euler(0f, arahhalus, 0f);
            
            controller.Move(gerakan * kecepatan * Time.deltaTime);
        }
        
    }

    private void gravity()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

    }

    private void lompat()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(speed_jump * -2f * gravitasi);
        }
        velocity.y += gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
