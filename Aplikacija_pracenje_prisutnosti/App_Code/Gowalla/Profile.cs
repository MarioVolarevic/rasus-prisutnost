//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//namespace gowalaWarp2
//{
//    public partial class Profile : Form
//    {
//        Form parent;
//        Gowalla user;

//        public Profile(Form parent,Gowalla user)        
//        {
//            this.parent = parent;
//            this.user = user;
//            InitializeComponent();

//            fillFormWithData();
//            dataGridView1_CellClick(this, new DataGridViewCellEventArgs(0,0));
//        }

//        void Profile_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
//        {
//            this.parent.Close();
//        }

//        void fillFormWithData()
//        {
//            labelFirstName.Text = user.FirstName;
//            labelLastName.Text = user.LastName;
//            pictureBoxAvatar.Image = user.Avatar;


//            textBoxHtml.Text += "Prijatelji:\r\n";


//            dataGridView1.AutoGenerateColumns = false;
//            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
//            dataGridView1.ScrollBars = ScrollBars.Vertical;
//            dataGridView1.BorderStyle = BorderStyle.None;
//            dataGridView1.RowHeadersVisible = false;
            

//            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
//            c1.HeaderText = "Ime";
//            c1.DataPropertyName = "FirstName";
//            dataGridView1.Columns.Add(c1);

//            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
//            c2.HeaderText = "Prezime";
//            c2.DataPropertyName = "LastName";
//            dataGridView1.Columns.Add(c2);

//            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();            
//            c3.DataPropertyName = "Alias";
//            c3.Visible = false;
//            dataGridView1.Columns.Add(c3);

//            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
//            c4.HeaderText = "Zadnja aktivnost";
//            c4.DataPropertyName = "LastCheckin";            
//            dataGridView1.Columns.Add(c4);


            
            
//            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

//            dataGridView1.DataSource = user.friends;
           

//            foreach (Friend friend in user.friends)
//            {
//                textBoxHtml.Text = textBoxHtml.Text + friend.firstName + " " + friend.lastName + " --- " + friend.alias + "\r\n";
//            }
//        }



//        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex >= 0)
//            {
//                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[2];
//                Image image = user.friends.Find(x => x.Alias.Equals(cell.Value.ToString())).avatar;
//                pictureBoxFriend.Image = image;
//            }
//        }
//    }
//}
