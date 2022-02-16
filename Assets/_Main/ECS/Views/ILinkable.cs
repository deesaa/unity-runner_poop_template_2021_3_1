﻿using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Views
{
    public interface ILinkable
    {
        int Hash { get; }
        Transform Transform { get; }
        int UnityInstanceId { get; }
        void Link(EcsEntity entity);
        void Destroy();
    }
}