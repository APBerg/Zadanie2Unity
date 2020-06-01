using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Z2
{
	public class Movement : MonoBehaviour
	{

		public CharacterController controller;

		public float horizontalMove = 0f;
		bool jump = false;

		// Update is called once per frame
		void Update()
		{

			horizontalMove = Input.GetAxisRaw("Horizontal");
			if (Input.GetButtonDown("Jump"))
			{
				jump = true;
			}
		}

		void FixedUpdate()
		{
			// Move our character
			controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
			jump = false;
		}
	}
}