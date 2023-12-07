using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public delegate void Death(GameObject Enemy);
    public static event Death OnDeath;

    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private GameObject Bar;

    private void Awake() {
        Bar = transform.GetChild(0).GetChild(0).gameObject;
        healthBar = Bar.gameObject.transform.GetChild(1).GetComponent<Image>();
    }

    public void StartEvent()
    {
        OnDeath.Invoke(this.gameObject);
    }

    public void UpdateHealthBar(int hp, int maxHp) {
        if (!healthBar.gameObject.active) {
            healthBar.gameObject.SetActive(true);
            Bar.gameObject.SetActive(true);
            
        }
        healthBar.fillAmount = (float) hp / maxHp;
    }
}
