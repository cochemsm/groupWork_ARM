using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {
    [SerializeField]
    private int radius = 20;

    [SerializeField]
    private int startEnemyNumber = 6;
    private int currentEnemyNumber;

    private int increase = 0;

    [SerializeField]
    private GameObject ghostPrefab;

    private void Awake() {
        currentEnemyNumber = startEnemyNumber;    
    }

    private void Start() {

    }

    private void Update() {
        if (EnemyNumber() < currentEnemyNumber) {
            Instantiate(ghostPrefab, FindRadius(), Quaternion.identity);
            increase++;
        }
        if (increase >= 10) {
            increase -= 10;
            currentEnemyNumber++;
        }
    }

    private Vector3 FindRadius() {
        switch (Random.Range(0, 8)) { 
            case 0: return GameManager.Instance.player.transform.position + new Vector3(radius, 0, 0);
            case 1: return GameManager.Instance.player.transform.position + new Vector3(-radius, 0, 0);
            case 2: return GameManager.Instance.player.transform.position + new Vector3(0, radius, 0);
            case 3: return GameManager.Instance.player.transform.position + new Vector3(0, -radius, 0);
            case 4: return GameManager.Instance.player.transform.position + new Vector3(radius, radius, 0);
            case 5: return GameManager.Instance.player.transform.position + new Vector3(-radius, radius, 0);
            case 6: return GameManager.Instance.player.transform.position + new Vector3(radius, -radius, 0);
            case 7: return GameManager.Instance.player.transform.position + new Vector3(-radius, -radius, 0);
            default: return new Vector3(0, 0, 0);
        }
    }

    private int EnemyNumber() {
        return GameObject.FindGameObjectsWithTag("enemy").Length;
    }
}