using UnityEngine;

public class MoveWith : MonoBehaviour
{
	[SerializeField] private Transform moveWith;

	private Vector3 offset;

	private void Start ()
	{
		offset = transform.position - moveWith.position;
	}

	private void Update ()
	{
		transform.position = moveWith.position + offset;
	}
}