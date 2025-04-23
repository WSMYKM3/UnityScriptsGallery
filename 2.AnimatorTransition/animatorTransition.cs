using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Trigger the isDying animation when W is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isDying", true);
        }

        //注意这里的GeyKey和上面GetKeyDown的区别，GetKey要注意按下w后会一直保持true的状态，直到检测到！GetKey
        // if (Input.GetKey(KeyCode.W))
        // {
        //     animator.SetBool("isDying", true);
        // }
        //  if (!Input.GetKey(KeyCode.W))
        // {
        //     animator.SetBool("isDying", true);
        // }
    }
}
