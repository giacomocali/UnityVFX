using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class VFXManager : MonoBehaviour
{
    public GameObject smallSword, bigSword;
    public VisualEffect horizontalSlash;
    public VisualEffect verticalSlash;

    public ParticleSystem dustEffect, verticalDustEffect, additionalNoise, vAdditionalNoise;
    public GameObject getsugaJujisho;
 

    public float horizontalDelay, verticalDelay, dustDelay, additionalNoiseDelay, getsugaDelay;


    private void Start()
    {
        horizontalSlash.Stop();
        verticalSlash.Stop();
        StartCoroutine(chainEffects());
    }

    IEnumerator chainEffects()
    {
        // HORIZONTAL SLASH -------------
        bigSword.SetActive(false);
        smallSword.SetActive(true);
        yield return new WaitForSeconds(horizontalDelay);
        horizontalSlash.Play();
        yield return new WaitForSeconds(additionalNoiseDelay);
        additionalNoise.Play();
        yield return new WaitForSeconds(dustDelay-additionalNoiseDelay);
        dustEffect.Play();

        // VERTICAL SLASH -----------------
        yield return new WaitForSeconds(1f);
        bigSword.SetActive(true);
        smallSword.SetActive(false);
        yield return new WaitForSeconds(verticalDelay-1f);
        verticalSlash.Play();
        yield return new WaitForSeconds(0.2f);
        vAdditionalNoise.Play();
        yield return new WaitForSeconds(dustDelay-0.2f);
        verticalDustEffect.Play();

        // GETSUGA JUJISHO -------------------
        yield return new WaitForSeconds(getsugaDelay);
        additionalNoise.gameObject.SetActive(false);
        vAdditionalNoise.gameObject.SetActive(false);
        getsugaJujisho.SetActive(true);
    }
}
