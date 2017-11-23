using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;
	public AudioClip coinPickUp;

	private AudioSource source;

	void Awake () {

		source = GetComponent<AudioSource>();
		source.dopplerLevel = 0f;

	}

	void Start () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.GetComponent<PlayerController> () == null) 
			return;

		ScoreManager.AddPoints (pointsToAdd);

		AudioSource.PlayClipAtPoint(coinPickUp, transform.position);

		Destroy (gameObject);

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
