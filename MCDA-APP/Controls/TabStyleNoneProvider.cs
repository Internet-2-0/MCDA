using MCDA_APP.TabControl;

namespace MCDA_APP.Controls
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class TabStyleNoneProvider : TabStyleProvider
    {
        public TabStyleNoneProvider(CustomTabControl tabControl) : base(tabControl)
        {
        }

        public override void AddTabBorder(System.Drawing.Drawing2D.GraphicsPath path, System.Drawing.Rectangle tabBounds)
        {
        }
    }
}
