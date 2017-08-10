using UnityEngine;
using System;

public class ConfigManager : MonoBehaviour
{

    WorkerConfig worker;

    [Serializable]
    struct WorkerConfig
    {
        public float bedTimeout;

        public WorkerConfig(float bedTimeout)
        {
            this.bedTimeout = bedTimeout;
        }
    }

}