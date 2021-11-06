using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Image currentEnergy;
    public Text time;
    private GameObject Player;

    private float energy = 200;
    private float maxEnergy = 200;
    private float kecepatan;
    private float kecepatanLari;
    private float input_x;
    private float input_z; 
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        kecepatanLari = Player.GetComponent<Player_movement>().kecepatan;
    }

    // Update is called once per frame
    void Update()
    {
        kecepatanLari = Player.GetComponent<Player_movement>().kecepatan;
        input_x = Player.GetComponent<Player_movement>().x;
        input_z = Player.GetComponent<Player_movement>().z;
        EnergyDrain();
        UpdateEnergy();
        UpdateTime();
    }

    private void EnergyDrain()
    {
        if(input_x > 0 || input_z > 0)
            {
                energy -=10 * Time.deltaTime;
            }
        else
        {
            if(energy < maxEnergy)
            { energy += 15 * Time.deltaTime; 
            }
         }     
    }

    private void UpdateEnergy()
    {
        float ratio = energy / maxEnergy;
        currentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void UpdateTime()
    {
        int hours = EnviroSky.instance.GameTime.Hours;
        int minutes = EnviroSky.instance.GameTime.Minutes;
        string gameHours;
        string gameMinutes;

        if (hours >= 0 && hours < 10) 
        {
            gameHours = "0" + hours.ToString();
        }
        else
        {
            gameHours = hours.ToString();
        }

        if (minutes >= 0 && minutes < 10)
        {
            gameMinutes = "0" + minutes.ToString();
        }
        else
        {
            gameMinutes = minutes.ToString();
        }

        time.text = gameHours.ToString() + " : " + gameMinutes.ToString();
    }
}
