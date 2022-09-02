using System.Collections.Generic;
using UnityEngine;

public class ResetIntVariable : MonoBehaviour
{
    private static bool didReset = false;

    [SerializeField] List<IntVariable> intVariables;
    [SerializeField] List<int> defaultValues;

    // Start is called before the first frame update
    void Start()
    {
        if (!didReset)
        {
            for (int index = 0; index < intVariables.Count; index++)
            {
                intVariables[index].value = defaultValues[index];
            }

            didReset = true;
        }

        Destroy(gameObject);
    }
}
