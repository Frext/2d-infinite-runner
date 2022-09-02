using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInstantiater : MonoBehaviour
{
    [SerializeField] IntVariable characterSelectionIndex;

    [SerializeField] List<GameObject> characterPrefabsList;

    public void ChangeSelectionIndex(int index)
    {
        characterSelectionIndex.value = index;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            InstantiateCharacterByIndex();

            Destroy(gameObject);
        }
    }

    private void InstantiateCharacterByIndex()
    {
        Instantiate(characterPrefabsList[characterSelectionIndex.value], gameObject.transform.position, Quaternion.identity);
    }
}
