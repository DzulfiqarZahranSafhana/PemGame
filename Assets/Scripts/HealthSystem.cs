using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float player_health = 100f;
    public string info;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mushroom")
        {
            player_health -= 5f;
            info = "You eat a poisonous mushroom";
        }

        if (other.tag == "Fire")
        {
            player_health -= 5f;
            info = "You are burned";
        }

            if (other.tag == "Enemy")
        {
            player_health -= 15f;
            info = "You are killed by spider";
        }
    }
}
