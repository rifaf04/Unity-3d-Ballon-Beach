using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject sceneManager;
    public float playerSpeed = 1500;
    public float directionalSpeed = 20;
    public AudioClip scoreUp;
    public AudioClip damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER 
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 2.5f), gameObject.transform.position.y, gameObject.transform.position.z), directionalSpeed * Time.deltaTime);
#endif
        GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right * GetComponent<Rigidbody>().velocity.z / 3);
        //MOBILE CONTROLS
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if (Input.touchCount > 0) {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
        }
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "scoreup") {
            GetComponent<AudioSource>().PlayOneShot(scoreUp, 1.0f);
        }
        if (other.gameObject.tag == "triangle") {
            GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
            sceneManager.GetComponent<App_Initialize>().GameOver();
        }
    }
}
