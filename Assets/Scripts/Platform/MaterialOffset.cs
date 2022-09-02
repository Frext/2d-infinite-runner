using UnityEngine;

public class MaterialOffset : MonoBehaviour
{
    Material material;

    Vector2 offset;
    [SerializeField] private int xVelocity, yVelocity;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
