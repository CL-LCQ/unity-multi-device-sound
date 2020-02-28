
# Unity Multi Dvice Sound Player

This is an asset that outputs sound from multiple sound card devices.

## Support

#### OS
- OSX 10.13

#### Platform
- Unity 2019


## Usage

#### Install
1. Open UnityPackge.


#### Method

##### Generate instance

`MultiDeviceSoundManager soundPlayer = new MultiDeviceSoundManager();`

##### Get deveice list

`string deviceList = soundPlayer.GetDveice(int systemID);`	

##### Load
	
`soundPlayer.Load(string filePath, int deviceIndex);`

##### Play

`soundPlayer.Play();`


## Features

- Get device list.
- Load sound file.
- Select sound device.
- Play sound file.

This asset is licensed under MIT license.  
This asset is using FMOD.  
FMOD dynamic libraries are licensed under **FMOD's non-commercial license.**
