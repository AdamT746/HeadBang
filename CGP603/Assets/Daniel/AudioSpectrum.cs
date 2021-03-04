using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioSpectrum : MonoBehaviour
{
    AudioSource _audioSourceLeft, _audioSourceRight;
    public static float[] _samplesLeft = new float[512];
    public static float[] _samplesRight = new float[512];
    public static float[] _freqBandLeft = new float[8];
    public static float[] _freqBandRight = new float[8];
    public static float[] _bandBufferLeft = new float[8];
    public static float[] _bandBufferRight = new float[8];
    public float[] _bufferDecreaseLeft = new float[8];
    public float[] _bufferDecreaseRight = new float[8];
    [Range(1.1f,2f)]
    public float bufferStrenght = 1.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        _audioSourceLeft = GetComponent<AudioSource>();
        _audioSourceRight = GetComponent<AudioSource>();       
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSourceLeft();
        GetSpectrumAudioSourceRight();
        FrequencyBandsLeft();
        FrequencyBandsRight();
        BandBuffer();
    }


    void GetSpectrumAudioSourceLeft()
    {
        _audioSourceLeft.GetSpectrumData(_samplesLeft, 0, FFTWindow.Blackman);
    }
    void GetSpectrumAudioSourceRight()
    {
        _audioSourceRight.GetSpectrumData(_samplesRight, 1, FFTWindow.Blackman);
    }
    void FrequencyBandsLeft()
    {
        /*
        * 22050 / 512 = 43Hz per sample
        * 20 - 60 Hz
        * 250 - 500 Hz
        * 500 - 2000 Hz
        * 2000 - 4000 Hz
        * 6000 - 20000 Hz
        
            0 - 2 = 86 Hz
            1 - 4 = 172 HZ     + 86 = 258 
            2 - 8 = 344 Hz       259 - 602 
            3 - 16 = 688 Hz      603 - 1290
            4 - 32 = 1376 Hz     1291 -2666
            5 - 64 = 2752 HZ     2667 - 5418
            6 - 128 = 5504 Hz    5419 - 10922
            7 - 258 = 11008 Hz   10923  - 21930
        */

        int count = 0;
        
        for (int i = 0; i < 8; i++)
        {
            int sampleCount = (int)Mathf.Pow(2,i) * 2;

            float average = 0;
            if (i == 7)
                sampleCount +=2;

            for (int j = 0; j < sampleCount; j++)
            {
                average += _samplesLeft[count] * (count + 1);
                count++;
            }

            average /= count;
            _freqBandLeft[i] = average * 10;
        }
    }
    void FrequencyBandsRight()
    {
        /*
        * 22050 / 512 = 43Hz per sample
        * 20 - 60 Hz
        * 250 - 500 Hz
        * 500 - 2000 Hz
        * 2000 - 4000 Hz
        * 6000 - 20000 Hz
        
            0 - 2 = 86 Hz
            1 - 4 = 172 HZ     + 86 = 258 
            2 - 8 = 344 Hz       259 - 602 
            3 - 16 = 688 Hz      603 - 1290
            4 - 32 = 1376 Hz     1291 -2666
            5 - 64 = 2752 HZ     2667 - 5418
            6 - 128 = 5504 Hz    5419 - 10922
            7 - 258 = 11008 Hz   10923  - 21930
        */

        int count = 0;
        
        for (int i = 0; i < 8; i++)
        {
            int sampleCount = (int)Mathf.Pow(2,i) * 2;

            float average = 0;
            if (i == 7)
                sampleCount +=2;

            for (int j = 0; j < sampleCount; j++)
            {
                average += _samplesRight[count] * (count + 1);
                count++;
            }

            average /= count;
            _freqBandRight[i] = average * 10;
        }
    }
    void BandBuffer()
    {
        for (int b = 0; b < 8; b++)
        {
            if (_freqBandLeft[b] > _bandBufferLeft[b])
            {
                _bandBufferLeft[b] = _freqBandLeft[b];
                _bufferDecreaseLeft[b] = 0.005f;
            }
            
            else if (_freqBandLeft[b] < _bandBufferLeft[b])
            {
                _bandBufferLeft[b] -= _bufferDecreaseLeft[b];
                _bufferDecreaseLeft[b] *= bufferStrenght;
            }

            if (_freqBandRight[b] > _bandBufferRight[b])
            {
                _bandBufferRight[b] = _freqBandRight[b];
                _bufferDecreaseRight[b] = 0.005f;
            }
            
            else if (_freqBandRight[b] < _bandBufferRight[b])
            {
                _bandBufferRight[b] -= _bufferDecreaseRight[b];
                _bufferDecreaseRight[b] *= bufferStrenght;
            }

        }
    }
}
