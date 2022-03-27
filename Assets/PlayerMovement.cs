using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    public float speed;
    int score;
    float maxDistance;
    public Text scoreText;
    public Text gameOver;
    public bool isGameOver;
    public Button playAgain;
    public Text taptoPlay;
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
        scoreText.text = "score:"+score;
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
            gameOver.GetComponent<Text>().enabled = true;
            isGameOver = true;
            playAgain.GetComponent<Image>().enabled = true;
            // playAgain.GetComponent<Text>().enabled = true;

            playAgain.GetComponent<Button>().enabled = true;
            taptoPlay.GetComponent<Text>().enabled = true;
            isGameOver = true;
        }
    }
}
