using UnityEngine;

public class Player : MonoBehaviour {
	private float XMin;
	private float XMax;

	public float Health = 1000.0f;
	public float Speed = 15.0f;
	public float Padding = 1.0f;
	public float ProjectileSpeed = 5.0f;
	public float FiringRate = 0.2f;

	public GameObject Projectile;
    public AudioClip FireSound;

    void Start() {
		var d = transform.position.z - Camera.main.transform.position.z;
		var l = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, d));
		var r = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, d));
		XMin = l.x + Padding;
		XMax = r.x - Padding;
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.00001f, FiringRate);
		}

		if(Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * Speed * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * Speed * Time.deltaTime;
		}

		KeepInside();
	}

	private void Fire() {
		var pos = transform.position + new Vector3(0, 0.5f, 0);
		var bean = Instantiate(Projectile, pos, Quaternion.identity) as GameObject;
		bean.GetComponent<Rigidbody2D>().velocity = new Vector3(0, ProjectileSpeed, 0);
        AudioSource.PlayClipAtPoint(FireSound, transform.position);
	}

	private void KeepInside() {
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * Speed * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * Speed * Time.deltaTime;
		}

		var x = Mathf.Clamp(transform.position.x, XMin, XMax);
		transform.position = new Vector3(x, transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D c) {
		var projectile = c.gameObject.GetComponent<EnemyProjectile>();

		if(projectile == null) {
			return;
		}

		Health -= projectile.Damage;

		if(Health <= 0) {
            Die();
        }

        projectile.Hit();
	}

    private void Die() {
        Destroy(gameObject);
        var manager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        if (manager != null) {
            manager.LoadLevel("Win Screen");
        }
    }
}
