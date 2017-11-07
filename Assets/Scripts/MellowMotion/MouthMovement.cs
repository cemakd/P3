﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthMovement : MonoBehaviour {

    public InputJump inputJump;
    private MellowCrushed mellowCrushed;

    public Sprite defaultSprite;
    public Sprite smileSprite;
    public float smileDuration = 0.5f;

//    private InputJump ij;
    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        inputJump.DidJump += Smile;
		mellowCrushed = GetComponentInParent<MellowCrushed> ();
        mellowCrushed.Remove += DisableMouth;
        mellowCrushed.Respawn += EnableMouth;
    }

    void Smile() {
        sr.sprite = smileSprite;
        Invoke("Default", smileDuration);
    }

    void Default() {
        sr.sprite = defaultSprite;
    }

    private void DisableMouth() {
        gameObject.SetActive(false);
    }

    private void EnableMouth()
    {
        gameObject.SetActive(true);
    }
}
