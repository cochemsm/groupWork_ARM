using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void Death(GameObject Enemy);
    public Death OnDeath;
}
