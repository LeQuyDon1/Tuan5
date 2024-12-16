using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoanThao
{
    public partial class Form1 : Form
    {
        private string currentFilePath = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richText.Clear();
            richText.Font = new Font("Tahoma", 14);
            richText.ForeColor = Color.Black;
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            currentFilePath = null;
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.ForeColor = fontDlg.Color;
                richText.Font = fontDlg.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                    SaveToFile(currentFilePath);
                }
            }
            else
            {
                SaveToFile(currentFilePath);
                MessageBox.Show("Lưu văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SaveToFile(string filePath)
        {
            try
            {
                if (Path.GetExtension(filePath).ToLower() == ".rtf")
                {
                    richText.SaveFile(filePath, RichTextBoxStreamType.RichText);
                }
                else
                {
                    File.WriteAllText(filePath, richText.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu tệp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lưuTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                try
                {
                    if (Path.GetExtension(currentFilePath).ToLower() == ".rtf")
                    {
                        richText.LoadFile(currentFilePath, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richText.Text = File.ReadAllText(currentFilePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở tệp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }
        private void ToggleFontStyle(FontStyle style)
        {
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newStyle;

                if (currentFont.Style.HasFlag(style))
                {

                    newStyle = currentFont.Style & ~style;
                }
                else
                {
                    newStyle = currentFont.Style | style;
                }

                richText.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        private void vănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Clear();
            richText.Font = new Font("Tahoma", 14);
            richText.ForeColor = Color.Black;
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            currentFilePath = null;
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                    SaveToFile(currentFilePath);
                }
            }
            else
            {
                SaveToFile(currentFilePath);
                MessageBox.Show("Lưu văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
