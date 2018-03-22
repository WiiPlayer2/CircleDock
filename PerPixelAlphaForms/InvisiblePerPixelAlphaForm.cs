using System;
using System.Windows.Forms;

namespace PerPixelAlphaForms
{
	public class InvisiblePerPixelAlphaForm : PerPixelAlphaForm
	{
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle = 134742016;
				createParams.ClassStyle |= 128;
				return createParams;
			}
		}

		public InvisiblePerPixelAlphaForm()
		{
			base.FormBorderStyle = FormBorderStyle.None;
			base.Hide();
		}
	}
}
