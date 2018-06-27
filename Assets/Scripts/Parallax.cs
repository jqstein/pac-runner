using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parallaxScales;
	public float smoothing;
	//public Transform cam;
	private Vector3 previousCamPos;

	void Start () {
		//cam = Camera.main.transform;
		previousCamPos = transform.position;
		parallaxScales = new float[backgrounds.Length];
		
		for (int i = 0; i < backgrounds.Length; i ++) {
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}
	}
	
	void LateUpdate () {
		for (int i = 0; i < backgrounds.Length; i ++) {
			float parallax = (previousCamPos.x - transform.position.x) * parallaxScales[i];
			float backgroundTargetPositionX = backgrounds[i].position.x + parallax;
			
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z);
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		previousCamPos = transform.position;
	}
}