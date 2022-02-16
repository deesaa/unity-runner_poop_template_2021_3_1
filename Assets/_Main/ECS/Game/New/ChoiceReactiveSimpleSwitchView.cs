using System.Collections.Generic;
using Leopotam.Ecs;


public class ChoiceReactiveSimpleSwitchView : ChoiceReactiveView, IReinitializable
{
    public EGameChoice CurrentChoice = EGameChoice.Null;
    public List<ChoiceReactiveSwitchElement> ChoiceReactiveSwitchElements;

    private bool _isSwitched;
    
    public override void Link(EcsEntity entity)
    {
        base.Link(entity);

        foreach (var switchElement in ChoiceReactiveSwitchElements)
            switchElement.GameObject.SetActive(false);

        if(CurrentChoice != EGameChoice.Null)
            ChoiceReactiveSwitchElements.Find(x => x.Choice == CurrentChoice).GameObject.SetActive(true);
    }

    public override void OnChoice(EGameChoice choice)
    {
        if(_isSwitched)
            return;
        
        if (CurrentChoice != EGameChoice.Null)
        {
            if(ChoiceReactiveSwitchElements.Exists(x => x.Choice == CurrentChoice))
                ChoiceReactiveSwitchElements.Find(x => x.Choice == CurrentChoice).GameObject.SetActive(false);
        }
        if (choice != EGameChoice.Null)
        {
            if (ChoiceReactiveSwitchElements.Exists(x => x.Choice == choice))
            {
                ChoiceReactiveSwitchElements.Find(x => x.Choice == choice).GameObject.SetActive(true);
                CurrentChoice = choice;
                _isSwitched = true;
            }
        }
    }

    public void Reinitialize()
    {
        CurrentChoice = EGameChoice.Null;
        _isSwitched = false;
        foreach (var switchElement in ChoiceReactiveSwitchElements)
            switchElement.GameObject.SetActive(false);
    }
}