﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour {
	
	public GameObject P1, P2;
	private Vector3 P1Position, P2Position, center;
	private Renderer P1Renderer;
	private Camera myCamera;
	private float viewFieldOffset = 1.5f, viewSizeSpeed = 1.2f, upOffset = 4f, currentZ = -20f;
	
	private const int UP = 3, DOWN = 2, LEFT = 0, RIGHT = 1;
	private Plane[] cameraPlanes;
	
	// Use this for initialization
	void Start () {
		P1 = GameObject.Find("Player1");
		P2 = GameObject.Find("Player2");
		P1Renderer = P1.GetComponent<Renderer>();
		myCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		P1Position = P1.transform.position;
		P2Position = P2.transform.position;
		center = P1Position + ((P2Position - P1Position)/2f);
		center.z = currentZ;
        center.y += upOffset;
		transform.position = center;
		cameraPlanes = GeometryUtility.CalculateFrustumPlanes(myCamera);
		
		if(offScreen()) {
			myCamera.transform.Translate(Vector3.back * viewSizeSpeed * Time.deltaTime);
			currentZ -= viewSizeSpeed * Time.deltaTime;
		}
		else if(myCamera.transform.position.z < -13f && Input.anyKey) {
			myCamera.transform.Translate(Vector3.forward * viewSizeSpeed * Time.deltaTime);
			currentZ += viewSizeSpeed * Time.deltaTime;
		}
	}
	
	bool offScreen() {
		return(! (cameraPlanes[UP].GetSide(P1Position + Vector3.up*viewFieldOffset) && cameraPlanes[DOWN].GetSide(P1Position + Vector3.down*viewFieldOffset) && cameraPlanes[LEFT].GetSide(P1Position + Vector3.left*viewFieldOffset) && cameraPlanes[RIGHT].GetSide(P1Position + Vector3.right*viewFieldOffset)));
	}
}
