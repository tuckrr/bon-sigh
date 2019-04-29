using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour
{

    public float magnitude = 0.4f;
    public bool autoshake = false;
    public AudioClip scream1;
    public AudioClip scream2;
    public AudioClip bark1;
    public AudioClip bark2;
    public AudioClip bark3;

    private float timeLeft = 0f;
    private Vector2 homePosition;
    private bool shaking = false;
    private AudioSource aud;


    void Awake()
    {
        aud = GetComponent<AudioSource>();
        homePosition = transform.localPosition;
    }

    void FixedUpdate()
    {
        if (shaking)
        {
            if (timeLeft > 0)
            {
                transform.localPosition = (homePosition + Random.insideUnitCircle * magnitude);
                transform.localPosition += Vector3.back * 10;

                timeLeft -= Time.deltaTime;
            }
            else
            {
                transform.localPosition = homePosition;
                transform.localPosition += Vector3.back * 10;
                shaking = false;
            }
        }
        else
        {
           if (autoshake && Random.Range(0, 120) < 1)
           {
                Shake(Random.Range(0.2f, 0.6f));
           }
        }
        
    }

    public void Shake(float time)
    {
        float pick = Random.Range(0, 5);
        if (pick < 1)
        {
            aud.clip = scream1;
        } 
        else if (pick < 2)
        {
            aud.clip = scream2;
        } 
        else if (pick < 3)
        {
            aud.clip = bark1;
        }
        else if (pick < 4) 
        {
            aud.clip = bark2;
        }
        else
        {
            aud.clip = bark3;
        }
        aud.Play();
        timeLeft = time;
        shaking = true;
    }
}
