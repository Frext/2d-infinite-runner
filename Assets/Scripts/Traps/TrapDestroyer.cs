using UnityEngine;

public class TrapDestroyer : MonoBehaviour
{
    [SerializeField] LayerMask trapLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Got help from https://forum.unity.com/threads/get-the-layernumber-from-a-layermask.114553/#post-3021076
        if (collision.gameObject.layer == Mathf.Log(trapLayer.value, 2))
        {
            if (collision.transform.childCount == 1)
            {
                // In some traps, to prevent player from rotating 360 degrees, we set the sprite renderer as a child of the collider.
                // We set the sprite renderer as a child of the collider and make the transform of the sprite renderer.

                // If the child has a collider, that means the child is the character.
                // If it doesn't have a collider, that means the child is the sprite renderer.

                if (collision.transform.GetComponentInChildren<Collider2D>() != null)
                {
                    collision.transform.DetachChildren();

                    // We need to make sure the character is not deleted with it.
                    // Deleting the character would intercept the game-over menu from showing up.
                }
            }

            else if (collision.transform.childCount == 2)
            {
                // If there are 2 childs, that means they are the sprite renderer and the character.
                // Because sprite renderer is always the first child, we can detach the character easily.

                collision.transform.GetChild(1).SetParent(null);
            }

            Destroy(collision.gameObject);
        }
    }
}
