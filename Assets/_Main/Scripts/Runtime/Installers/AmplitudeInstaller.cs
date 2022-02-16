using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runtime.Installers
{
    public class AmplitudeInstaller : MonoInstaller
    {
        [SerializeField] private string apiKey;
        public override void InstallBindings()
        {
            var amplitude = Amplitude.Instance;
            amplitude.logging = true;
            amplitude.init(apiKey);
            

            int count = PlayerPrefs.GetInt("GameStartCount", 0);
            count += 1;
            PlayerPrefs.SetInt("GameStartCount", count);
            PlayerPrefs.Save();
            
            Amplitude.Instance.logEvent("game_start", new Dictionary<string, object>()
            {
                {"count", count}
            });
            
            Amplitude.Instance.setUserProperty("session_count", count);
        }
    }
}