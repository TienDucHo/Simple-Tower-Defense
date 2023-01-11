using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    // Start hitpoints
    public int hitpoints = 1;
    // Remaining hitpoints
    public int currentHitpoints;
    // Hit visual effect duration
    public float hitDisplayTime = 0.2f;

    // Image of this object
    private SpriteRenderer sprite;
    // Visualisation of hit
    private bool hitCoroutine;

    Animator animator;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    void Awake()
    {
        currentHitpoints = hitpoints;
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Debug.Assert(sprite, "Wrong initial parameters");
    }

    /// <summary>
    /// Take damage.
    /// </summary>
    /// <param name="damage">Damage.</param>
    public void TakeDamage(int damage)
    {
        if (currentHitpoints > damage)
        {
            // Still alive
            currentHitpoints -= damage;
            // If no coroutine now
            if (hitCoroutine == false)
            {
                // Damage visualisation
                StartCoroutine(DisplayDamage());
            }
        }
        else
        {
            // Die
            currentHitpoints = 0;
            Die();
        }
    }

    /// <summary>
    /// Die this instance.
    /// </summary>
    public void Die()
    {
        EventManager.TriggerEvent("UnitDie", gameObject, null);
        Destroy(gameObject);
    }

    /// <summary>
    /// Damage visualisation.
    /// </summary>
    /// <returns>The damage.</returns>
    IEnumerator DisplayDamage()
    {
        hitCoroutine = true;
        float counter;
        for (counter = 0f; counter < hitDisplayTime; counter += Time.deltaTime)
        {
            yield return new WaitForEndOfFrame();
        }
        animator.SetTrigger("Hurt");
        hitCoroutine = false;
    }
}
