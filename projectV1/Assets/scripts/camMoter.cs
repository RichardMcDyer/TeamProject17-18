using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMoter : MonoBehaviour {


	private Transform lookAt;
	private Vector3 startOffSet;
	private Vector3 moveV;

	private float transition = 0.0f;
	private float animationDiration = 3.0f;
	private Vector3 animationOffSet = new Vector3 (0, 5, 5);
	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag("Player").transform;
		startOffSet = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
		moveV = lookAt.position + startOffSet;

		//x
		moveV.x = 0;
		//y
		moveV.y = Mathf.Clamp(moveV.y,3,5);

		if (transition > 1.0f) {
			transform.position = moveV;
		} else {
			//animation strat 
			transform.position = Vector3.Lerp(moveV + animationOffSet,moveV,transition);
			transition += Time.deltaTime * 1 / animationDiration;
			transform.LookAt (lookAt.position + Vector3.up);
		}


	}
}
