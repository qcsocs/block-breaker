using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    private Level_Manager level_manager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        level_manager = GameObject.FindObjectOfType<Level_Manager>();
        print("Trigger");
        level_manager.LoadLevel("Lose");
    }
}
