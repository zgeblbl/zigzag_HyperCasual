using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torus : MonoBehaviour
{
    public int minScore, maxScore;
    private GameManager gameManager;
    public ParticleSystem collectEffect;
    public AudioSource collectSound;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        transform.Rotate(180f * Time.deltaTime, 0f, 0f);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(Random.Range(minScore, maxScore));
            collectEffect.Play();
            collectSound.Play();
            Destroy(this.gameObject, 0.5f);
        }
    }
}
