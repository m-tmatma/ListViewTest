namespace ListViewTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddListviewItems();
        }


        private void AddListviewItems()
        {
            this.listView1.Columns.Add("Item Colunm", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Item Colunm 2", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Item Colunm 3", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Item Colunm 4", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Item Colunm 5", -2, HorizontalAlignment.Left);

            this.listView1.View = View.Details;
            this.listView1.LabelEdit = false;
            this.listView1.AllowColumnReorder = true;
            this.listView1.CheckBoxes = true;

            for (int i = 0; i < 10; i++)
            {
                ProgressBar prg = new ProgressBar();
                prg.Value = 100 / (i + 1);
                var item1 = new ListViewItem("item", 0);
                item1.Checked = true;
                item1.SubItems.Add("1");
                item1.SubItems.Add("2");
                item1.SubItems.Add("3");
                var subitem = item1.SubItems.Add("-------");
                subitem.Tag = prg;

                this.listView1.Controls.Add(prg);
                item1.SubItems.Add("5");
                this.listView1.Items.Add(item1);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.Items)
            {
                int index = 0;
                var subitem = item.SubItems[4];
                var progress = (ProgressBar)subitem.Tag;
                var bounds = subitem.Bounds;
                progress.Bounds = bounds;
            }
        }
    }
}