using UnityEngine;

namespace Input.Provider
{
    public interface IInputProvider<out T> where T : struct
    {
        public T GetInputFrame();

        public void ConsumeInput() {}
    }
}