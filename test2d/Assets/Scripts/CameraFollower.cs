using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour 
{

	public Transform target;
	public bool followInX;
	public bool followInY;
	public float xOffset;
	public float yOffset;

	void Update() 
	{
		float posX = followInX ? target.position.x + xOffset : transform.position.x;
		float posY = followInY ? target.position.y + yOffset : transform.position.y;
		transform.position = new Vector3(posX,posY,transform.position.z);
		/*if(followInX && followInY)
		{
			Vector3 targetPos = new Vector3(target.position.x,target.position.y,transform.position.z);
			transform.position = newPos + Vector3.right*xOffset;
		}
		else if(followInX)
		{
			Vector3 newPos = new Vector3(target.position.x,transform.position.y,transform.position.z);
			transform.position = newPos + Vector3.right*xOffset;
		}
		else if(followInY)
		{
			Vector3 newPos = new Vector3(transform.position.x,target.position.y,transform.position.z);
			transform.position = newPos;
		}*/
	}
}
