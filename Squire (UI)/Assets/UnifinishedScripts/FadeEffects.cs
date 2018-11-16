
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeEffects : MonoBehaviour {

    public Animator animator;

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fade();
        }		
	}

    public void Fade()
    {
        animator.SetTrigger("FadeOut");
    }
}