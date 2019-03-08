using UnityEngine;

public class Shredder : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D c) {
		Destroy(c.gameObject);
	}
}
