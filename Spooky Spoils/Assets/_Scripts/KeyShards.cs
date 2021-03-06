﻿using UnityEngine;
using System.Collections;

public class KeyShards : MonoBehaviour{
    public GameObject correspondingKey;
    private GazeAwareComponent _gazeAware;
    private MouseAwareComponent _mouseAware;
    private AudioSource audioClip;
    private bool HasGaze
    {
        get { return ((InputManager.tobiiOn && _gazeAware.HasGaze) || (!InputManager.tobiiOn && _mouseAware.HasMouse)); }
    }

    void Awake()
    {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
        _mouseAware = this.GetComponent<MouseAwareComponent>();
        audioClip = this.GetComponentInParent<AudioSource>();
    }

    void Start()
    {
        this.GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        if (this.HasGaze)
        {
            this.GetComponent<Collider2D>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioClip.PlayOneShot(audioClip.clip);
            if (this.correspondingKey.gameObject != null)
                correspondingKey.SetActive(true);
           
            Destroy(this.gameObject);
        }
    }
}
