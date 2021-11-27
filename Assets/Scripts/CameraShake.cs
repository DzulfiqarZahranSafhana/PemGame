using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    private CinemachineFreeLook cinemafreelook;
    //[SerializeField] private float power = 1.5f;
    private float duration = 1f;
    //private float slowDownAmount = 1f;
    [SerializeField] private bool shouldshake = false;
    //public Transform camera;
    Vector3 startPosition;
    float initialDuration;
    
    
    private void Awake()
    {
        Instance = this;
        cinemafreelook = GetComponent<CinemachineFreeLook>();
    }

    public void ShakeCamera(float intensity, float time)
    {
            CinemachineBasicMultiChannelPerlin CinePerlin = cinemafreelook.GetComponent<CinemachineBasicMultiChannelPerlin>();

            CinePerlin.m_AmplitudeGain = intensity;
            duration = time;
    }

    // Start is called before the first frame update
    void Start()
    {
        //camera = Camera.main.transform;
        //startPosition = camera.localPosition;
        //initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldshake)
        {
            if (duration > 0)
            {
                //camera.localPosition = startPosition + Random.insideUnitSphere * power;
                //duration = Time.deltaTime * slowDownAmount;
                ShakeCamera(3, 1);
            duration -= Time.deltaTime;
            if (duration <= 0f)
            {
                    CinemachineBasicMultiChannelPerlin CinePerlin = cinemafreelook.GetComponent<CinemachineBasicMultiChannelPerlin>();

                    CinePerlin.m_AmplitudeGain = 0f;
                }
            }
            /*else
            {
                shouldshake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }*/
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            shouldshake = true;
        }
    }
}
