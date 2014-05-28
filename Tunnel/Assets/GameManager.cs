﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager _instance;
	
	public static GameManager instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<GameManager>();
			}
			return _instance;
		}
	}

	public GameObject treasure;
	public GameObject gnome;
	public GameObject startingPoint;
	public Rope rope;
	public Fade fade;
	public GameObject mainMenu;

	bool treasureCollected = false;

	void Start() {
		Reset ();
	}

	void TreasureCollected() {
		treasureCollected = true;
		treasure.SetActive(false);
	}

	void Reset() {
		treasureCollected = false;
		treasure.SetActive(true);

		gnome.transform.position = startingPoint.transform.position;

		rope.Reset();

		fade.gameObject.SetActive(true);

		fade.SetAlpha(1.0f);
		fade.FadeTo(0.0f, 0.5f);

		mainMenu.SetActive(false);

		Time.timeScale = 1.0f;
	}

	void TrapTouched() {

		Reset ();
	}

	void ExitReached() {
		if (treasureCollected == true) {
			Reset();
		}
	}

	void ShowMenu() {
		Time.timeScale = 0.0f;
		mainMenu.SetActive(true);
	}

}