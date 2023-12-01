using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    public static GameManager Instance => instance;

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public GameObject[] enemys;

    [HideInInspector]
    public GameObject worldUI;

    [SerializeField]
    private GameObject popUpTextPrefab;

    public enum Potions { Healing }
    public Potions Type { get; private set; }

    [SerializeField]
    private GameObject healingPotionPrefab;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable() {
        Enemy.OnDeath += SpawnPotion;
    }

    private void OnDisable() {
        Enemy.OnDeath -= SpawnPotion;
    }

    private void Start() {
        if (GameObject.FindGameObjectWithTag("player")) {
            player = GameObject.FindGameObjectWithTag("player");
        }
        if (GameObject.FindGameObjectWithTag("worldUI")) {
            worldUI = GameObject.FindGameObjectWithTag("worldUI");
        }
    }

    private void Update() {
        if (GameObject.FindGameObjectsWithTag("enemy") != null) {
            enemys = GameObject.FindGameObjectsWithTag("enemy");
        }
    }

    private void SpawnPotion(GameObject deadEnemy) {
        if (Random.Range(0, 6) == 6) {
            Type = (Potions) Random.Range(0, Potions.GetNames(typeof(Potions)).Length);
            Instantiate(FindPotionType(Type), deadEnemy.transform.position, Quaternion.identity);
        }
    }

    private GameObject FindPotionType(Potions type) {
        switch (type) {
            case Potions.Healing: return healingPotionPrefab;
            default: return null;
        }
    }

    public void SpawnPopUpText(string text, Color textColor) {
        GameObject temp = Instantiate(popUpTextPrefab, worldUI.transform);
        temp.GetComponent<PopUpText>().SetTextAndColor(text, textColor);
    }
}
