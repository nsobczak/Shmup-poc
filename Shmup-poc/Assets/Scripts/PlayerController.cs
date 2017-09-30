﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 2f;
    public GameObject PrefabShoot;

    private float m_shootTimer = 0.1f;

    // Update is called once per frame
    void Update()
    {
        //move
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position); //stay in screen
        if (Input.GetKey(KeyCode.UpArrow) && screenPos.y < Screen.height)
        {
            transform.position += new Vector3(0, 3, 0) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) && screenPos.x < Screen.width)
        {
            transform.position += new Vector3(3, 0, 0) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && screenPos.x > 0)
        {
            transform.position += new Vector3(-3, 0, 0) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) && screenPos.y > 0)
        {
            transform.position += new Vector3(0, -3, 0) * Time.deltaTime * Speed;
        }

        //shoot
        m_shootTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (m_shootTimer <= 0)
            {
                GameObject shoot;

                shoot = GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0),
                    Quaternion.identity);
                shoot.GetComponent<ShootComponent>().Direction = new Vector3(-1, 1).normalized;

                shoot = GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0),
                    Quaternion.identity);
                shoot.GetComponent<ShootComponent>().Direction = new Vector3(1, 1).normalized;

                shoot = GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0),
                    Quaternion.identity);
                shoot.GetComponent<ShootComponent>().Direction = new Vector3(0, 1);
                shoot = GameObject.Instantiate(PrefabShoot, transform.position - new Vector3(0.2f, 0, 0),
                    Quaternion.identity);
                shoot.GetComponent<ShootComponent>().Direction = new Vector3(0, 1);

                m_shootTimer = 0.1f; //pour tirer toutes les 100ms
            }
        }
    }
}