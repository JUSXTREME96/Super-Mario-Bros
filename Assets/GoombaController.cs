using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour {

	public float speed;
	private bool wallHit;
	private bool playerHit;
	public Transform wallHitBox;
	public float wallHitWidth;
	public float wallHitHeight;
	public Transform playerHitBox;
	public float playerHitWidth;
	public float playerHitHeight;
	public LayerMask isGround;

	private AudioSource source;
	public AudioClip stompClip;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	// Use this for initialization
	void Start () {
		//rb2d = GetComponent<Rigidbody2D>();
	}

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (speed * Time.deltaTime, 0, 0);

		wallHit = Physics2D.OverlapBox (wallHitBox.position, new Vector2 (wallHitWidth, wallHitHeight), 0, isGround);
		if (wallHit == true) {
			speed = speed * -1;
		}
		playerHit = Physics2D.OverlapBox (playerHitBox.position, new Vector2 (playerHitWidth, playerHitHeight), 0, isGround); 
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			float vol = Random.Range(volLowRange, volHighRange);
			source.PlayOneShot(stompClip);
			Debug.Log("I loved living");
			Destroy(gameObject, 0.25f);
			//audio
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube (wallHitBox.position, new Vector3 (wallHitWidth, wallHitHeight, 1));
		Gizmos.color = Color.blue;
		Gizmos.DrawCube (playerHitBox.position, new Vector3 (playerHitWidth, playerHitHeight, 1));
	}
}
