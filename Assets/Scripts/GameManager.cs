using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    public static GameManager Instance => instance;

    public GameObject player;
    public GameObject[] enemys;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        if (GameObject.FindGameObjectWithTag("player")) {
            player = GameObject.FindGameObjectWithTag("player");
        }
    }

    private void Update() {
        if (GameObject.FindGameObjectsWithTag("enemy") != null) {
            enemys = GameObject.FindGameObjectsWithTag("enemy");
        }
    }
}
