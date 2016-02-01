using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class camera : MonoBehaviour {
    private AudioListener audioListener;

    SerialPort stream = new SerialPort("COM3", 250000);

    float lastPosX;
    float lastPosY;
    float lastPosZ;
    float lastRotHeading;
    float lastRotPitch;
    float lastRotRoll;

    float threshold = 5;

    float rotHeading = 0;
    float rotPitch = 0;
    float rotRoll = 0;

    // Use this for initialization
    void Start () {
        audioListener = GetComponent<AudioListener>();

        stream.Open(); //Open the Serial Stream.

        //string value = stream.ReadLine(); //Read the information
        //value = stream.ReadLine(); //Read the information
        //value = stream.ReadLine(); //Read the information
        //if (value != "")
        //{
        //    string[] vec12 = value.Split(',');

        //    // translate using A
        //    // transform.Translate(float.Parse(vec12[3]), float.Parse(vec12[4]), float.Parse(vec12[5]), Space.World);
        //    initPosX = float.Parse(vec12[3]);
        //    initPosY = float.Parse(vec12[4]);
        //    initPosZ = float.Parse(vec12[5]);

        //    // rotate using heading, pitch, roll
        //    float scale = 3.1415926f / 180.00f;
        //    initRotHeading = float.Parse(vec12[9]) * scale;
        //    initRotPitch = float.Parse(vec12[10]) * scale;
        //    initRotRoll = float.Parse(vec12[11]) * scale;
        //}
    }
	
	// Update is called once per frame
	void Update () {
        string value = stream.ReadLine(); //Read the information
        if (value != "")
        {
            string[] vec12 = value.Split(',');

            // translate using A
            //float positionScale = 0.1f;
            //float newPosX = float.Parse(vec12[3]) * positionScale;
            //float newPosY = float.Parse(vec12[4]) * positionScale;
            //float newPosZ = float.Parse(vec12[5]) * positionScale;

            //transform.Translate(newPosX - lastPosX, newPosY - lastPosY, newPosZ - lastPosZ);

            //lastPosX = newPosX;
            //lastPosY = newPosY;
            //lastPosZ = newPosY;

            //Debug.Log(value);

            // rotate using heading, pitch, roll
            float scale = 0.01f; // 3.1415926f / 180.00f;
            //float rotHeading = float.Parse(vec12[9]) * scale;
            //float rotPitch = float.Parse(vec12[10]) * scale;
            //float rotRoll = float.Parse(vec12[11]) * scale;



            lastRotHeading = rotHeading;
            lastRotPitch = rotPitch;
            lastRotRoll = rotRoll;

            rotHeading = float.Parse(vec12[0]) * scale;
            rotPitch = float.Parse(vec12[1]) * scale;
            rotRoll = float.Parse(vec12[2]) * scale;

            if (Mathf.Abs(rotHeading) < threshold)
            {
                rotHeading = lastRotHeading;
            }
            if (Mathf.Abs(rotPitch) < threshold)
            {
                rotPitch = lastRotPitch;
            }
            if (Mathf.Abs(rotRoll) < threshold)
            {
                rotHeading = lastRotRoll;
            }

            //transform.Rotate(rotHeading - lastRotHeading, rotPitch - lastRotPitch, rotRoll - lastRotRoll, Space.World);
            transform.Rotate(rotHeading, rotPitch, rotRoll, Space.World);


        }
        stream.BaseStream.Flush();


    }
}
