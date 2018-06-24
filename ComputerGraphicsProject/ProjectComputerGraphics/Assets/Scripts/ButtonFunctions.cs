using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject postProcCamera;

    private UnityEngine.PostProcessing.PostProcessingBehaviour postProcBehaviour;
    // Use this for initialization
    void Start()
    {
        postProcBehaviour = postProcCamera.GetComponent<UnityEngine.PostProcessing.PostProcessingBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFogClick()
    {
        if (!postProcBehaviour.profile.fog.enabled)
            postProcBehaviour.profile.fog.enabled = true;
        else
            postProcBehaviour.profile.fog.enabled = false;
    }


    public void OnAntiAliasingClick()
    {
        if (!postProcBehaviour.profile.antialiasing.enabled)
            postProcBehaviour.profile.antialiasing.enabled = true;
        else
            postProcBehaviour.profile.antialiasing.enabled = false;
    }

    public void OnAmbientOcclusionClick()
    {
        if (!postProcBehaviour.profile.ambientOcclusion.enabled)
            postProcBehaviour.profile.ambientOcclusion.enabled = true;
        else
            postProcBehaviour.profile.ambientOcclusion.enabled = false;
    }

    public void OnScreenSpaceReflectionClick()
    {
        if (!postProcBehaviour.profile.screenSpaceReflection.enabled)
            postProcBehaviour.profile.screenSpaceReflection.enabled = true;
        else
            postProcBehaviour.profile.screenSpaceReflection.enabled = false;
    }

    public void OnDepthOfFieldClick()
    {
        if (!postProcBehaviour.profile.depthOfField.enabled)
            postProcBehaviour.profile.depthOfField.enabled = true;
        else
            postProcBehaviour.profile.depthOfField.enabled = false;
    }

    public void OnMotionBlurClick()
    {
        if (!postProcBehaviour.profile.motionBlur.enabled)
            postProcBehaviour.profile.motionBlur.enabled = true;
        else
            postProcBehaviour.profile.motionBlur.enabled = false;
    }

    public void OnEyeAdaptionClick()
    {
        if (!postProcBehaviour.profile.eyeAdaptation.enabled)
            postProcBehaviour.profile.eyeAdaptation.enabled = true;
        else
            postProcBehaviour.profile.eyeAdaptation.enabled = false;
    }

    public void OnBloomClick()
    {
        if (!postProcBehaviour.profile.bloom.enabled)
            postProcBehaviour.profile.bloom.enabled = true;
        else
            postProcBehaviour.profile.bloom.enabled = false;
    }

    public void OnColorGradingClick()
    {
        if (!postProcBehaviour.profile.colorGrading.enabled)
            postProcBehaviour.profile.colorGrading.enabled = true;
        else
            postProcBehaviour.profile.colorGrading.enabled = false;
    }

    public void OnUserLutClick()
    {
        if (!postProcBehaviour.profile.userLut.enabled)
            postProcBehaviour.profile.userLut.enabled = true;
        else
            postProcBehaviour.profile.userLut.enabled = false;
    }

    public void OnChromaticAberrationClick()
    {
        if (!postProcBehaviour.profile.chromaticAberration.enabled)
            postProcBehaviour.profile.chromaticAberration.enabled = true;
        else
            postProcBehaviour.profile.chromaticAberration.enabled = false;
    }

    public void OnGrainClick()
    {
        if (!postProcBehaviour.profile.grain.enabled)
            postProcBehaviour.profile.grain.enabled = true;
        else
            postProcBehaviour.profile.grain.enabled = false;
    }

    public void OnVignetteClick()
    {
        if (!postProcBehaviour.profile.vignette.enabled)
            postProcBehaviour.profile.vignette.enabled = true;
        else
            postProcBehaviour.profile.vignette.enabled = false;
    }

    public void OnDitheringClick()
    {
        if (!postProcBehaviour.profile.dithering.enabled)
            postProcBehaviour.profile.dithering.enabled = true;
        else
            postProcBehaviour.profile.dithering.enabled = false;
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
