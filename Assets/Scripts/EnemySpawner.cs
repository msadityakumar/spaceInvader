using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 5f;
	public float height = 10f;
	private bool isMovingLeft;
	private float xMin;
	private float xMax;
	public float speed = 2f ;


	// Use this for initialization
	void Start () 
	{
		isMovingLeft = false;
	float cameraDistance = transform.position.z - Camera.main.transform.position.z;
	xMin = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,cameraDistance)).x;
	xMax = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, cameraDistance)).x;

	foreach (Transform child in transform)
	{
		GameObject enemyObj = Instantiate(enemyPrefab,child.transform.position,Quaternion.identity) as GameObject;
		enemyObj.transform.parent = child;

		}
	}


	public	void OnDrawGizmos()
	{
	
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isMovingLeft) {
			transform.position +=  Vector3.right * speed * Time.deltaTime;
		
		} else {
			transform.position -=  Vector3.right * speed * Time.deltaTime;
		}
		float leftTransformPosition = transform.position.x - (0.5f * width);
		float rightTransformPosition = transform.position.x + (0.5f * width);

		if (leftTransformPosition < xMin || rightTransformPosition > xMax) {
			isMovingLeft = !isMovingLeft;
		
		}
	}
}
