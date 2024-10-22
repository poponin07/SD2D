using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveComponent : MonoBehaviour
{
	private Rigidbody2D m_rb;
	private Vector2 m_motionVector;
	[SerializeField] private float m_speed;
	private Animator m_animator;
	
	void Awake()
	{
		m_rb = GetComponent<Rigidbody2D>();
		m_animator = GetComponent<Animator>();
	}
	
	void Update()
	{
		m_motionVector = new Vector2(
			Input.GetAxisRaw("Horizontal"), 
			Input.GetAxisRaw("Vertical"));
			
		m_animator.SetFloat("horizontal", Input.GetAxisRaw("Horizontal"));
		m_animator.SetFloat("vertical", Input.GetAxisRaw("Vertical"));
	}
	
	void FixedUpdate()
	{
		Move();
	}
	
	private void Move()
	{
		m_rb.velocity =  m_motionVector * m_speed * Time.deltaTime;
	}
}
