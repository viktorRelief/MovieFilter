using MovieFilter.Data;
using MovieFilter.FilterLogic;
using MovieFilter.Filters;
using System;
using System.Windows.Forms;

namespace MovieFilter
{
    public partial class AdditionalDataForm : Form
    {
        private DefaultFilter defaultFilter;
        private FilterDataLogic<string> filterDataLogic;
        public int index;

        public AdditionalDataForm()
        {
            InitializeComponent();

            defaultFilter = new DefaultFilter();
            filterDataLogic = new FilterDataLogic<string>(defaultFilter);
        }

        private void AdditionalDataForm_Load_1(object sender, EventArgs e)
        {
            try
            {
                filterDataLogic.FilterDataGrid("FilterValuesActorsBirthDate", dateOfBirthGroupBox, index);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
