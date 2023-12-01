using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour {
    [SerializeField]
    private int healingAmount;

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player")) {
            print("lag?????");
            collision.gameObject.GetComponent<Player>().Heal(healingAmount);
            GameManager.Instance.SpawnPopUpText("+2 Healing", Color.red);
            Destroy(gameObject);
        }
    }
}
