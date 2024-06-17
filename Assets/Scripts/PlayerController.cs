using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask stopsMovement;
    public Animator anim;
    public ParticleSystem particleSystemPrefab;
    public AudioSource audioSource;
    public GameOverScript gameOverScript;
    public CarrotSpawningScript carrotSpawningScript;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),  0f, 0f), 0.2f, stopsMovement)) {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, stopsMovement)) {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

            anim.SetBool("moving", false);
        }
        else
        {
            anim.SetBool("moving", true);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Danger"))
        {
            audioSource.Play();
            gameOverScript.Setup(carrotSpawningScript.getScore());
            
            ParticleSystem newParticleSystem = Instantiate(particleSystemPrefab, transform.position, transform.rotation);
            newParticleSystem.Play();
            Destroy(newParticleSystem.gameObject, newParticleSystem.main.duration);
            Destroy(gameObject, 0.1f);
        }
    }
}