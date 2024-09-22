using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
public GameObject Meteor_miniPrefab;
public float bisectSpreadAngle = 45f;
    
    public float speed = 10f;
    public float maxlifetime = 3f;
    public static Boolean isDead = false;

    public Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxlifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision){

        if(collision.gameObject.tag == "Enemy"){
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SplitMeteorite(collision);
            isDead = true;
        }

        if(collision.gameObject.tag == "Enemy_mini"){
            IncreaseHalfScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void IncreaseScore(){
        Player.SCORE = Player.SCORE + 2;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
    }
    private void IncreaseHalfScore(){
        Player.SCORE = Player.SCORE + 1;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
    }

    private void UpdateScoreText(){
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
    }
    private void SplitMeteorite(Collision collision)
    {
        Vector3 bulletDirection = collision.relativeVelocity.normalized;
        
        Vector3 direction1 = Quaternion.Euler(0, -bisectSpreadAngle / 2, 0) * bulletDirection;
        Vector3 direction2 = Quaternion.Euler(0, bisectSpreadAngle / 2, 0) * bulletDirection;

        GameObject fragment1 = Instantiate(Meteor_miniPrefab, transform.position, Quaternion.identity);
        GameObject fragment2 = Instantiate(Meteor_miniPrefab, transform.position, Quaternion.identity);

        Rigidbody rb1 = fragment1.GetComponent<Rigidbody>();
        Rigidbody rb2 = fragment2.GetComponent<Rigidbody>();

        rb1.AddForce(direction1 * 0.01f, ForceMode.Impulse);
        rb2.AddForce(direction2 * 0.01f, ForceMode.Impulse);
    }
}
