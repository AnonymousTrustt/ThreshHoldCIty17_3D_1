using Input.Utility;
using UnityEngine;

namespace Input.Provider
{
    public interface IMotor<in T> where T : IConsumable 
    {
        public void Tick(T inputFrame);
    }
}
