using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    new AudioSource audio;
    Collider2D col;
    SpriteRenderer sprite;

    void Start(){
        audio = GetComponent<AudioSource>();
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Collect(){
        col.enabled = false;
        sprite.enabled = false;
        audio.Play();
        Destroy(gameObject, audio.clip.length);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Collect();
        }
    }
}
