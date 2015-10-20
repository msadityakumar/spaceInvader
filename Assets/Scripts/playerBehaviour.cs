using UnityEngine;
using System.Collections;

public class playerBehaviour : MonoBehaviour {

	// Use this for initialization

	float xMax ;
	float xMin;
	float padding = 1.0f;
	public GameObject playerBeam;
	public float repeatRate = 0.2f;


	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3( 1,0,distance));

		xMin = leftMost.x+padding;
		xMax = rightMost.x-padding;
	}



	void Fire()
	{
		GameObject projectile = Instantiate(playerBeam,transform.position,Quaternion.identity) as GameObject;
		projectile.rigidbody2D.velocity = new Vector3(0,5f,0);
	
	}

	// Update is called once per frame

	void Update () {
	

		if (Input.GetKeyDown (KeyCode.Space))
		{
			InvokeRepeating("Fire",0.0000001f,repeatRate);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke();
		}


		if(Input.GetKey(KeyCode.RightArrow))
		{
			float pos = this.transform.position.x +0.1f;
			Vector3 newPosition = new Vector3(pos,this.transform.position.y,this.transform.position.z);
			this.transform.position =  newPosition;

		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			float pos = this.transform.position.x -0.1f;
			Vector3 newPosition = new Vector3(pos,this.transform.position.y,this.transform.position.z);
			this.transform.position =  newPosition;
			
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			float pos = this.transform.position.y +0.1f;
			Vector3 newPosition = new Vector3(transform.position.x,pos,this.transform.position.z);
			this.transform.position =  newPosition;
			
		}

		if(Input.GetKey(KeyCode.DownArrow))
		{
			float pos = this.transform.position.y -0.1f;
			Vector3 newPosition = new Vector3(transform.position.x,pos,this.transform.position.z);
			this.transform.position =  newPosition;
		}
		this.transform.position = new Vector3 (Mathf.Clamp(transform.position.x,xMin,xMax),transform.position.y,transform.position.z);
	
	}
}
