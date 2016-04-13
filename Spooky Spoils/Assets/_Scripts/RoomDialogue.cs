﻿using UnityEngine;
using System.Collections;

public class RoomDialogue : MonoBehaviour {
    public TextAsset roomBegin, roomHint;    
    private DialogueManager _dialogueManager;    

    void Awake()
    {
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    void Start()
    {
        if (roomBegin != null)
            _dialogueManager.StartDialogue(roomBegin);   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && roomHint != null)
        {
            _dialogueManager.StartDialogue(roomHint);
        }
    }
}
