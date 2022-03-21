using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public Transform respawnPoint;

    float Health;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Respawn()
    {
        Health = maxHealth;
        gameObject.transform.position = respawnPoint.position;
    }

    public void DamagePlayer(float Damage, GameObject Player)
    {
        if(Health > 0)
            Health -= Damage;

        if(Health <= 0)
        {
            Respawn();
            Player.GetComponent<ScoreManager>().AddScore();
        }
    }
}
