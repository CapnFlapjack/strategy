using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public float xPosStart;
	public float yPosStart;
	public float zPosStart;
	
	public float xRot;
	
	public float xSpeed;
	public float zSpeed;
	
	GameObject cameraBox;
	GameObject GameMaster;
	
	float xMin;
	float xMax;
	float zMin;
	float zMax;
	
	public float xMinExtra;
	public float xMaxExtra;
	public float zMinExtra;
	public float zMaxExtra;
	
	
	// Use this for initialization
	void Start () 
	{
		if(xPosStart == 0)
		{
			xPosStart = 60;	
		}
		if(yPosStart == 0)
		{
			yPosStart = 35;	
		}
		if(zPosStart == 0)
		{
			zPosStart = -10;	
		}
		
		if(xRot == 0)
		{
			xRot = 45;	
		}
		
		if(xSpeed == 0)
		{
			xSpeed = 10;	
		}
		if(zSpeed == 0)
		{
			zSpeed = 10;	
		}
		
		cameraBox = new GameObject();
		cameraBox.name = "CameraBox";
		cameraBox.transform.position = new Vector3(xPosStart, yPosStart, zPosStart);
		transform.parent = cameraBox.transform;
		transform.localPosition = Vector3.zero;
		
		//transform.position = new Vector3(xPosStart, yPosStart, zPosStart);
		transform.localRotation = Quaternion.Euler(xRot, 0, 0);
		
		if(GameMaster == null)
		{
			GameMaster = GameObject.Find("GameMaster");
		}
		GameMaster.SendMessage("sendBoardCorners");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButton("CamRight") && cameraBox.transform.localPosition.x < xMax + xMaxExtra)
		{
			cameraBox.transform.Translate(Time.deltaTime * xSpeed, 0, 0);
		}
		
		if(Input.GetButton("CamLeft") && cameraBox.transform.localPosition.x > xMin - xMinExtra)
		{
			cameraBox.transform.Translate(Time.deltaTime * -xSpeed, 0, 0);
		}
		
		if(Input.GetButton("CamUp") && cameraBox.transform.localPosition.z < zMax + zMaxExtra)
		{
			cameraBox.transform.Translate(0, 0, Time.deltaTime * zSpeed);	
		}
		
		if(Input.GetButton("CamDown") && cameraBox.transform.localPosition.z > zMin + zMinExtra)
		{
			cameraBox.transform.Translate(0, 0, Time.deltaTime * -zSpeed);	
		}
	}
	
	void getCorners(Vector3[] corners)
	{
		xMin = corners[0].x;
		xMax = corners[1].x;
		
		zMin = corners[0].z;
		zMax = corners[1].z;
		
		//print(xMin + ":" + xMax + ":" + zMin + ":" + zMax);
	}
}