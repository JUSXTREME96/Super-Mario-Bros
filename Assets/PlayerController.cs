using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private AudioSource source;
	public AudioClip jumpClip;
	public AudioClip coinClip;
	private Rigidbody2D rb2d;
	private bool facingRight = true;
	public int coins; 
	public float speed;
	public float jumpForce;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;
	//ground check
	private bool isOnGround;
	public Transform groundcheck;
	public float checkRadius;
	public LayerMask allGround;
	public Text coinText;

	//private float jumpTimeCounter;
	//public float jumpTime;
	//private bool isJumping;

	//audio

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		coins = 0;
		SetCoinText ();
	}

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
		
	// Update is called once per frame
	private void Update () {
		if (Input.GetKey("escape"))
			Application.Quit();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, 0);

		//rb2d.AddForce(movement * speed);
		rb2d.velocity = new Vector2 (moveHorizontal * speed, rb2d.velocity.y);
		isOnGround = Physics2D.OverlapCircle (groundcheck.position, checkRadius, allGround);
		Debug.Log (isOnGround);

		if (facingRight == false && moveHorizontal > 0) {
			Flip ();
		} else if (facingRight == true && moveHorizontal < 0) {
			Flip ();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Coins")) {
			coins = coins + 1;
			other.gameObject.SetActive (false);
	
			SetCoinText ();
			source.PlayOneShot (coinClip);
		} 
		/*else if (other.gameObject.CompareTag ("CoinBlock")) {
			other.gameObject.SetActive(false);
			coins = coins + 1;
			SetCoinText ();
			source.PlayOneShot (coinClip);*/
		
	}

void Flip()
	{
		facingRight = !facingRight;
		Vector2 Scalar = transform.localScale;
		Scalar.x = Scalar.x * -1;
		transform.localScale = Scalar;
	}

	void SetCoinText ()
	{
		coinText.text = "O x " + coins.ToString ();
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.collider.tag == "Ground" && isOnGround)
		{
			if (Input.GetKey (KeyCode.UpArrow)) 
		    {
				//rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
				rb2d.velocity = Vector2.up * jumpForce;
				float vol = Random.Range(volLowRange, volHighRange);
				source.PlayOneShot(jumpClip);
			} 
		}

			if (collision.collider.tag == "Enemy" && isOnGround) 
			{
				gameObject.SetActive (false);
			}
			//audio
		}
}
