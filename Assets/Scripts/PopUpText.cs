using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PopUpText : MonoBehaviour {
    private TMP_Text text;
    private Rigidbody2D rigidbody2d;

    [SerializeField]
    private string popUpText = null;
    [SerializeField]
    private Color popUpTextColor = Color.white;

    private void Awake() {
        text = GetComponent<TMP_Text>();
        text.text = popUpText;
        text.color = popUpTextColor;
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = Vector2.up * Time.deltaTime * 10;
        rigidbody2d.gravityScale = 0;
        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation() {
        yield return new WaitForSeconds(1);
        text.alpha = 0.75f;
        yield return new WaitForSeconds(1);
        text.alpha = 0.5f;
        yield return new WaitForSeconds(1);
        text.alpha = 0.25f;
        Destroy(gameObject);
    }

    public void SetTextAndColor(string newText, Color newColor) {
        text.text = newText;
        text.color = newColor;
    }
}