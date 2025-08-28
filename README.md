# dansertodiscord
Render osu! replays using [danser-go](https://github.com/Wieku/danser-go) and upload them to a Discord channel through webhooks.
Developed as a proof of concept using Windows Forms with C#.

## Usage
1. Install [danser-go](https://github.com/Wieku/danser-go).
2. Right click on a Discord channel and select "Edit Channel".
3. Click on "Integrations" and "Create Webhook".
4. Click on the newly created webhook and edit it as you please. Then click "Copy Webhook URL".
5. In the Settings tab of sendtodiscord, paste the webhook URL in the specified text box.
6. Select the danser binary (danser-cli.exe) from your danser installation.
7. Select a danser settings file to use. An [example settings file](example-settings.json) is included in the repository, see [Example Settings](#example-settings).
8. In the Render tab, select a replay file and optionally, the start and end times of the replay.
9. The program is now ready to render and upload replays.

## Notes
- To cancel a render, "Show danser terminal?" must be checked in settings, and then Ctrl-C will exit danser when performed in a danser terminal. This may result in a temp video folder left behind in the videos directory of the danser installation.
- User configuration is stored at `%APPDATA%/sendtodiscord/`.
- dansertodiscord was developed to work with version 0.11.0 of danser. Other versions may work, but have not been tested.
- The project files and program directories do not match with the name of the repository because I did not have the foresight to choose a better name when development started, and manual renaming is a pain.
## Example Settings
- It is recommended that you copy the example-settings to your danser settings folder and use the danser GUI to edit the settings as you please. Some settings including the osu! directories in the General section, the Skin settings, and the Recording settings (especially the Encoder) may need to be changed before the settings can work.
- These settings prioritize these goals in this order: a file size below 10 MiB, 60 fps, then video quality. As a result, rendered videos are only in 720p and may further suffer from pixelation, causing videos to not look as smooth as they should.
