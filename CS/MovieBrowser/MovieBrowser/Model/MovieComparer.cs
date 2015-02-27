using System.Collections;
using System.Windows.Forms;

namespace MovieBrowser.Model
{
    class MovieComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var tx = (TreeNode)x;
            var ty = (TreeNode)y;
            var nodex = (Movie)tx.Tag;
            var nodey = (Movie)ty.Tag;

            if (nodex.Rating < nodey.Rating)
            {
                return 1;
            }
            else if (nodex.Rating > nodey.Rating)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

}
