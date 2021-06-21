using System;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrouvailleFrontend.Shared.Classes.Interfaces;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class LocalStorage : ILocalStorage {
        private IJSRuntime _JSRuntime;
        public LocalStorage(IJSRuntime JSRuntime) {
            _JSRuntime = JSRuntime;
        }

        public async Task<T> GetStorageAsync<T>(string key) {

            T _localStorage;
            var jsonString = await _JSRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (jsonString == null) {
                if (typeof(T).IsGenericType) {
                    if (typeof(T).GetGenericTypeDefinition() == typeof(List<>)) {
                        //await _JSRuntime.InvokeAsync<string>("console.log", "TYPE: LIST");
                        jsonString = "[]";
                    }
                } else {
                    //await _JSRuntime.InvokeAsync<string>("console.log", "TYPE: SIMPLE OBJECT");
                    jsonString = "{}";
                }
                Console.WriteLine("GetStorageAsync(): Either the Key: " + key + " or its Value does not exist");
            }

            Console.WriteLine(jsonString);

            _localStorage = JsonSerializer.Deserialize<T>(jsonString);

            return _localStorage;
        }


        public async Task SetStorageAsync<T>(string key, T value) {

            await _JSRuntime.InvokeAsync<string>("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }


        public async Task RemoveStorageAsync(string key) {
            await _JSRuntime.InvokeAsync<string>("localStorage.removeItem", key);
        }


        /*
        public async Task ClearStorageAsync() {
            await _JSRuntime.InvokeAsync<string>("localStorage.clear");
        }
        */


        public async Task<int> LengthStorageAsync() {
            int length = await _JSRuntime.InvokeAsync<int>("eval", "localStorage.length");
            return length;
        }


    }



}