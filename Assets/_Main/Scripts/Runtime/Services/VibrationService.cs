using Zenject;

namespace _Main.Scripts.Runtime.Services
{
    public class VibrationService : IInitializable
    {
        public void Initialize() { }

        public void Vibrate(ValueGameData playerData, long mlseconds)
        {
            if(playerData.DisabledVibration)
                return;
            
            Vibration.Vibrate(mlseconds);
        }
    }
}