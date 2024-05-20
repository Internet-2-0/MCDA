using MCDA_APP.TabControl;

namespace MCDA_APP.Controls
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class TabStyleDefaultProvider : TabStyleProvider
    {
        public TabStyleDefaultProvider(CustomTabControl tabControl) : base(tabControl)
        {
            this.Radius = 2;

            this.SelectedTabIsLarger = true;

            this.TabColorHighLighted1 = Color.FromArgb(236, 244, 252);
            this.TabColorHighLighted2 = Color.FromArgb(221, 237, 252);

            this.PageBackgroundColorHighlighted = TabColorHighLighted1;
        }
    }
}
