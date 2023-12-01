using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void Death(GameObject Enemy);
    public static event Death OnDeath;

    public void StartEvent()
    {
        OnDeath.Invoke(this.gameObject);
    }
}
