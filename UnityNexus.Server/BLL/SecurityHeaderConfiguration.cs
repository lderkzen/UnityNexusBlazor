using NetEscapades.AspNetCore.SecurityHeaders.Headers.ContentSecurityPolicy;

namespace UnityNexus.Server.BLL
{
    internal static class SecurityHeaderConfiguration
    {
        internal static void Configure(
            this HeaderPolicyCollection collection,
            bool IsDevelopment
        )
        {
            collection.AddReferrerPolicyNoReferrer();
            collection.RemoveServerHeader();
            collection.AddContentSecurityPolicy(builder =>
            {
                builder.AddObjectSrc().None();
                ImageSourceDirectiveBuilder imageSrc = builder.AddImgSrc()
                    .Self()
                    // Required for SVGs.
                    .From("data:")
                    .From("cdn.discordapp.com");
                ScriptSourceDirectiveBuilder scriptSrc = builder.AddScriptSrc()
                    .Self()
                    .From("stackpath.bootstrapcdn.com")
                    .From("cdnjs.cloudflare.com")
                    .From("cdn.jsdelivr.net")
                    .UnsafeEval();
                FontSourceDirectiveBuilder fontSrc = builder.AddFontSrc()
                    .Self()
                    .From("data:")
                    .From("fonts.gstatic.com")
                    .From("use.fontawesome.com");
                StyleSourceDirectiveBuilder styleSrc = builder.AddStyleSrc()
                    .Self()
                    .UnsafeInline()
                    .From("use.fontawesome.com")
                    .From("cdnjs.cloudflare.com")
                    .From("cdn.jsdelivr.com");
                FrameSourceDirectiveBuilder frameSrc = builder.AddFrameSrc()
                    .Self()
                    .From("sso.handofunity.eu");
                ConnectSourceDirectiveBuilder connectSrc = builder.AddConnectSrc()
                    .Self()
                    .From("sso.handofunity.eu");

                if (!IsDevelopment)
                    return;

                imageSrc.From("cdn.reloc.ly");

                scriptSrc
                // Required for Swagger UI.
                .From("'sha256-j7WFHQph0yJM122nd1knhupC4bZHKn88wyMC9Yf0s8E='")
                .From("'sha256-58X5LTc77JM40SIfH5emvqukvGIdLh2gjyr6jWXgZrQ='");
            });
            collection.AddFeaturePolicy(builder =>
            {
                builder.AddAccelerometer().None();
                builder.AddAmbientLightSensor().None();
                builder.AddAutoplay().None();
                builder.AddCamera().None();
                builder.AddEncryptedMedia().None();
                builder.AddFullscreen().None();
                builder.AddGeolocation().None();
                builder.AddGyroscope().None();
                builder.AddMagnetometer().None();
                builder.AddMicrophone().None();
                builder.AddMidi().None();
                builder.AddPayment().None();
                builder.AddPictureInPicture().None();
                builder.AddSpeaker().None();
                builder.AddSyncXHR()
                   // Required by Blazor.
                   .Self()
                   // Required for Keycloak.
                   .For("https://sso.handofunity.eu/");
                builder.AddUsb().None();
                builder.AddVR().None();
            });
        }
    }
}
