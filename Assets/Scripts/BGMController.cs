using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{

    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("bgm");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        AudioSource bgm = GetComponent<AudioSource>();
        if (!bgm.isPlaying)
        {
            bgm.Play();
        }
    }
}
