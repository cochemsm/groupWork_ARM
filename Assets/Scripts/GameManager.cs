using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    public static GameManager Instance => instance;

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public GameObject[] enemys;

    [HideInInspector]
    public GameObject worldUI;

    private GameObject screenUI;

    [SerializeField]
    private GameObject popUpTextPrefab;

    private int score = 0;

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
        if (GameObject.FindGameObjectWithTag("screenUI")) {
            screenUI = GameObject.FindGameObjectWithTag("screenUI");
            screenUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "Score: " + score.ToString();
        }
    }

    private void Update() {
        if (GameObject.FindGameObjectsWithTag("enemy") != null) {
            enemys = GameObject.FindGameObjectsWithTag("enemy");
        }
    }

    private void SpawnPotion(GameObject deadEnemy, int scoreAmount) {
        if (Random.Range(0, 6) == 0) {
            Type = (Potions) Random.Range(0, Potions.GetNames(typeof(Potions)).Length);
            Instantiate(FindPotionType(Type), deadEnemy.transform.position, Quaternion.identity);
        }
        AddScore(scoreAmount);
    }

    private GameObject FindPotionType(Potions type) {
        switch (type) {
            case Potions.Healing: return healingPotionPrefab;
            default: return null;
        }
    }

    public void SpawnPopUpText(string text, Color textColor) {
        GameObject temp = Instantiate(popUpTextPrefab, worldUI.transform);
        temp.transform.position += new Vector3(0, 0.2f, 0);
        temp.GetComponent<PopUpText>().SetTextAndColor(text, textColor);
    }

    public void GameOver() {
        screenUI.transform.GetChild(0).gameObject.SetActive(true);
    }

    public IEnumerator Wait(int seconds) {
        yield return new WaitForSeconds(seconds);
    }

    public void AddScore(int amount) {
        score += amount;
        screenUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "Score: " + score.ToString();
    }
}
