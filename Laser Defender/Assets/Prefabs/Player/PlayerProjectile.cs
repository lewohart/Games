using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
	public float Damage = 100f;

	public void Hit() {
		Destroy(this.gameObject);
	}
}
