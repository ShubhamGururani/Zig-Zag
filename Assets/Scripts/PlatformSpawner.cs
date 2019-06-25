using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public GameObject platform;
	public GameObject diamonds;
	Vector3 lastPos;
	float size;
	public bool gameOver;


	// Use this for initialization
	void Start () {
		lastPos = platform.transform.position;
		size = platform.transform.localScale.x;

		for(int i = 0; i<= 5;i++){
			SpawnPlatforms();
		}
		
			
	}

	public void StartSpawningPlatforms(){
		InvokeRepeating("SpawnPlatforms",1f,0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver == true){
			CancelInvoke("SpawnPlatforms");
		}	
	}

	void SpawnPlatforms(){

		int rand = Random.Range(0,6);
		if(rand < 3){
				SpawnX();
		}
		else{
			SpawnZ();
		}
	}

	void SpawnX(){

		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;
		Instantiate(platform, pos, Quaternion.identity);

		int rand = Random.Range(0,5);
		if(rand == 0){
			Instantiate(diamonds,new Vector3(pos.x,pos.y+1,pos.z),diamonds.transform.rotation);
		}

	}


	void SpawnZ(){
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;
		Instantiate(platform, pos, Quaternion.identity);

		int rand = Random.Range(0,5);
		if(rand == 0){
			Instantiate(diamonds,new Vector3(pos.x,pos.y+1,pos.z),diamonds.transform.rotation);
		}
	}

	


}
