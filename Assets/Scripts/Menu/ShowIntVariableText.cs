using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowIntVariableText : MonoBehaviour
{ 
    [SerializeField] IntVariable intVariable;
    [SerializeField] TextMeshProUGUI textMeshPro;

    [SerializeField] bool shouldUpdate;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = intVariable.value.ToString();

        if(!shouldUpdate)
        {
            enabled = false;
        }        
    }

    void Update()
    {
        textMeshPro.text = intVariable.value.ToString();
    }
}
