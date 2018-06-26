/*
    ButtonFunstions.cs
    
    Purpose: Has all of the GUI button scripts in here.
            This script gets stored on an empty game object
            and the empty game object is used to get the 
            functions from.

    @author Nathan Nette
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The ButtonFunctions class stores all of the functions
        that will be called when specific buttons on the UI
        is clicked.
 */
public class ButtonFunctions : MonoBehaviour
{
    // Gets a copy of the camera to access the post-processing effects.
    public GameObject postProcCamera;

    // Creating a post-processing behaviour to store it in.
    private UnityEngine.PostProcessing.PostProcessingBehaviour postProcBehaviour;

    // Use this for initialization.
    void Start()
    {
        // Cache the camera's post processing behaviour into the one created above.
        postProcBehaviour = postProcCamera.GetComponent<UnityEngine.PostProcessing.PostProcessingBehaviour>();
    }

    /*
        This function turns off the Fog effect on the post processing behaviour that's connected to the camera.
    */
    public void OnFogClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.fog.enabled)
            postProcBehaviour.profile.fog.enabled = true;
        else
            postProcBehaviour.profile.fog.enabled = false;
    }

    /*
       This function turns off the AntiAliasing effect on the post processing behaviour that's connected to the camera.
   */
    public void OnAntiAliasingClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.antialiasing.enabled)
            postProcBehaviour.profile.antialiasing.enabled = true;
        else
            postProcBehaviour.profile.antialiasing.enabled = false;
    }

    /*
       This function turns off the Ambient Occlusion effect on the post processing behaviour that's connected to the camera.
   */
    public void OnAmbientOcclusionClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.ambientOcclusion.enabled)
            postProcBehaviour.profile.ambientOcclusion.enabled = true;
        else
            postProcBehaviour.profile.ambientOcclusion.enabled = false;
    }

    /*
       This function turns off the On Screen Space Reflection effect on the post processing behaviour that's connected 
            to the camera.
   */
    public void OnScreenSpaceReflectionClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.screenSpaceReflection.enabled)
            postProcBehaviour.profile.screenSpaceReflection.enabled = true;
        else
            postProcBehaviour.profile.screenSpaceReflection.enabled = false;
    }

    /*
       This function turns off the Depth of Field effect on the post processing behaviour that's connected to the camera.
   */
    public void OnDepthOfFieldClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.depthOfField.enabled)
            postProcBehaviour.profile.depthOfField.enabled = true;
        else
            postProcBehaviour.profile.depthOfField.enabled = false;
    }

    /*
       This function turns off the Motion Blur effect on the post processing behaviour that's connected to the camera.
   */
    public void OnMotionBlurClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.motionBlur.enabled)
            postProcBehaviour.profile.motionBlur.enabled = true;
        else
            postProcBehaviour.profile.motionBlur.enabled = false;
    }

    /*
       This function turns off the Eye Adaption effect on the post processing behaviour that's connected to the camera.
   */
    public void OnEyeAdaptionClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.eyeAdaptation.enabled)
            postProcBehaviour.profile.eyeAdaptation.enabled = true;
        else
            postProcBehaviour.profile.eyeAdaptation.enabled = false;
    }

    /*
       This function turns off the Bloom effect on the post processing behaviour that's connected to the camera.
   */
    public void OnBloomClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.bloom.enabled)
            postProcBehaviour.profile.bloom.enabled = true;
        else
            postProcBehaviour.profile.bloom.enabled = false;
    }

    /*
       This function turns off the Colour Grading effect on the post processing behaviour that's connected to the camera.
   */
    public void OnColorGradingClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.colorGrading.enabled)
            postProcBehaviour.profile.colorGrading.enabled = true;
        else
            postProcBehaviour.profile.colorGrading.enabled = false;
    }

    /*
       This function turns off the User Lut effect on the post processing behaviour that's connected to the camera.
   */
    public void OnUserLutClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.userLut.enabled)
            postProcBehaviour.profile.userLut.enabled = true;
        else
            postProcBehaviour.profile.userLut.enabled = false;
    }

    /*
       This function turns off the Chromatic Aberration effect on the post processing behaviour that's connected to the camera.
   */
    public void OnChromaticAberrationClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.chromaticAberration.enabled)
            postProcBehaviour.profile.chromaticAberration.enabled = true;
        else
            postProcBehaviour.profile.chromaticAberration.enabled = false;
    }

    /*
       This function turns off the Grain effect on the post processing behaviour that's connected to the camera.
   */
    public void OnGrainClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.grain.enabled)
            postProcBehaviour.profile.grain.enabled = true;
        else
            postProcBehaviour.profile.grain.enabled = false;
    }

    /*
       This function turns off the Vignette effect on the post processing behaviour that's connected to the camera.
   */
    public void OnVignetteClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.vignette.enabled)
            postProcBehaviour.profile.vignette.enabled = true;
        else
            postProcBehaviour.profile.vignette.enabled = false;
    }

    /*
       This function turns off the Dithering effect on the post processing behaviour that's connected to the camera.
   */
    public void OnDitheringClick()
    {
        // A basic toggle of if it's not enabled, enable it.
        if (!postProcBehaviour.profile.dithering.enabled)
            postProcBehaviour.profile.dithering.enabled = true;
        else
            postProcBehaviour.profile.dithering.enabled = false;
    }

    /*
        When the quit button is clicked, it closes the application.
     */
    public void OnExitClick()
    {
        Application.Quit();
    }
}
