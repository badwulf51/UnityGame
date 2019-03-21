using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {
	// movement variables 
	public float moveSpeed = 300;
	public float jumpForce = 800f;
	public GameObject character;
	private Rigidbody2D characterBody; 

	private float ScreenWidth;
	private bool jump = false; 

	// Use this for initialization
	void Start () {
		ScreenWidth = Screen.width; 
		characterBody = character.GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		int i=0;
		// Loops over each touch 
		while (i < Input.touchCount){
			if(Input.GetTouch (i).position.x > ScreenWidth / 2){
				RunCharacter (1.0f);
		}
			if(Input.GetTouch (i).position.x < ScreenWidth / 4){
				RunCharacter (-1.0f);
		}
		++i;
	}
}
// used for testing touch controls inside unity editor 
void FixedUpdate(){
#if UNITY_EDITOR
RunCharacter(Input.GetAxis("Horizontal"));
#endif

}

	private void RunCharacter(float horizontalInput){
		characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
	}

	//private void jumpCharacter(float verticalInput){
		//characterBody.AddForce(new Vector2(verticalInput * jumpForce * Time.deltaTime, 0));
	//}

}
