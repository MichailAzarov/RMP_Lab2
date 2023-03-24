using UnityEngine;
using UnityEngine.Android;
using System.Collections;
using UnityEngine.UI;
using System;

public class StaticMap : MonoBehaviour
{
    [SerializeField] private Text _locationText;
    [SerializeField] private RawImage _image;

    private string _latitude;
    private string _longitude;
    private string _one = "https://maps.googleapis.com/maps/api/staticmap?center=";
    private string _two = "%2c%20";
    private string _three = "&zoom=16&size=720x1280&key=AIzaSyAWF1sLm8Z3kHXxAGScc7ivws1VnNLIeMQ";

    
    IEnumerator Start()
    {
        


        if (!Input.location.isEnabledByUser)
            yield break;
        Input.location.Start();

        
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
           
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            _latitude = Convert.ToString(Input.location.lastData.latitude);
            _longitude = Convert.ToString(Input.location.lastData.longitude);
            using (WWW www = new WWW(_one + _latitude + _two + _longitude + _three))
            {
                // Wait for download to complete
                yield return www;


                _image.material.mainTexture = www.texture;
                _image.gameObject.SetActive(false);
                _image.gameObject.SetActive(true);
            }
        }
        _locationText.text = "Широта: " + _latitude + "\nДолгота: " + _longitude;
        Input.location.Stop();
        
    }

}

