using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NinjaStarController : MonoBehaviour
{
    public float rotationSpeed;
    
    public Vector3 direction;
    public float speed =5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SpinForever());
        if(transform.position.x >= 4.5) {
            direction = Vector3.left;
        } if(transform.position.x <= -3) {
            direction = Vector3.right;
        } if(transform.position.y <= -3) {
            direction = Vector3.up;
        } if(transform.position.y >= 4) {
            direction = Vector3.down;
        }
        rb.velocity = direction.normalized * speed;
    }

    IEnumerator SpinForever()
    {
        while (true)
        {
            transform.localEulerAngles += new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
    // Update is called once per frame

}
