using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public delegate void Death(GameObject Enemy);
    public static event Death OnDeath;

    private Image healthBar;

    private void Awake() {
        healthBar = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>();
    }

    public void StartEvent()
    {
        OnDeath.Invoke(this.gameObject);
    }

    public void UpdateHealthBar(int hp, int maxHp) {
        if (!healthBar.gameObject.active) {
            healthBar.gameObject.SetActive(true);
        }
        healthBar.fillAmount = hp / maxHp;
    }
}
