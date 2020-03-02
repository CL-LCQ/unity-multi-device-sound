using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MultiDeviceSoundPlayer;

public class SoundManager : MonoBehaviour{

    MultiDeviceSoundManager soundPlayer;
    MultiDeviceSoundManager soundPlayer2;

    [SerializeField]Text deviceList;

    // Start is called before the first frame update
    void Start(){
        soundPlayer = new MultiDeviceSoundManager();
        soundPlayer2 = new MultiDeviceSoundManager();

        deviceList.text = "deviceList:\n" + soundPlayer.GetDveice(0);


        soundPlayer.Load(Application.streamingAssetsPath + "/Audios/test1.mp3", 0);        
        soundPlayer2.Load(Application.streamingAssetsPath + "/Audios/test2.mp3", 0);

    }

    // Update is called once per frame
    void Update(){

        if(Input.GetKeyDown(KeyCode.Alpha0)){
            soundPlayer.Play();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            soundPlayer2.Play();
        }
    }

    private void OnApplicationQuit(){
        soundPlayer.Destroy();
        soundPlayer2.Destroy();
    }
}
