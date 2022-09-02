using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(Rigidbody2D), typeof(Animator))]
public class CharacterScore : MonoBehaviour
{
    [SerializeField] IntVariable totalScore;

    [SerializeField] bool ResetScore;
    [SerializeField] int startScore;

    [SerializeField] IntVariable difficulty;

    [SerializeField] private GameObject gameOverMenu;   // This will be assigned by the character instantiater.

    Rigidbody2D rb2;
    Animator animator;
    CharacterMovement characterMovement;

    bool isAlive; // This prevents playing the death animation twice.

    private void Awake()
    {
        if (ResetScore)
        {
            totalScore.value = startScore;
        }
    }

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();

        isAlive = true;

        float incrementScoreAfter;

        switch (difficulty.value)
        {
            case 0:
                incrementScoreAfter = 1f;
                break;
            case 1:
                incrementScoreAfter = 0.7f;
                break;
            case 2:
                incrementScoreAfter = 0.4f;
                break;
            default:
                throw new System.NotImplementedException();
        }

        InvokeRepeating(nameof(IncreaseScore), 1f, incrementScoreAfter);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(6) && isAlive)    // If the character collided with a trap
        {
            Die();

            FollowTransform(collision.transform);  // Move the character with the trap backwards.

            isAlive = false;

            CancelInvoke(nameof(IncreaseScore));
        }
    }

    private void FollowTransform(Transform transform)
    {
        gameObject.transform.SetParent(transform);
    }

    private void IncreaseScore()
    {
        totalScore.value++;
    }

    private void Die()
    {
        characterMovement.isInputEnabled = false;

        animator.SetTrigger("death");
    }

    #region Functions Called By Animation Events

    public void ShowGameOverMenu()
    {
        Instantiate(gameOverMenu, new Vector3(0, 0, 0), Quaternion.identity);
    }

    #endregion
}
