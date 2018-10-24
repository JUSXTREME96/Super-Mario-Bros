using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlockController : MonoBehaviour {

	public bool coinHit;
	public Transform coinHitBox;
	public float coinHitWidth;
	public float coinHitHeight;
	public LayerMask isGround;
	public int speed;
	private AudioSource source;
	public AudioClip jumpClip;
	public AudioClip coinClip;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	// Use this for initialization
	void Start () {
		
	}

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		coinHit = Physics2D.OverlapBox (coinHitBox.position, new Vector2 (coinHitWidth, coinHitHeight), 0, isGround);
		if (coinHit == true) {
			speed = speed * 0;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			Debug.Log("New Coin");
			Destroy(gameObject);
			float vol = Random.Range(volLowRange, volHighRange);
			source.PlayOneShot(coinClip);
			//audio
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube (coinHitBox.position, new Vector3 (coinHitWidth, coinHitHeight, 1));
	}
}
