using System;
using System.Collections.Generic;

namespace TrouvailleFrontend.Shared.Classes.Functional {
    public class GlobalStateManager {
        private Dictionary<Type, object> _state = new();

        public T Get<T>() {
            return (T)_state[typeof(T)];
        }

        public void Add<T>(T value) {
            if (_state.ContainsKey(typeof(T))) {
                _state[typeof(T)] = value;
            } else {
                _state.Add(typeof(T), value);
            }
        }
    }
}