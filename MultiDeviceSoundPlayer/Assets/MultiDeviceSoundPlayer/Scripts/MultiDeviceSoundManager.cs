using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace MultiDeviceSoundPlayer {

    public class MultiDeviceSoundManager {

        private IntPtr _instance;

        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_create")]
        private static extern IntPtr NativeCreate();
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_destroy")]
        private static extern void NativeDestroy(IntPtr instance);

        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_loadSoundWithTarget")]
        private static extern int NativeLoad(IntPtr instance, string fileName, int deviceID);
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_getDeviceInfo")]
        private static extern string NativeGetDevice(IntPtr instance, int deviceID);
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_play")]
        private static extern void NativePlay(IntPtr instance);
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_stop")]
        private static extern void NativeStop(IntPtr instance);


        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_getPan")]
        private static extern float NativeGetPan(IntPtr instance);
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_getSpeed")]
        private static extern float NativeGetSpeed(IntPtr instance);
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_getPosition")]
        private static extern float NativeGetPosition(IntPtr instance);
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_getIsPlaying")]
        private static extern bool NativeIsPlaying(IntPtr instance);

        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_setPaused")]
        private static extern void NativeSetPaused(IntPtr instance, bool isPaused);
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_setLoop")]
        private static extern void NativeSetLoop(IntPtr instance, bool isLoop);
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_setVolume")]
        private static extern void NativeSetVolume(IntPtr instance, float vol);
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_setSpeed")]
        private static extern void NativeSetSpeed(IntPtr instance, float speed);
        
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_setPosition")]
        private static extern void NativeSetPosition(IntPtr instance, float pos);
        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_setPan")]
        private static extern void NativeSetPan(IntPtr instance, float pan);


        public MultiDeviceSoundManager() {
            _instance = NativeCreate();
        }

        public void Destroy() {
            if (IsDestroyed()) {
                return;
            }
            NativeDestroy(_instance);
            _instance = IntPtr.Zero;
        }

        private bool IsDestroyed() {
            return _instance == IntPtr.Zero;
        }

        public string GetDveice(int id){
            if (IsDestroyed()) {
                return "Instance does not exist.";
            }
            return NativeGetDevice(_instance, id);
        }

        public int Load(string fileName, int deviceID) {
            if (IsDestroyed()) {
                return -1;
            }
            return NativeLoad(_instance, fileName, deviceID);
        }

        public void Play() {
            if (IsDestroyed()) {
                return;
            }
            NativePlay(_instance);
        }

        public void Stop() {
            if (IsDestroyed()) {
                return;
            }
            NativeStop(_instance);
        }

        public float GetPan() {
            if (IsDestroyed()) {
                return -1;
            }
            return NativeGetPan(_instance);
        }
        public float GetSpeed() {
            if (IsDestroyed()) {
                return -1;
            }
            return NativeGetSpeed(_instance);
        }
        public float GetPosition() {
            if (IsDestroyed()) {
                return -1;
            }
            return NativeGetPosition(_instance);
        }
        public bool IsPlaying() {
            if (IsDestroyed()) {
                return false;
            }
            return NativeIsPlaying(_instance);
        }

        public void Paused(bool isPaused) {
            if (IsDestroyed()) {
                return;
            }
            NativeSetPaused(_instance, isPaused);
        }

        public void SetLoop(bool isLoop) {
            if (IsDestroyed()) {
                return;
            }
            NativeSetLoop(_instance, isLoop);
        }

        public void SetVolume( float vol) {
            if (IsDestroyed()) {
                return;
            }
            NativeSetVolume(_instance, vol);
        }

        public void SetSpeed( float speed) {
            if (IsDestroyed()) {
                return;
            }
            NativeSetSpeed(_instance, speed);
        }

        public void SetPosition( float pos) {
            if (IsDestroyed()) {
                return;
            }
            NativeSetPosition(_instance, pos);
        }

        public void SetPan( float pan) {
            if (IsDestroyed()) {
                return;
            }
            NativeSetPan(_instance, pan);
        }
    }
}
