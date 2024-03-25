using System;
namespace StoryFront
{
    public static class SD
    {
        public static string storyAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}

