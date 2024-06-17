using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CarrotSpawningScript : MonoBehaviour
{
    public ParticleSystem particleSystemPrefab;
    public GameObject player; 
    public int score = 0; 
    public TextMeshProUGUI scoreText;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        score = 0;
        MoveToRandom();
    }

    void Update() {
        if (player != null) {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 0.1f && Mathf.Abs(transform.position.y - player.transform.position.y) <= 0.1f) {
                spawnParticles();
                audioSource.Play();
                MoveToRandom();
                score += 1; 
                UpdateScore(score);
            }   
        }   
    }

    void MoveToRandom()
    {

        int randomX = Random.Range(-2, 3);
        int randomY = Random.Range(-2, 3);


        float centerX = randomX + 0.5f;
        float centerY = randomY + 0.5f;

        transform.position = new Vector3(centerX, centerY, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
            {
                spawnParticles();
                audioSource.Play();
                MoveToRandom();
                score += 1; 
                UpdateScore(score);
            }
    }

    public int getScore() {
        return score;
    }
    private void spawnParticles() {
        ParticleSystem newParticleSystem = Instantiate(particleSystemPrefab, transform.position, transform.rotation);
        newParticleSystem.Play();
        Destroy(newParticleSystem.gameObject, newParticleSystem.main.duration);
    }
    public void UpdateScore(int newScore) {
        score = newScore;
        if (score == 0) {
            scoreText.text = "0 carrots :(";
        } else if (score == 1) {
            scoreText.text = "1 carrot :(";
        } else {
            scoreText.text = score.ToString() + " Carrots :)";
        }
    }

}