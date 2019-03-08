using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {
	public float Damage = 100f;

	public void Hit() {
		Destroy(this.gameObject);
	}
}
