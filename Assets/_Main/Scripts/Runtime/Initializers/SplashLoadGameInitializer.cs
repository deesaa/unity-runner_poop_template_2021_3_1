using System;
using System.Collections.Generic;
using Game.SceneLoading;
using Game.Ui.SplashScreen.Impls;
using Runtime.Services.CommonPlayerData;
using Runtime.Services.CommonPlayerData.Data;
using SimpleUi.Signals;
using UnityEngine;
using Zenject;

namespace Initializers
{
    public class SplashLoadGameInitializer : IInitializable
    {
        private readonly SignalBus _signalBus;
        [Inject] private ICommonGameDataService<CommonGameData> _gameData;
        [Inject] private readonly ISceneLoadingManager _sceneLoadingManager;
        
        private int _updateVersionShot = 19; 

        public SplashLoadGameInitializer(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            var data = _gameData.GetData();

            DateTime firstPlayDate = data.GameData.ValueGameData.FirstPlayDate == DateTime.MinValue ? DateTime.Now : data.GameData.ValueGameData.FirstPlayDate;

           // Debug.Log(data.GameData.ValueGameData.UpdateVersionShot);
          // Debug.Log(_updateVersionShot);
            
            if (data.GameData.ValueGameData.UpdateVersionShot != _updateVersionShot)
            {
                PlayerPrefs.SetInt("StickTutorial", 1);
                _gameData.Remove();
                var newData = new CommonGameData()
                {
                    GameData = new GameDataComponent()
                    {
                        
                        ValueGameData = new ValueGameData()
                        {
                            FirstPlayDate = firstPlayDate,
                            UpdateVersionShot = _updateVersionShot
                        },
                        ReferenceGameData = new ReferenceGameData(null)
                    }
                };
                
                _gameData.Save(newData);
                data = newData;
            }
            
            _sceneLoadingManager.LoadScene($"Level_{data.GameData.ValueGameData.CurrentLevelIndex}");
        }
    }
}