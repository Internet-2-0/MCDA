namespace MCDA_APP.Rendering
{
    public class CustomRender : ToolStripSystemRenderer
    {
        private readonly bool _isTopMenu;

        public CustomRender(bool isTopMenu)
        {
            this._isTopMenu = isTopMenu;
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (_isTopMenu && e.ToolStrip is MenuStrip)
            {
                e.Graphics.DrawImage(new Bitmap(Properties.Resources.malcore_icon), new PointF(7, 7));
            }
        }
    }
}
