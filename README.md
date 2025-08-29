# dansertodiscord
Render osu! replays using [danser-go](https://github.com/Wieku/danser-go) and upload them to a Discord channel through webhooks.
Developed as a proof of concept using Windows Forms with C#.

## Usage
1. Install [danser-go](https://github.com/Wieku/danser-go).
2. Install the latest version of dansertodiscord for your system from the [releases](https://github.com/tinbolw/dansertodiscord/releases/latest) page.
3. Right click on a Discord channel and select "Edit Channel".
4. Click on "Integrations" and "Create Webhook".
5. Click on the newly created webhook and edit it as you please. Then click "Copy Webhook URL".
6. In the Settings tab of sendtodiscord, paste the webhook URL in the specified text box.
7. Select the danser binary (danser-cli.exe) from your danser installation.
8. Select a danser settings file to use. An [example settings file](example-settings.json) is included in the repository, see [Example Settings](#example-settings) for usage.
9. Optionally, if it wasn't detected by default, select your osu! directory to enable the program to render your latest replay.

   You can now render replays. You can also specify [arguments](https://github.com/Wieku/danser-go?tab=readme-ov-file#cli-run-arguments) for danser to use.
   ### Do not use the `-replay` and `-out` arguments as they are used by dansertodiscord to manage rendered video files. The program will not work and may crash if you do.

## Notes
- User configuration is stored at `%APPDATA%/sendtodiscord/`.
- dansertodiscord was developed to work with version 0.11.0 of danser. Other versions may work, but have not been tested.
- dansertodiscord was developed on Windows x64 platform, and functionality on other platforms has not been tested.
- The project files and program directories do not match with the name of the repository because I did not have the foresight to choose a better name when development started, and manual renaming is a pain.
- Videos larger than [10 MiB](https://discord.com/developers/docs/reference#uploading-files) and up to 1 GB will automatically be uploaded to [Litterbox](https://litterbox.catbox.moe/) where they will persist for three days after upload. If a video is uploaded there, a direct link to it will be sent to the Discord webhook where it should embed in the channel and be viewable, if the video format is permitted.
## Example Settings
- It is recommended that you copy the example-settings to your danser settings folder and use the danser GUI to edit the settings as you please. Some settings, including the osu! directories in the General section, the Skin settings, and the Recording settings (especially the Encoder) may need to be changed before the settings can work.
- These settings prioritize these goals in this order: a file size below 10 MiB, 60 fps, then video quality. As a result, rendered videos are only in 720p and may further suffer from pixelation, causing videos to not look as smooth as they should.
