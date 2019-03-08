using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour {
	public GameObject EnemyPrefab;
	public float Widht = 10f;
	public float Heigth = 5f;

	public float Speed = 15.0f;
	public float Padding = 1.0f;

	public float XMin { get; set; }
	public float XMax { get; set; }

	public float respawTime = 0.5f;

	private bool movingRight = true;

	void Start() {
		var d = transform.position.z - Camera.main.transform.position.z;
		var l = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, d));
		var r = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, d));
		XMin = l.x + Padding;
		XMax = r.x - Padding;
		SpawnEnemies();
	}

	private void SpawnEnemies() {
		foreach(Transform p in transform) {
			var enemy = Instantiate(EnemyPrefab, p.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = p;
		}
	}

	private void SpawnUntilFullEnemies() {
		var transform = NextFreePosition();

		if(transform != null) {
			Debug.Log("Has Free");
			var enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = transform;
		}

		if(NextFreePosition() != null) {
			Debug.Log("Will SpawnUntilFullEnemies");
			Invoke("SpawnUntilFullEnemies", respawTime);
		}
	}
	
	public void Update() {
		Move();

		if(AllEnemiesAreDead()) {
			Debug.Log("AllEnemiesAreDead");
			SpawnUntilFullEnemies();
		}
	}

	private bool AllEnemiesAreDead() {
		foreach(Transform p in transform) {
			if(p.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	private Transform NextFreePosition() { 
		foreach(Transform p in transform) {
			if(p.childCount == 0) {
				return p;
			}
		}
		return null;
	}

	private void Move() {
		transform.position += (movingRight ? Vector3.right : Vector3.left) * Speed * Time.deltaTime;
		float r = transform.position.x + (Widht / 2);
		float l = transform.position.x - (Widht / 2);
		movingRight = (l < XMin) ? true : (r > XMax ? false : movingRight);
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(Widht, Heigth));
	}
}
