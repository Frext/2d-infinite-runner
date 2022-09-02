using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySetter : MonoBehaviour
{
    [SerializeField] TrapInstantiater trapInstantiater;
    [SerializeField] IntVariable difficultyVariable;

    public void ChangeDifficulty(int index)
    {
        difficultyVariable.value = index;
    }

    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            switch (difficultyVariable.value)
            {
                case 0:
                    trapInstantiater.instantiateInterval = 2f;
                    break;

                case 1:
                    trapInstantiater.instantiateInterval = 1.5f;
                    break;

                case 2:
                    trapInstantiater.instantiateInterval = 1f;
                    break;

                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
