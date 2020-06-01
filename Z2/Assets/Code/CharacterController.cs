using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Z2
{
	public class CharacterController : MonoBehaviour
	{
		public bool isDead = false;
		public Animator animator;
		public float jumpForce = 400f;
		public float runSpeed = 40f;
		public Text text;

		[SerializeField] public LayerMask groundLayer;

		private Rigidbody2D rigidbody2D;
		private bool grounded = true;
		private bool facingRight = true;
		public GameObject legs;

		private void Awake()
		{
			rigidbody2D = GetComponent<Rigidbody2D>();
		}
		private void FixedUpdate()
		{
			grounded = false;

			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll(legs.transform.position, .2f, groundLayer);
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
					grounded = true;
			}
		}
		public void Move(float move, bool jump)
		{
			if (!isDead)
			{
				move *= runSpeed;
				animator.SetFloat("Speed", Mathf.Abs(move));
				Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);
				//rigidbody2D.AddForce(targetVelocity);
				rigidbody2D.velocity = new Vector2(move * 10f, rigidbody2D.velocity.y);

				if (move > 0 && !facingRight)
				{
					Flip();
				}
				else if (move < 0 && facingRight)
				{
					Flip();
				}

				if (grounded && jump)
				{
					grounded = false;
					rigidbody2D.AddForce(new Vector2(0f, jumpForce));
				}
			}
		}

		private void Flip()
		{
			facingRight = !facingRight;

			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.CompareTag("Traps"))
			{
				isDead = true;
				text.text = "Smutny koniec!";
				animator.SetBool("IsDead", true);
				rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
			}
		}
	}
}