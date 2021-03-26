using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrumBandsVis : MonoBehaviour
{
    [Tooltip(" theres 8 different frequency bands. From 0 to 7")]
    public int _band;
    public float _yStartScale, _scaleMultiplier;
    public bool useBuffer;
    public enum _channel
    {
        left,
        right
    };
    public _channel Channel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (useBuffer)
        {
            if (Channel == _channel.left)
                transform.localScale = new Vector3 (transform.localScale.x, (AudioSpectrum._bandBufferLeft[_band] * _scaleMultiplier) + _yStartScale, transform.localScale.z);
            else if (Channel == _channel.right)
                transform.localScale = new Vector3 (transform.localScale.x, (AudioSpectrum._bandBufferRight[_band] * _scaleMultiplier) + _yStartScale, transform.localScale.z);            
        }
        else 
        {
            if (Channel == _channel.left)
                transform.localScale = new Vector3 (transform.localScale.x, (AudioSpectrum._freqBandLeft[_band] * _scaleMultiplier) + _yStartScale, transform.localScale.z);
            else if (Channel == _channel.right)
                transform.localScale = new Vector3 (transform.localScale.x, (AudioSpectrum._freqBandRight[_band] * _scaleMultiplier) + _yStartScale, transform.localScale.z); 
        }
    }
}