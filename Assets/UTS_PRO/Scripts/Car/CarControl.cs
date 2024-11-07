using UnityEngine;

public class CarControl : MonoBehaviour 
{
	private CarMove m_Car;

	private void Awake()
	{
		m_Car = GetComponent<CarMove>();
	}


	private void FixedUpdate()
	{
		// pass the input to the car!
	}
}
