
# Unity Multi Dvice Sound Player

This is an asset that outputs sound from multiple sound card devices.  

Referenced http://forum.openframeworks.cc/t/multi-device-targeting-with-fmod/951

## Support

### OS
- OSX 10.13

### Platform
- Unity 2019


## Usage

### Install
1. Open UnityPackge.


### Method

#### Generate instance

`MultiDeviceSoundManager soundPlayer = new MultiDeviceSoundManager();`

#### Get deveice list

`string deviceList = soundPlayer.GetDveice(int systemID);`	

List update requires a restrt of Unity.

#### Load
	
`soundPlayer.Load(string filePath, int deviceIndex);`

#### Play

`soundPlayer.Play();`

#### Stop

`soundPlayer.Stop();`


## Features

- Get device list
- Select device
- Play 
- Stop
- Pause
- Volume
- Speed
- Pan  
etc...
  

This asset is licensed under MIT license.  
This asset is using FMOD.  
FMOD dynamic libraries are licensed under **FMOD's non-commercial license.**
