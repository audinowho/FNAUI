using ImGuiNET;
using Num = System.Numerics;


namespace FNAImgui.ImGuiTools
{
	public static class NezImGuiThemes
	{
		public static void DarkTheme1()
		{
			var colors = ImGui.GetStyle().Colors;

			colors[(int) ImGuiCol.Text] = new Num.Vector4(1.00f, 1.00f, 1.00f, 1.00f);
			colors[(int) ImGuiCol.TextDisabled] = new Num.Vector4(0.50f, 0.50f, 0.50f, 1.00f);
			colors[(int) ImGuiCol.WindowBg] = new Num.Vector4(0.06f, 0.06f, 0.06f, 0.94f);
			colors[(int) ImGuiCol.ChildBg] = new Num.Vector4(1.00f, 1.00f, 1.00f, 0.00f);
			colors[(int) ImGuiCol.PopupBg] = new Num.Vector4(0.08f, 0.08f, 0.08f, 0.94f);
			colors[(int) ImGuiCol.Border] = new Num.Vector4(0.43f, 0.43f, 0.50f, 0.50f);
			colors[(int) ImGuiCol.BorderShadow] = new Num.Vector4(0.00f, 0.00f, 0.00f, 0.00f);
			colors[(int) ImGuiCol.FrameBg] = new Num.Vector4(0.20f, 0.21f, 0.22f, 0.54f);
			colors[(int) ImGuiCol.FrameBgHovered] = new Num.Vector4(0.40f, 0.40f, 0.40f, 0.40f);
			colors[(int) ImGuiCol.FrameBgActive] = new Num.Vector4(0.18f, 0.18f, 0.18f, 0.67f);
			colors[(int) ImGuiCol.TitleBg] = new Num.Vector4(0.04f, 0.04f, 0.04f, 1.00f);
			colors[(int) ImGuiCol.TitleBgActive] = new Num.Vector4(0.29f, 0.29f, 0.29f, 1.00f);
			colors[(int) ImGuiCol.TitleBgCollapsed] = new Num.Vector4(0.00f, 0.00f, 0.00f, 0.51f);
			colors[(int) ImGuiCol.MenuBarBg] = new Num.Vector4(0.14f, 0.14f, 0.14f, 1.00f);
			colors[(int) ImGuiCol.ScrollbarBg] = new Num.Vector4(0.02f, 0.02f, 0.02f, 0.53f);
			colors[(int) ImGuiCol.ScrollbarGrab] = new Num.Vector4(0.31f, 0.31f, 0.31f, 1.00f);
			colors[(int) ImGuiCol.ScrollbarGrabHovered] = new Num.Vector4(0.41f, 0.41f, 0.41f, 1.00f);
			colors[(int) ImGuiCol.ScrollbarGrabActive] = new Num.Vector4(0.51f, 0.51f, 0.51f, 1.00f);
			colors[(int) ImGuiCol.CheckMark] = new Num.Vector4(0.94f, 0.94f, 0.94f, 1.00f);
			colors[(int) ImGuiCol.SliderGrab] = new Num.Vector4(0.51f, 0.51f, 0.51f, 1.00f);
			colors[(int) ImGuiCol.SliderGrabActive] = new Num.Vector4(0.86f, 0.86f, 0.86f, 1.00f);
			colors[(int) ImGuiCol.Button] = new Num.Vector4(0.44f, 0.44f, 0.44f, 0.40f);
			colors[(int) ImGuiCol.ButtonHovered] = new Num.Vector4(0.46f, 0.47f, 0.48f, 1.00f);
			colors[(int) ImGuiCol.ButtonActive] = new Num.Vector4(0.42f, 0.42f, 0.42f, 1.00f);
			colors[(int) ImGuiCol.Header] = new Num.Vector4(0.70f, 0.70f, 0.70f, 0.31f);
			colors[(int) ImGuiCol.HeaderHovered] = new Num.Vector4(0.70f, 0.70f, 0.70f, 0.80f);
			colors[(int) ImGuiCol.HeaderActive] = new Num.Vector4(0.48f, 0.50f, 0.52f, 1.00f);
			colors[(int) ImGuiCol.Separator] = new Num.Vector4(0.43f, 0.43f, 0.50f, 0.50f);
			colors[(int) ImGuiCol.SeparatorHovered] = new Num.Vector4(0.72f, 0.72f, 0.72f, 0.78f);
			colors[(int) ImGuiCol.SeparatorActive] = new Num.Vector4(0.51f, 0.51f, 0.51f, 1.00f);
			colors[(int) ImGuiCol.ResizeGrip] = new Num.Vector4(0.91f, 0.91f, 0.91f, 0.25f);
			colors[(int) ImGuiCol.ResizeGripHovered] = new Num.Vector4(0.81f, 0.81f, 0.81f, 0.67f);
			colors[(int) ImGuiCol.ResizeGripActive] = new Num.Vector4(0.46f, 0.46f, 0.46f, 0.95f);
			colors[(int) ImGuiCol.PlotLines] = new Num.Vector4(0.61f, 0.61f, 0.61f, 1.00f);
			colors[(int) ImGuiCol.PlotLinesHovered] = new Num.Vector4(1.00f, 0.43f, 0.35f, 1.00f);
			colors[(int) ImGuiCol.PlotHistogram] = new Num.Vector4(0.73f, 0.60f, 0.15f, 1.00f);
			colors[(int) ImGuiCol.PlotHistogramHovered] = new Num.Vector4(1.00f, 0.60f, 0.00f, 1.00f);
			colors[(int) ImGuiCol.TextSelectedBg] = new Num.Vector4(0.87f, 0.87f, 0.87f, 0.35f);
			colors[(int) ImGuiCol.ModalWindowDimBg] = new Num.Vector4(0.80f, 0.80f, 0.80f, 0.35f);
			colors[(int) ImGuiCol.DragDropTarget] = new Num.Vector4(1.00f, 1.00f, 0.00f, 0.90f);
			colors[(int) ImGuiCol.NavHighlight] = new Num.Vector4(0.60f, 0.60f, 0.60f, 1.00f);
			colors[(int) ImGuiCol.NavWindowingHighlight] = new Num.Vector4(1.00f, 1.00f, 1.00f, 0.70f);
		}

	}
}