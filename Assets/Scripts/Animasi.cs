using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animasi : MonoBehaviour
{
    private float kecepatan_player;
    private float nilai_x;
    private float nilai_z;
    private bool status_ground;

    private Animator anim1;
    private GameObject player;    
    
    // Start is called before the first frame update
    void Start()
    {
        anim1 = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan_player = player.GetComponent<Player_movement>().kecepatan;
        nilai_x = player.GetComponent<Player_movement>().x;
        nilai_z = player.GetComponent<Player_movement>().z;
        status_ground = player.GetComponent<Player_movement>().isGrounded;
        
        anim1.SetFloat("x", nilai_x);
        anim1.SetFloat("z", nilai_z);
        anim1.SetBool("isGrounded", status_ground);
    }
}
