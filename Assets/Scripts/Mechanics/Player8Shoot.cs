using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player8Shoot : MonoBehaviour
{
	public float speed = 12f;
	public Rigidbody2D rb;
	public Vector2 movement;
	private Vector2 screenBounds;
	public int bulletDirection = 0;
	public float tempTime;
	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		rb = this.GetComponent<Rigidbody2D>();
		tempTime = Time.time + 2f;
	}

	void Update()
	{
		//if (transform.position.x > (screenBounds.x * 1.5) || transform.position.x < -(screenBounds.x *1.5) ||
		//	transform.position.y > (screenBounds.y * 1.2) || transform.position.y < -(screenBounds.y *1.2)   )
		if (Time.time > tempTime)
		{
            Destroy(this.gameObject);
        }
		movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
	}

	void FixedUpdate()
	{
		switch (bulletDirection)
		{
			case 8:
		        ShootUpRight(movement);
		        break;
			case 7:
		        ShootUpLeft(movement);
		        break;
		    case 6:
		    	ShootUp(movement);
		        break;
			case 5:
		        ShootDownRight(movement);
		        break;
			case 4:
		        ShootDownLeft(movement);
		        break;
		    case 3:
		    	ShootDown(movement);
		        break;
		    case 2:   
		        ShootRight(movement);
		        break;
		    case 1:
		        ShootLeft(movement);
		        break;
		}
	}

	public void ShootUpRight(Vector2 direction)
	{
        //shoots bullet at the right direction
        Quaternion rotation = Quaternion.Euler(0,0,45);
        GetComponent<Transform>().rotation = rotation;
        rb.MovePosition((Vector2)transform.position + new Vector2(speed * Time.deltaTime, 0.15f ));
	}
	public void ShootUpLeft(Vector2 direction)
	{
        //shoots bullet at the right direction
        Quaternion rotation = Quaternion.Euler(0,0,135);
        GetComponent<Transform>().rotation = rotation;
        rb.MovePosition((Vector2)transform.position + new Vector2(speed * Time.deltaTime * -1, 0.15f ));
	}
	public void ShootUp(Vector2 direction)
	{
        //shoots bullet at the right direction
        Quaternion rotation = Quaternion.Euler(0,0,90);
        GetComponent<Transform>().rotation = rotation;
		rb.MovePosition((Vector2)transform.position + new Vector2(0f, Time.deltaTime * speed ));
	}
	public void ShootDownRight(Vector2 direction)
	{
        //shoots bullet at the right direction
        Quaternion rotation = Quaternion.Euler(0,0,-45);
        GetComponent<Transform>().rotation = rotation;
        rb.MovePosition((Vector2)transform.position + new Vector2(speed * Time.deltaTime, -0.15f ));
	}
	public void ShootDownLeft(Vector2 direction)
	{
        //shoots bullet at the right direction
        Quaternion rotation = Quaternion.Euler(0,0,-135);
        GetComponent<Transform>().rotation = rotation;
        rb.MovePosition((Vector2)transform.position + new Vector2(speed * Time.deltaTime * -1, -0.15f ));
	}
	public void ShootDown(Vector2 direction)
	{
        //shoots bullet at the right direction
        Quaternion rotation = Quaternion.Euler(0,0,-90);
        GetComponent<Transform>().rotation = rotation;
		rb.MovePosition((Vector2)transform.position + new Vector2(0f, Time.deltaTime * speed * -1));
	}
	public void ShootRight(Vector2 direction)
	{
        //shoots bullet at the right direction
        rb.MovePosition((Vector2)transform.position + new Vector2(speed * Time.deltaTime, 0f ));
	}
	public void ShootLeft(Vector2 direction)
	{
		Quaternion rotation = Quaternion.Euler(180,0,180);
        GetComponent<Transform>().rotation = rotation;
    	rb.MovePosition((Vector2)transform.position + new Vector2(speed * Time.deltaTime * -1, 0f ));
	}
}

