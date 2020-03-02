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

        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_play")]
        private static extern void NativePlay(IntPtr instance);

        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_loadSoundWithTarget")]
        private static extern int NativeLoad(IntPtr instance, string fileName, int deviceID);

        [DllImport ("MultiDeviceSoundPlayer", EntryPoint="MultiSoundDviceInterface_getDeviceInfo")]
        private static extern string NativeGetDevice(IntPtr instance, int deviceID);

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

        public string GetDveice(int id){
            if (IsDestroyed()) {
                return "Instance does not exist.";
            }
            return NativeGetDevice(_instance, id);
        }
    }
}
