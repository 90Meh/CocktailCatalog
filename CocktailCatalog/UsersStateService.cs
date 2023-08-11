using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailCatalog
{
    internal class UsersStateService
    {
        public enum UserState
        {
            NoState, ChatGPT, DALLE, Привет
        }
        // Dictionary не потокобезопасный. Но в нашем случае это не проблема.
        // ConcurrentDictionary - потокобезопасный аналог Dictionary.
        // В идеале - персистентное хранилище, например, база данных.
        private readonly Dictionary<long, UserState> _usersState = new();

        public void SetState(long userId, UserState state)
        {
            _usersState[userId] = state;
        }

        public UserState GetState(long userId)
        {
            if (_usersState.TryGetValue(userId, out var state))
            {
                return state;
            }
            else
            {
                return UserState.NoState;
            }
        }
    }
}
