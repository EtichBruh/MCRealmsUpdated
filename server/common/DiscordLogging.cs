using DiscordWebhook;

namespace common
{
    public class DiscordLogging
    {
        private bool Enabled;

        public DiscordLogging(bool enabled)
        {
            Enabled = enabled;
        }

        public void LogToDiscord(Webhook hook, string name, string content)
        {
            if (!Enabled) return;

            hook.PostData(new WebhookObject()
            {
                username = name,
                content = content
            });
        }
    }

    public class WebHooks
    {
        public static Webhook ChatLog = new Webhook("https://discord.com/api/webhooks/778397660334915595/ekWfD3d0EF7AUZt2idbxdcL1bqGfSFAwB9p947kincjs3AF0BUrpMWjeP4ZDv88oeYmN");
        public static Webhook ClientLog = new Webhook("https://discord.com/api/webhooks/779537586325946418/CypHUJ32o-Hz_J6vZg8ZhuJgTAiW-xAm_KoW18rcZ8uuIEYHHLc7mN-TYaJSqR7Lg4Ht");
        public static Webhook ModifiedClientLog = new Webhook("https://discord.com/api/webhooks/781179710922686504/NOE5_wLGKbvHF1UyU4qhCzTi9_YTro5BSXTmLBoH1R915IQl_tFHjeNz-0xCpS7How71");
    }
}