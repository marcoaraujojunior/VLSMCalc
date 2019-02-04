using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using IPCalculatorLib;

namespace VLSMCalc
{
    public partial class FrmVlsm : Form
    {
        private int count = 1;
        private int topLbl = 37;
        private int topTxt = 34;

        public FrmVlsm()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
        }

        private void FrmVlsm_Load(object sender, EventArgs e)
        {
            this.createSubnetRow();
        }

        private void createSubnetRow()
        {
            this.createLabel(
                "Subnet " + this.count + " Hosts Needed: ",
                "lblSubnet" + this.count,
                this.topLbl
            );
            this.createTextBox("txtSubnet" + this.count);
            this.count++;
            this.topTxt += 28;
            this.topLbl += 28;
        }

        private void createTextBox(string name)
        {
            TextBox txt = new TextBox();
            txt.Name = name;
            txt.Text = "";
            txt.Location = new Point(140, this.topTxt);
            txt.TabIndex = this.count;
            txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxKeyUp);
            this.Controls.Add(txt);
        }

        private void createLabel(string text, string name, int y, int x = 9)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Name = name;
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;
            this.Controls.Add(lbl);
        }

        private void textBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.createSubnetRow();
                SendKeys.Send("{TAB}");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNetwork.Text = "";
            txtNetwork.Focus();
            this.deleteLabelTextBox();
            this.createSubnetRow();
        }

        private void deleteLabelTextBox()
        {
            List<Control> objToDelete = new List<Control>();
            foreach (Control x in this.Controls)
            {
                bool isTextBox = x is TextBox;
                bool isLabel = x is Label;
                bool shouldDelete = false;

                if (isTextBox && ((TextBox)x).Name.Contains("txtSubnet"))
                    shouldDelete = true;

                if (isLabel && ((Label)x).Name.Contains("lblSubnet"))
                    shouldDelete = true;

                if (shouldDelete)
                {
                    objToDelete.Add(x);
                }
            }

            foreach (Control item in objToDelete)
            {
                this.Controls.Remove(item);
                item.Dispose();
            }
            this.count = 1;
            this.topLbl = 37;
            this.topTxt = 34;
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            List<int> hosts = new List<int>();
            int host;
            int topLbl = 33;
            var textboxes = this.Controls.OfType<TextBox>();

            if (txtNetwork.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Network Needed!",
                    "Data Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            foreach (TextBox txt in textboxes)
            {
                if (txt.Name.Contains("txtSubnet") && int.TryParse(txt.Text, out host))
                {
                    hosts.Add(host);
                }
            }

            Subnet subnet = new Subnet(hosts, txtNetwork.Text);
            if (!subnet.isValid())
            {
                MessageBox.Show(
                    "Invalid Data!",
                    "Data Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            this.deleteLabelTextBox();

            String[] title = new String[] {
                "Network",
                "First IP",
                "Last IP",
                "Broadcast",
                "Mask"
            };

            this.showResult(title, 120, topLbl);
            topLbl += 28;

            foreach (Network network in subnet.getNetworks())
            {
                int leftLbl = 120;
                String getNetwork = network.getNetwork() + "/" + network.getPrefix().ToString();
                String[] net = new String[] {
                    getNetwork,
                    network.getFirstIP(),
                    network.getLastIP(),
                    network.getBroadcast(),
                    network.getSubnetMask(),
                };

                Label lbl = new Label();
                lbl.Text = "Subnet for " + network.getNeededSize().ToString() + " hosts:";
                lbl.Name = "lblSubnet";
                lbl.Location = new Point(2, topLbl);
                lbl.Size = new Size(110, 17);
                lbl.TextAlign = ContentAlignment.MiddleLeft;

                this.Controls.Add(lbl);

                this.showResult(net, leftLbl, topLbl);

                topLbl += 28;
            }
        }

        private void showResult(String[] row, int leftLbl, int topLbl, bool border = true)
        {
            foreach (String item in row)
            {
                Label lbl = new Label();
                lbl.Text = item;
                lbl.Name = "lblSubnet";
                lbl.Location = new Point(leftLbl, topLbl);
                lbl.Size = new Size(110, 17);

                if (border)
                    lbl.BorderStyle = BorderStyle.FixedSingle;

                lbl.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(lbl);
                leftLbl += 116;
            }
        }

        private void txtNetwork_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
