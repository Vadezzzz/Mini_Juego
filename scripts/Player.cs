using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public GameObject gun, bulletPrefab;

    public static int SCORE = 0;

    public float thrustForce = 100f;
    public float rotationSpeed = 120f;

    private Rigidbody _rigid;

    private float xMax = 10;
    private float yMax = 5;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = transform.position;

        if (posicion.x > xMax+1) {
            posicion.x = -xMax;
        } else if (posicion.x < -xMax-1) {
            posicion.x = xMax;
        } 
        else if(posicion.y > yMax+1){
            posicion.y = -yMax;
        }
        else if(posicion.y < -yMax-1){
            posicion.y = yMax;
        }

        transform.position = posicion;

        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);

        transform.Rotate(Vector3.forward, -rotation*rotationSpeed);

        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

            Bullet balaScript = bullet.GetComponent<Bullet>();

            balaScript.targetVector = transform.right;
        }
    }

   /* private void OnCollisionEnter(Collision collision){

        if(collision.gameObject.tag == "Enemy"){
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else{
            Debug.Log("He colisionado con algo...");
        }
    }*/
    private void OnTriggerEnter(Collider collision){

        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy_mini"){
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else{
            Debug.Log("He colisionado con algo...");
        }
    }
}
