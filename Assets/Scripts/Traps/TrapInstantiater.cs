using System.Collections.Generic;
using UnityEngine;

public class TrapInstantiater : MonoBehaviour
{
    [SerializeField] List<GameObject> trapsList;
    [SerializeField] GameObject parentGameObject;

    [SerializeField] float upBoundary;
    [SerializeField] float downBoundary;

    [HideInInspector] public float instantiateInterval; // This will be set by the difficulty setter.

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(InstantiateTrap), 0.5f, instantiateInterval);
    }

    private void InstantiateTrap()
    {
        int randomIndex = Random.Range(0, trapsList.Count);
        float randomY = Random.Range(downBoundary, upBoundary);

        Instantiate(trapsList[randomIndex], new Vector3(gameObject.transform.position.x, randomY), Quaternion.identity)
            .transform.SetParent(parentGameObject.transform);
    }
}
