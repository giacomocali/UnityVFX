using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class VFXManager : MonoBehaviour
{
    public GameObject smallSword, bigSword;
    public VisualEffect horizontalSlash;
    public VisualEffect verticalSlash;
    
    public ParticleSystem dustEffect;
    public ParticleSystem getsugaJujisho;
 

    public float horizontalDelay, verticalDelay, dustDelay, getsugaDelay;


    private void Start()
    {
        horizontalSlash.Stop();
        verticalSlash.Stop();
        StartCoroutine(chainEffects());
    }

    IEnumerator chainEffects()
    {
        bigSword.SetActive(false);
        smallSword.SetActive(true);
        
        yield return new WaitForSeconds(horizontalDelay);
        //swordRenderer.sharedMesh = smallBlade;
        horizontalSlash.Play();

        yield return new WaitForSeconds(dustDelay);
        dustEffect.Play();

        yield return new WaitForSeconds(1.5f);
        bigSword.SetActive(true);
        smallSword.SetActive(false);

        yield return new WaitForSeconds(verticalDelay-1.5f);
        //swordRenderer.sharedMesh = bigBlade;
        verticalSlash.Play();

        yield return new WaitForSeconds(getsugaDelay);
        getsugaJujisho.Play();
    }
}
