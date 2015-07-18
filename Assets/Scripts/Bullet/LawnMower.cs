﻿using UnityEngine;
using System.Collections;

public class LawnMower : MonoBehaviour {

    public AudioClip sound;
    public int row;
    public float speed;

    private SearchZombie search;
    private bool startUp = false;
    private float range = 0.2f;

	void Awake () {
        search = GetComponent<SearchZombie>();
	}
	
	void Update () {
        if (startUp) {
            transform.Translate(Time.deltaTime * speed, 0, 0);

            object[] zombies = search.SearchZombiesInRange(row, 0, range);
            foreach (GameObject zombie in zombies) {
                zombie.GetComponent<ZombieHealthy>().Damage(10000);
            }

            if (transform.position.x > (StageMap.GRID_RIGHT + 0.4f)) {
                Destroy(gameObject);
            }
        } else {
            if (search.IsZombieInRange(row, 0, range)) {
                startUp = true;
                AudioManager.GetInstance().PlaySound(sound);
            }
        }
	}
}
