﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlock : Block {

	public AudioClip coinSound;
	public GameObject item;

	bool active;

	void Start () {
		base.Start ();
		active = true;
	}

	void SpawnItem() {
		Instantiate (item, transform.position, Quaternion.identity);
	}

	public override void Hit() {
		if (active) {
			base.Hit ();
			audioSource.clip = coinSound;
			audioSource.Play ();
			active = false;
			SpawnItem ();
		} else {
			audioSource.clip = bump;
			audioSource.Play ();
		}
	}
}