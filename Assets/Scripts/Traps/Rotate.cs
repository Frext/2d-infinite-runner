using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] Transform transformToRotate;

    private void Update() => RotateObject();

    private void RotateObject() => transformToRotate.Rotate(0, 0, 360 * rotateSpeed * Time.deltaTime);
}
