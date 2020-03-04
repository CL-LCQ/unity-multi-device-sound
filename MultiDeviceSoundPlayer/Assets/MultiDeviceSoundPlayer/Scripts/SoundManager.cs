using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MultiDeviceSoundPlayer;

public class SoundManager : MonoBehaviour{

    MultiDeviceSoundManager soundPlayer;
    MultiDeviceSoundManager soundPlayer2;

    [SerializeField]Text deviceList;

    [SerializeField] Slider volome;

    // Start is called before the first frame update
    void Start(){
        soundPlayer = new MultiDeviceSoundManager();
        soundPlayer2 = new MultiDeviceSoundManager();

        deviceList.text = "deviceList:\n" + soundPlayer.GetDveice(0);

        soundPlayer.SetLoop(true);
        soundPlayer.Load(Application.streamingAssetsPath + "/Audios/bgm_maoudamashii_8bit26.mp3", 0);        
        soundPlayer2.Load(Application.streamingAssetsPath + "/Audios/se_maoudamashii_chime11.mp3", 1);

        volome.onValueChanged.AddListener(ChangeVolume);

    }

    // Update is called once per frame
    void Update(){

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            soundPlayer.Play();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            soundPlayer2.Play();
        }

        if(Input.GetKeyDown(KeyCode.Alpha9)){
            soundPlayer.Paused(true);
        }
        if(Input.GetKeyUp(KeyCode.Alpha9)){
            soundPlayer.Paused(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha0)){
            soundPlayer2.Stop();
        }
    }

    void ChangeVolume(float vol){
        soundPlayer.SetVolume(vol);
    }

    private void OnApplicationQuit(){
        soundPlayer.Destroy();
        soundPlayer2.Destroy();
    }
}
