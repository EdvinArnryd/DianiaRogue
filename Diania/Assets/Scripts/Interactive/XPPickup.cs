using System;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine;

public class XPPickup : MonoBehaviour
{
    [SerializeField] private float _xpAmount = 5;

    [SerializeField] private float pushDistance = 1.5f;
    [SerializeField] private float pushDuration = 0.2f;
    [SerializeField] private float pullSpeed = 6f;
    [SerializeField] private AnimationCurve pullCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AnimatePickup(other.transform));
        }
    }

    private IEnumerator AnimatePickup(Transform player)
    {
        Vector3 start = transform.position;
        Vector3 dir = (transform.position - player.position).normalized;

        // Step 1: Push away
        Vector3 pushTarget = start + dir * pushDistance;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / pushDuration;
            transform.position = Vector3.Lerp(start, pushTarget, t);
            yield return null;
        }

        // Step 2: Pull back (like gravity)
        float elapsed = 0f;
        Vector3 pullStart = transform.position;

        while (true)
        {
            elapsed += Time.deltaTime * pullSpeed;
            float progress = pullCurve.Evaluate(elapsed);

            // Move towards player using interpolation
            transform.position = Vector3.Lerp(pullStart, player.position, progress);

            // If close enough — collect
            if (Vector3.Distance(transform.position, player.position) < 0.3f)
            {
                LevelSystem levelSystem = player.GetComponent<LevelSystem>();
                if (levelSystem != null)
                {
                    levelSystem.GainExp(_xpAmount);
                }
                Destroy(gameObject);
                yield break;
            }

            yield return null;
        }
    }
}
