using System;
using System.Collections.Generic;
using Code.Gameplay.Features.AnimationEvents.Configs;
using UnityEditor.Animations;

namespace Code.Gameplay.Features.Animations.Configs
{
    [Serializable]
    public class AnimationSetup
    {
        public AnimatorController AnimatorController;
        public string Name;
        public AnimationTypeId AnimationTypeId;
        public float LastFrame;
        public float AnimationSpeed;
        public float MovementSpeed;
        public List<AnimationEventConfig> AnimationEventConfigs;
        public List<string> StateNames;

        public AnimationSetup(AnimationTypeId typeId, float speed, string name)
        {
            AnimationTypeId = typeId;
            AnimationSpeed = speed;
            Name = name;
        }

        public static AnimationSetup Create(AnimationTypeId typeId, float speed, string name)
        {
            return new AnimationSetup(typeId, speed, name);
        }

        public void Initialize()
        {
            if(!AnimatorController)
                return;
            
            foreach (var state in AnimatorController.layers[0].stateMachine.states)
            {
                if (!StateNames.Contains(state.state.name))
                    StateNames.Add(state.state.name);
            }
        }
    }
}
