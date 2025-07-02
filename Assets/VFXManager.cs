using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class VFXManager : MonoBehaviour
{
    public VisualEffect horizontalSlash;
    public VisualEffect verticalSlash;
    public ParticleSystem dustEffect;
    public float horizontalDelay, verticalDelay, dustDelay;
    private void Start()
    {
        horizontalSlash.Stop();
        verticalSlash.Stop();
        StartCoroutine(chainEffects());
    }

    IEnumerator chainEffects()
    {
        yield return new WaitForSeconds(horizontalDelay);
        horizontalSlash.Play();
        yield return new WaitForSeconds(dustDelay);
        dustEffect.Play();
        yield return new WaitForSeconds(verticalDelay);
        verticalSlash.Play();
    }
}
