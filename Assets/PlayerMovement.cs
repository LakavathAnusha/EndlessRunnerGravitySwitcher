using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    public float speed;
    int score;
    float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(Vector3.up * jumpForce);
            Physics.gravity *= -1;
            
        }
        score=Mathf.FloorToInt(transform.position.x);
        Debug.Log(score);
        if(score>maxDistance)
        {
            speed = speed + 0.2f;
            maxDistance = maxDistance + 100f;
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
    }
    private void OnTriggerEnter(Collider other)
    {
     if(other.gameObject.GetComponent<ObstacleController>()!=null)
        {
            Destroy(this.gameObject);
        }
    }
}
