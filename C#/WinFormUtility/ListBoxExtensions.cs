using System;
using System.Windows.Forms;

namespace WinFormUtility
{
    public static class ListBoxExtensions
    {
        public static void ScrollToBottom(this ListBox listBox)
        {
            int visibleItems = listBox.ClientSize.Height / listBox.ItemHeight;
            listBox.TopIndex = Math.Max(listBox.Items.Count - visibleItems + 1, 0);
        }
    }
}
