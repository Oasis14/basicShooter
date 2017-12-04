using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB : StateMachineBehaviour {
	public float m_Damping = 0.15f;


	private readonly int m_HashHorizontalPara = Animator.StringToHash ("Horizontal");
	private readonly int m_HashVerticalPara = Animator.StringToHash ("Vertical");


	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		bool shift = Input.GetKey (KeyCode.LeftShift);


		Vector2 input = new Vector2(horizontal, vertical).normalized;
		if (shift) {
			animator.SetFloat(m_HashHorizontalPara, 2 * input.x, m_Damping, Time.deltaTime);
			animator.SetFloat(m_HashVerticalPara, 2 * input.y, m_Damping, Time.deltaTime);

		} else {
			animator.SetFloat(m_HashHorizontalPara, input.x, m_Damping, Time.deltaTime);
			animator.SetFloat(m_HashVerticalPara, input.y, m_Damping, Time.deltaTime);
		}

	}
}
