﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Sun : MonoBehaviour {

    public AudioClip sound;
    public Vector3 disappearPos;
    public int value = 25;
    public float actionTime = 0.5f;
    public float disappearTime;

    private GameModel model;
    private Vector3 speed;
    private Vector3 scaleSpeed;
	void Awake () {
        model = GameModel.GetInstance();
        scaleSpeed = new Vector3(0.9f, 0.9f, 0.9f) / actionTime;

        GetComponent<FadeOut>().Begin();
        Destroy(gameObject, disappearTime);

        enabled = false;
	}

    void Update() {
        transform.Translate(speed * Time.deltaTime);
        transform.localScale = transform.localScale - scaleSpeed * Time.deltaTime;
    }

    void OnMouseDown() {
        model.sun += value;
        MoveBy move = GetComponent<MoveBy>();
        if (move) move.enabled = false;
        enabled = true;

        speed = (disappearPos - transform.position) / actionTime;
        AudioManager.GetInstance().PlaySound(sound);
        Destroy(gameObject, actionTime);
    }

}