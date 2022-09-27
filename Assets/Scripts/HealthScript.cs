using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public GameManager Manager;
    public GameObject HealthBarCanvas;
    public scoregame Movement;
    public MeshRenderer MeshRenderer;
    public RectTransform BarTransform;
    public float max_health = 100f;
    public float cur_health;
    public bool alive = true;

    float minDelta = .01f;    //SizeDelta "Off" where bar is empty
    float maxDelta = 1.9f; //SizeDelta "On" where bar is full

    void Start()
    {
        Reset();
    }

    public void TakeDamage(float amount)
    {
        if (!alive) return;

        cur_health -= amount;
        SetHealthBar();

        if (cur_health <= 0)
            Die();
    }

    public void SetHealthBar()
    {
        float barRatio = minDelta + (maxDelta - minDelta) * Mathf.Clamp(cur_health / max_health, 0f, 1f);
        BarTransform.sizeDelta = new Vector2(barRatio, BarTransform.sizeDelta.y);
    }

    public void Reset()
    {
        cur_health = max_health;
        alive = true;

        HealthBarCanvas.SetActive(true);
        SetHealthBar();

        Movement.enabled = true;
        this.gameObject.SetActive(true);
    }

    public void Die()
    {
        cur_health = 0;
        alive = false;

        //Make the player disappear
        this.gameObject.SetActive(false);

        //Disable the health bar
        HealthBarCanvas.SetActive(false);

        //Tell the GameManager we died
        Manager.OnDeath();
    }

}
