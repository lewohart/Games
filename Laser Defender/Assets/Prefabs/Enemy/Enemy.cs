using System;
using UnityEngine;

public class Enemy: MonoBehaviour {
    public float Health = 300.0f;
    public float ProjectileSpeed = 5.0f;
    public float FiringRate = 0.2f;
    public float ShotsPerSecond = 0.5f;

    private ScoreKeeper scoreKeeper;

    public GameObject Projectile;
    public AudioClip FireSound;
    public AudioClip DieSound;

    private void Start() {
        this.scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    private void Update() {
        float probability = Time.deltaTime * ShotsPerSecond;

        if (UnityEngine.Random.value < probability) {
            Fire();
        }
    }

    private void Fire() {
        var pos = transform.position + new Vector3(0, -0.5f, 0);
        var bean = Instantiate(Projectile, pos, Quaternion.identity) as GameObject;
        bean.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -ProjectileSpeed, 0);
        AudioSource.PlayClipAtPoint(FireSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D c) {
        var projectile = c.gameObject.GetComponent<PlayerProjectile>();

        if (projectile == null) {
            return;
        }

        Health -= projectile.Damage;
        this.scoreKeeper.Score(Convert.ToInt32(projectile.Damage));


        if (Health <= 0) {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(DieSound, transform.position);
        }

        projectile.Hit();
    }
}
