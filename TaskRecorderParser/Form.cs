using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TaskRecorderParser
{
    public partial class Form : System.Windows.Forms.Form
    {
        private static List<Models.MenuItem> menuItemList;

        public Form()
        {
            InitializeComponent();
            ResizeListViewColumns();
        }

        #region HelperMethods

        private List<Models.MenuItem> ParseInputFile(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            string ns = "http://schemas.datacontract.org/2004/07/Microsoft.Dynamics.Client.ServerForm.TaskRecording";
            if (xDoc.GetElementsByTagName("Recording", ns).Count > 0)
            {
                tb_taskRecordingType.Text = "D365FO";
                return ParseD365FOTaskRecording(path);
            }
            else
            {
                tb_taskRecordingType.Text = "AX 2012";
                return ParseAXTaskRecording(path);
            }
        }

        private List<Models.MenuItem> ParseD365FOTaskRecording(string path)
        {
            List<Models.MenuItem> menuItemList = new List<Models.MenuItem>();
            try
            {
                string ns = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlNodeList values = xDoc.GetElementsByTagName("Value", ns);
                foreach (XmlNode value in values)
                {
                    Models.MenuItem menuItem = new Models.MenuItem();
                    menuItem.FormName = value["FormName"]?.InnerText ?? "";
                    XmlNode annotation = value["Annotations"]["Annotation"];
                    if (annotation != null)
                    {
                        menuItem.Name = annotation["MenuItemName"]?.InnerText ?? "";
                        menuItem.Label = annotation["MenuItemLabel"]?.InnerText ?? "";
                        menuItem.Type = annotation["MenuItemType"]?.InnerText ?? "";

                        menuItemList.Add(menuItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Parsing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return menuItemList.GroupBy(mi => new { mi.Name, mi.Label, mi.Type, mi.FormName }).Select(x => x.First()).ToList();
        }

        private List<Models.MenuItem> ParseAXTaskRecording(string path)
        {
            List<Models.MenuItem> menuItemList = new List<Models.MenuItem>();
            try
            {
                XDocument xDoc = XDocument.Load(path);
                var formActivateEvents = xDoc.Descendants("event").Where(n => n.Attribute("name").Value == "FormActivate");
                foreach(var formActivateEvent in formActivateEvents)
                {
                    Models.MenuItem mi = new Models.MenuItem();
                    mi.Label = formActivateEvent.Attribute("formcaption").Value;
                    mi.Name = formActivateEvent.Attribute("menuitemname").Value;
                    mi.Type = formActivateEvent.Attribute("menuitemtype").Value;
                    mi.FormName = formActivateEvent.Attribute("formname").Value;

                    menuItemList.Add(mi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Parsing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return menuItemList.GroupBy(mi => new { mi.Name, mi.Label, mi.Type, mi.FormName }).Select(x => x.First()).ToList();
        }

        private void ResizeListViewColumns()
        {
            foreach (ColumnHeader column in lv_output.Columns)
            {
                column.Width = -2;
            }
        }

        private List<Models.MenuItem> GetSorting(List<Models.MenuItem> menuItemList)
        {
            if (rb_name.Checked)
                return menuItemList.OrderBy(x => x.Name).ToList();
            else if (rb_label.Checked)
                return menuItemList.OrderBy(x => x.Label).ToList();
            else if (rb_type.Checked)
                return menuItemList.OrderBy(x => x.Type).ToList();
            return menuItemList;
        }

        private void UpdateListView(List<Models.MenuItem> menuItemList)
        {
            lv_output.Items.Clear();
            foreach (var menuItem in menuItemList)
            {
                ListViewItem item = new ListViewItem(new[] { menuItem.Label, menuItem.Name, menuItem.Type, menuItem.FormName });
                lv_output.Items.Add(item);
            }
            ResizeListViewColumns();
        }

        #endregion

        #region EventListeners

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fileDialog.Filter = "Task Recorder Files|*.xml";
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
                menuItemList = new List<Models.MenuItem>();
                menuItemList = ParseInputFile(path);
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
