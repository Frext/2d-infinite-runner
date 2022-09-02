using UnityEngine;

public class TrapMovement : MonoBehaviour
{
    [HideInInspector] public float speed = 5.0f;

    // Update is called once per frame
    void Update() => MoveLeft();

    private void MoveLeft() => gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0);
}
