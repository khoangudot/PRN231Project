using System;
using System.Security.AccessControl;
using static StoryFront.SD;

namespace StoryFront
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}

