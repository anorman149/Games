using UnityEngine;

public class AnimationMethods : MonoBehaviour {

    /// <summary>
    /// Will loop through the Animations and get the appropriate one
    /// </summary>
    /// <param name="animation">Animation to grab</param>
    /// <param name="animator">The animator to get the Animations</param>
    /// <returns></returns>
    private static AnimatorControllerParameter getAnimatorControllerParameter(Animation animation, Animator animator) {
        AnimatorControllerParameter param;

        for(int i = 0; i < animator.parameters.Length; i++) {
            param = animator.parameters[i];

            if(param.name.Equals(animation.ToString())) {
                return param;
            }
        }

        return null;
    }

    /// <summary>
    /// Will set the Animation with the supplied parameter
    /// </summary>
    /// <param name="animation">The Animation to set</param>
    /// <param name="animator">The animator to get the Animations</param>
    /// <param name="parameter">The value for the Animation</param>
    public static void setAnimationTypeAndValue(Animation animation, Animator animator, object value) {

        if(value == null) {
            return;
        }

        //Grab what Type of parameter
        AnimatorControllerParameter param = getAnimatorControllerParameter(animation, animator);

        //If param doesn't exist, just get out
        if(param == null) {
            return;
        }

        switch(param.type) {
            case AnimatorControllerParameterType.Bool:
                animator.SetBool(animation.ToString(), (bool)value);
                break;
            case AnimatorControllerParameterType.Float:
                animator.SetFloat(animation.ToString(), (float)value);
                break;
            case AnimatorControllerParameterType.Int:
                animator.SetInteger(animation.ToString(), (int)value);
                break;
            case AnimatorControllerParameterType.Trigger:
                animator.SetTrigger(animation.ToString());
                break;
            default:
                break;
        }
    }
}
