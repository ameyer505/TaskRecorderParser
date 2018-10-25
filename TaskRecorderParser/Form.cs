using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            else if (rb_form.Checked)
                return menuItemList.OrderBy(x => x.FormName).ToList();
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
                btn_exportCSV.Enabled = true;
                btn_exportXLSX.Enabled = true;
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

        private void rbForm_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListView(GetSorting(menuItemList));
        }

        private void btnExportXLSX_Click(object sender, EventArgs e)
        {
            List<Models.MenuItem> menuItemList = new List<Models.MenuItem>();
            menuItemList = GetSorting(ParseInputFile(tb_input.Text));
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel File|.xlsx",
                Title = "Save As Excel File",
                CheckPathExists = true,
                RestoreDirectory = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(saveFileDialog.FileName);
                using (ExcelPackage ep = new ExcelPackage(fi))
                {
                    ExcelWorksheet ws = ep.Workbook.Worksheets.Add("Menu Items");
                    ws.Cells[1, 1].Value = "Menu Item Label";
                    ws.Cells[1, 2].Value = "Menu Item Name";
                    ws.Cells[1, 3].Value = "Menu Item Type";
                    ws.Cells[1, 4].Value = "Form Name";
                    ws.Cells[2, 1].LoadFromCollection(menuItemList);
                    ep.Save();
                }
                MessageBox.Show("File Exported Successfully!", "File Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
               
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            List<Models.MenuItem> menuItemList = new List<Models.MenuItem>();
            menuItemList = GetSorting(ParseInputFile(tb_input.Text));
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV File|.csv",
                Title = "Save As CSV File",
                CheckPathExists = true,
                RestoreDirectory = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csv = new StringBuilder();
                string header = string.Format("{0},{1},{2},{3}", "Menu Item Label", "Menu Item Name", "Menu Item Type", "Form Name");
                csv.AppendLine(header);
                foreach (var menuItem in menuItemList)
                {
                    string line = string.Format("{0},{1},{2},{3}", menuItem.Label, menuItem.Name, menuItem.Type, menuItem.FormName);
                    csv.AppendLine(line);
                }
                File.WriteAllText(saveFileDialog.FileName, csv.ToString());
                MessageBox.Show("File Exported Successfully!", "File Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
