using System;
using System.Numerics;
using Dalamud.Data;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using ImGuiScene;

namespace DailyBeastTribe.Windows;

public class MainWindow : Window, IDisposable
{
    private TextureWrap goatImage;
    private Plugin plugin;
    
   



    public MainWindow(Plugin plugin, TextureWrap goatImage) : base(
        "My Amazing Window", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        var tribalQuests = questSheet.Where(q => q.BeastTribe.Row != 0);
        this.goatImage = goatImage;
        this.plugin = plugin;
       
    }

    public void Dispose()
    {
        this.goatImage.Dispose();
    }

    public override void Draw()
    {
        ImGui.Text($"The random config bool is {this.plugin.Configuration.SomePropertyToBeSavedAndWithADefault}");

        if (ImGui.Button("Show Settings"))
        {
            this.plugin.DrawConfigUI();
        }

        ImGui.Spacing();

        ImGui.Text("Have a goat:");
        ImGui.Indent(55);
        ImGui.Image(this.goatImage.ImGuiHandle, new Vector2(this.goatImage.Width, this.goatImage.Height));
        ImGui.Unindent(55);
    }
}
