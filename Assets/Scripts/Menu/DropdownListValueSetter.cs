using TMPro;
using UnityEngine;

public class DropdownListValueSetter : MonoBehaviour
{
    [SerializeField] IntVariable intVariable;
    [SerializeField] TMP_Dropdown dropdownList;

    private void Start()
    {
        dropdownList.value = intVariable.value;
    }
}
