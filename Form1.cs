using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace TaskRecorderParser
{
    public partial class Form1 : Form
    {
        private static List<MenuItem> menuItemList;

        public Form1()
        {
            InitializeComponent();
            ResizeListViewColumns();
        }

        #region HelperMethods

        private List<MenuItem> ParseInputFile(string path)
        {
            List<MenuItem> menuItemList = new List<MenuItem>();
            try
            { 
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlNodeList annotations = xDoc.GetElementsByTagName("Annotation");
                foreach (XmlNode annotation in annotations)
                {
                    MenuItem menuItem = new MenuItem();
                    var name = annotation["MenuItemName"]?.InnerText;
                    var label = annotation["MenuItemLabel"]?.InnerText;
                    var type = annotation["MenuItemType"]?.InnerText;

                    if (name != null)
                        menuItem.name = name;
                    if (label != null)
                        menuItem.label = label;
                    if (type != null)
                        menuItem.type = type;
                    if (name != null && label != null && type != null)
                        menuItemList.Add(menuItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Parsing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return menuItemList.GroupBy(mi => new { mi.name, mi.label, mi.type }).Select(x => x.First()).ToList();
        }

        private void ResizeListViewColumns()
        {
            foreach (ColumnHeader column in lv_output.Columns)
            {
                column.Width = -2;
            }
        }

        private List<MenuItem> GetSorting(List<MenuItem> menuItemList)
        {
            if (rb_name.Checked)
                return menuItemList.OrderBy(x => x.name).ToList();
            else if (rb_label.Checked)
                return menuItemList.OrderBy(x => x.label).ToList();
            else if (rb_type.Checked)
                return menuItemList.OrderBy(x => x.type).ToList();
            return menuItemList;
        }

        private void UpdateListView(List<MenuItem> menuItemList)
        {
            lv_output.Items.Clear();
            foreach (var menuItem in menuItemList)
            {
                ListViewItem item = new ListViewItem(new[] { menuItem.label, menuItem.name, menuItem.type });
                lv_output.Items.Add(item);
            }
            ResizeListViewColumns();
        }

        #endregion

        #region Classes

        public class MenuItem
        {
            public string name { get; set; }
            public string label { get; set; }
            public string type { get; set; }
        }

        #endregion

        #region EventListeners

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tb_input.Text = fileDialog.FileName;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string path = tb_input.Text;
            if (File.Exists(path))
            {
                menuItemList = new List<MenuItem>();
                menuItemList = this.ParseInputFile(path);
                UpdateListView(GetSorting(menuItemList));
            }
            else
            {
                MessageBox.Show("File does not exist", "Error Parsing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListView(GetSorting(menuItemList));
        }

        private void rbLabel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListView(GetSorting(menuItemList));
        }

        private void rbType_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListView(GetSorting(menuItemList));
        }

        #endregion
    }
}
