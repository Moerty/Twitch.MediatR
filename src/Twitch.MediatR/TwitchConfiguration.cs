namespace BenjaminAbt.Twitch.MediatR {
    public class TwitchConfiguration {
        public string UserName { get; set; }
        public string AccessToken { get; set; }

        public string[] Channels { get; set; }
    }
}