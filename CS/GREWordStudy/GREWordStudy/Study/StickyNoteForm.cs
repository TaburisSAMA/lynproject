using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GREWordStudy.Study
{
    public partial class StickyNoteForm : Form
    {
        public StickyNoteForm()
        {
            InitializeComponent();
        }

        #region Text Effects
        private FontStyle MakeFontStyle(bool bold, bool italic, bool underline, bool strike)
        {
            FontStyle fs = FontStyle.Regular;
            if (bold)
                fs = fs | FontStyle.Bold;
            if (italic)
                fs = fs | FontStyle.Italic;
            if (underline)
                fs = fs | FontStyle.Underline;
            if (strike)
                fs = fs | FontStyle.Strikeout;
            return fs;
        }

        private void MakeBold()
        {
            FontStyle fs = MakeFontStyle(!rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout);
            Font newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void MakeItalic()
        {
            FontStyle fs = MakeFontStyle(rtfComment.SelectionFont.Bold, !rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout);
            Font newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void MakeUnderline()
        {
            FontStyle fs = MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, !rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout);
            Font newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void MakeStrikethrough()
        {
            FontStyle fs = MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, !rtfComment.SelectionFont.Strikeout);
            Font newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void SetFontSizeAsIncrement(float increment)
        {
            try
            {
                SetFontSize(rtfComment.SelectionFont.Size + increment);
            }
            catch { }
        }

        private void SetFontSize(float fontsize)
        {
            try
            {
                rtfComment.SelectionFont = new Font(rtfComment.SelectionFont.FontFamily, (float)(fontsize), MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout));
            }
            catch { }
        }

        private void SetCommentFont(Font font)
        {
            font = new Font(font.FontFamily, rtfComment.SelectionFont.Size, MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout));
            if (rtfComment.SelectedText.Length == 0)
            {
                rtfComment.Font = font;
            }
            else
            {
                rtfComment.SelectionFont = font;
            }
        }
        private void SetCommentColor(object sender)
        {
            rtfComment.SelectionColor = ((ToolStripMenuItem)sender).ForeColor;
        }

        private void SetCommentBackgroundColor(object sender)
        {
            rtfComment.SelectionBackColor = ((ToolStripMenuItem)sender).BackColor;
        }
        #endregion

        private void tsBold_Click(object sender, EventArgs e)
        {
            MakeBold();
        }
        private void tsItalic_Click(object sender, EventArgs e)
        {
            MakeItalic();
        }

        private void tsUnderline_Click(object sender, EventArgs e)
        {
            MakeUnderline();
        }

        private void tsStrikethrough_Click(object sender, EventArgs e)
        {
            MakeStrikethrough();

        }

        private void tsColorRed_Click(object sender, EventArgs e)
        {
            SetCommentColor(sender);
        }

        private void tsGreen_Click(object sender, EventArgs e)
        {
            SetCommentColor(sender);
        }

        private void tsBlue_Click(object sender, EventArgs e)
        {
            SetCommentColor(sender);
        }

        private void tsNormalColor_Click(object sender, EventArgs e)
        {
            SetCommentColor(sender);
            SetCommentBackgroundColor(sender);
        }

        private void tsYellowBackground_Click(object sender, EventArgs e)
        {
            SetCommentBackgroundColor(sender);
        }

        private void tsLightGreenBackground_Click(object sender, EventArgs e)
        {
            SetCommentBackgroundColor(sender);
        }

        private void tsFontSegoe_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontSegoe.Font);
        }

        private void tsFontPalatino_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontPalatino.Font);
        }

        private void tsFontCandara_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontCandara.Font);
        }

        private void tsFontCorbel_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontCorbel.Font);
        }

        private void tsFontVrinda_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontVrinda.Font);
        }

        private void tsFontBangla_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontBangla.Font);
        }

        private void tsFontIncrease_Click(object sender, EventArgs e)
        {
            SetFontSizeAsIncrement((float)4.0);
        }

        private void tsFontDecrease_Click(object sender, EventArgs e)
        {
            SetFontSizeAsIncrement((float)-4.0);

        }

        private void tsFontSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetFontSize((float)Convert.ToDouble(tsFontSize.Text));
            }
            catch { }
        }



    }
}
