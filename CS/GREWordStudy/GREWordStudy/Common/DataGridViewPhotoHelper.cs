using System;
using System.Windows.Forms;
using System.ComponentModel;
using GREWordStudy.Model;

namespace GREWordStudy.Common
{

    class DataGridViewPhotoHelper
    {
        PictureBox[] _picsbox;

        readonly DataGridView _gridview;

        public DataGridViewPhotoHelper(DataGridView gridView)
        {
            _gridview = gridView;
        }

        public void Load(WordDefinition[] words)
        {
            _picsbox = new PictureBox[words.Length];


            _gridview.Rows.Clear();
            for (int i = 0; i < words.Length; i++)
            {
                //picsbox[i] = new PictureBox();

                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.Height = 100;
                DataGridViewTextBoxCell text = new DataGridViewTextBoxCell()
                {
                    Value = words[i].Definition
                };
                DataGridViewImageCell img = new DataGridViewImageCell()
                {
                    Value = null
                };
                DataGridViewTextBoxCell tag = new DataGridViewTextBoxCell()
                {
                    Value = words[i].Tag
                };

                if (words[i].Image.Length > 1)
                {
                    _picsbox[i] = new PictureBox();
                    _picsbox[i].ImageLocation = words[i].Image;
                    _picsbox[i].LoadCompleted += Loaded;
                    _picsbox[i].LoadAsync();
                }

                dgvr.Cells.Add(text);
                dgvr.Cells.Add(img);
                dgvr.Cells.Add(tag);
                _gridview.Rows.Add(dgvr);
            }
        }


        private void Loaded(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                PictureBox pb = (PictureBox)sender;
                int index = Convert.ToInt32(pb.Tag);

                DataGridViewImageCell img = (DataGridViewImageCell)_gridview.Rows[index].Cells[1];
                img.Value = pb.Image;
            }
            catch 
            {
            }
        }

    }
}
