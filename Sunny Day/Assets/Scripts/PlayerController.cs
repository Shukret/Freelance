using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour {
	[SerializeField] private AudioSource jumpFX;
	[SerializeField] private AudioSource gemFX;
	[SerializeField] private AudioSource keyFX;



	public static int gems;
	[SerializeField] private bool arcade = false;
	[SerializeField] private Text ArcadeText;
	int points;

	public enum ProjectAxis {onlyX = 0, xAndY = 1};
	public ProjectAxis projectAxis = ProjectAxis.onlyX;
	public float speed = 150;
	public float addForce = 7;
	public bool lookAtCursor;
	public KeyCode leftButton = KeyCode.A;
	public KeyCode rightButton = KeyCode.D;
	public KeyCode upButton = KeyCode.W;
	public KeyCode downButton = KeyCode.S;
	public KeyCode addForceButton = KeyCode.Space;
	public bool isFacingRight = true;
	private Vector3 direction;
	private float vertical;
	private float horizontal;
	private Rigidbody2D body;
	private float rotationY;
	private bool jump;

	//анимации
	[SerializeField] private Animator anim;
	//стояние на земле
	public bool isGround;

	void Start () 
	{
		body = GetComponent<Rigidbody2D>();
		body.fixedAngle = true;
	}

	void OnCollisionStay2D(Collision2D coll) 
	{
		if(coll.transform.tag == "Ground")
		{
			body.drag = 10;
			jump = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D coll) 
	{
		if(coll.transform.tag == "Ground")
		{
			body.drag = 0;
			jump = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("key"))
		{
			keyFX.Play();
		}
		if (other.CompareTag("gem"))
		{
			gems += 1;
			gemFX.Play();
			Destroy(other.gameObject);
		}
		if (other.CompareTag("gemWithRB"))
		{
			gemFX.Play();
			gems += 1;
			points+=1;
			Destroy(other.gameObject);
		}
	}
	
	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed);

		if(Mathf.Abs(body.velocity.x) > speed/100f)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed/100f, body.velocity.y);
		}
	}

	void Flip()
	{
		if(projectAxis == ProjectAxis.onlyX)
		{
			isFacingRight = !isFacingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
	
	public void Jump()
	{
		if(isGround)
		{
			body.velocity = new Vector2(0, addForce);
			jumpFX.Play();
		}
	}

	public void ChangeDirection(int hor)
	{
		horizontal = hor;
	}

	void Update () 
	{
		if (arcade)
			ArcadeText.text = points.ToString();
		Debug.Log(direction);
		if(Input.GetKey(addForceButton) && isGround)
		{
			body.velocity = new Vector2(0, addForce);
		}
		if (isGround == false)
		{
			anim.SetBool("Jump", true);
		}
		else{
			anim.SetBool("Jump", false);
		}
		if (horizontal != 0)
		{
			anim.SetBool("Run", true);
		}
		else
		{
			anim.SetBool("Run", false);
		}
		if(lookAtCursor)
		{
			Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
			lookPos = lookPos - transform.position;
			float angle  = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

		if(Input.GetKey(upButton)) vertical = 1;
		else if(Input.GetKey(downButton)) vertical = -1; else vertical = 0;


		if(projectAxis == ProjectAxis.onlyX) 
		{
			direction = new Vector2(horizontal, 0); 
		}

		if(horizontal > 0 && !isFacingRight) Flip(); else if(horizontal < 0 && isFacingRight) Flip();
	}
}
