using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRb;
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
 
    void Start(){
        ballRb=GetComponent<Rigidbody2D>();  
        Launch();      
    }

    private void Launch(){
        float xVelocity = Random.Range(0,2)==0?1:-1;
        float yVelocity = Random.Range(0,2)==0?1:-1;
        ballRb.velocity = new Vector2(xVelocity,yVelocity)*initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("paddle")){
            ballRb.velocity*=velocityMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("goal1")){
            GameManager.Instance.Paddel2Scored();
            GameManager.Instance.Restart();
            Launch();
        }else{
            GameManager.Instance.Paddel1Scored();
            GameManager.Instance.Restart();
            Launch();
        }
    }
}
