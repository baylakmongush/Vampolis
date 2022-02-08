using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
	public float rotationSpeed;
	private Vector2 direction;
	public float moveSpeed;
	public Transform tagret;

	// Update is called once per frame
	private void Move()
	{
		direction = tagret.position - transform.position; // change Camera.main.ScreenToWorldPoint(Input.mousePosition) to tagret.position
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


		//Vector2 cursorPosition = tagret.position;
		//transform.position = Vector2.MoveTowards(transform.position, cursorPosition, moveSpeed * Time.deltaTime);
	}
}
