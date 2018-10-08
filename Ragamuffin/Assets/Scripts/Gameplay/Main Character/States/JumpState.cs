﻿using UnityEngine;

public class JumpState : MovementState {

	public JumpState(MainCharacter c) : base(c) { name = "jump"; }

	public override void Update()
	{
		if(mc.controller.isGrounded)
		{
			if(mc.runState.StateAllowed())
				mc.SetMovementState(mc.runState);
			else
				mc.SetMovementState(mc.idleState);
		}
		else 
		{
			ApplyGrounding();
			ApplyVelocityX(mc.inAirDamping);
            ApplyVelocityY();
			Move();
		}
	}

	public override void OnStateEnter()
	{
		mc.velocity.y = Mathf.Sqrt( 2f * mc.jumpHeight * -mc.gravity );
		// ignores grounding for first movement calculation
		// to avoid problem where grounding checks prevent character
		// from lifting off the ground
		ApplyVelocityX(mc.inAirDamping);
		ApplyVelocityY();
		Move();
	}

	public override bool StateAllowed()
	{
		if(mc.controller.isGrounded && Input.GetAxis(mc.verticalAxis) > 0f)
			return true;
		return false;
	}

}