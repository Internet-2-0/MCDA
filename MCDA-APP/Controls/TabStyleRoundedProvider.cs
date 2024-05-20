﻿using MCDA_APP.TabControl;

namespace MCDA_APP.Controls
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class TabStyleRoundedProvider : TabStyleDefaultProvider
    {
        public TabStyleRoundedProvider(CustomTabControl tabControl) : base(tabControl)
        {
            this.Radius = 10;
            this.SelectedTabIsLarger = false;

            this.Padding = new Point(6, 3);
        }

        public override void AddTabBorder(System.Drawing.Drawing2D.GraphicsPath path, System.Drawing.Rectangle tabBounds)
        {

            switch (this.TabControl.Alignment)
            {
                case TabAlignment.Top:
                    path.AddLine(tabBounds.X, tabBounds.Bottom, tabBounds.X, tabBounds.Y + this.Radius);
                    path.AddArc(tabBounds.X, tabBounds.Y, this.Radius * 2, this.Radius * 2, 180, 90);
                    path.AddLine(tabBounds.X + this.Radius, tabBounds.Y, tabBounds.Right - this.Radius, tabBounds.Y);
                    path.AddArc(tabBounds.Right - this.Radius * 2, tabBounds.Y, this.Radius * 2, this.Radius * 2, 270, 90);
                    path.AddLine(tabBounds.Right, tabBounds.Y + this.Radius, tabBounds.Right, tabBounds.Bottom);
                    break;
                case TabAlignment.Bottom:
                    path.AddLine(tabBounds.Right, tabBounds.Y, tabBounds.Right, tabBounds.Bottom - this.Radius);
                    path.AddArc(tabBounds.Right - this.Radius * 2, tabBounds.Bottom - this.Radius * 2, this.Radius * 2, this.Radius * 2, 0, 90);
                    path.AddLine(tabBounds.Right - this.Radius, tabBounds.Bottom, tabBounds.X + this.Radius, tabBounds.Bottom);
                    path.AddArc(tabBounds.X, tabBounds.Bottom - this.Radius * 2, this.Radius * 2, this.Radius * 2, 90, 90);
                    path.AddLine(tabBounds.X, tabBounds.Bottom - this.Radius, tabBounds.X, tabBounds.Y);
                    break;
                case TabAlignment.Left:
                    path.AddLine(tabBounds.Right, tabBounds.Bottom, tabBounds.X + this.Radius, tabBounds.Bottom);
                    path.AddArc(tabBounds.X, tabBounds.Bottom - this.Radius * 2, this.Radius * 2, this.Radius * 2, 90, 90);
                    path.AddLine(tabBounds.X, tabBounds.Bottom - this.Radius, tabBounds.X, tabBounds.Y + this.Radius);
                    path.AddArc(tabBounds.X, tabBounds.Y, this.Radius * 2, this.Radius * 2, 180, 90);
                    path.AddLine(tabBounds.X + this.Radius, tabBounds.Y, tabBounds.Right, tabBounds.Y);
                    break;
                case TabAlignment.Right:
                    path.AddLine(tabBounds.X, tabBounds.Y, tabBounds.Right - this.Radius, tabBounds.Y);
                    path.AddArc(tabBounds.Right - this.Radius * 2, tabBounds.Y, this.Radius * 2, this.Radius * 2, 270, 90);
                    path.AddLine(tabBounds.Right, tabBounds.Y + this.Radius, tabBounds.Right, tabBounds.Bottom - this.Radius);
                    path.AddArc(tabBounds.Right - this.Radius * 2, tabBounds.Bottom - this.Radius * 2, this.Radius * 2, this.Radius * 2, 0, 90);
                    path.AddLine(tabBounds.Right - this.Radius, tabBounds.Bottom, tabBounds.X, tabBounds.Bottom);
                    break;
            }
        }
    }
}
