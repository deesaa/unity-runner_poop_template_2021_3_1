using DataBase.Game;

public interface IGameStageService
{
    public void ChangeStage(EGameStage stage, float transitionTime = 0f);
    public EGameStage CurrentStage { get; }
}